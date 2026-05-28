using DAL;
using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using LoanDAL = DAL.Repositories.LoanDAL;
using System.Web;

namespace BLL.Services
{
    public class LoanService 
    {
        public static List<LoanSchedulesDTO> GetSchedulesByAccountNumber(string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                return new List<LoanSchedulesDTO>();
            }

            return LoanDAL.GetSchedulesByAccountNumber(accountNumber.Trim());
        }
        public static bool ProcessNewLoanRegistration(LoanContractDTO loanContract)
        {
            
            List<LoanSchedulesDTO> calculatedSchedules = GenerateSchedulesLogic(loanContract);

          
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    
                    bool isContractSaved = LoanDAL.CreateLoanContract(loanContract);
                    if (!isContractSaved)
                    {
                        throw new Exception("Lỗi khi tao tai khoan vay no!");
                    }

                    bool isScheduleSaved = LoanDAL.CreateLoanSchedules(calculatedSchedules);
                    if (!isScheduleSaved)
                    {
                        throw new Exception("Lỗi khi tao lich tra no");
                    }

                    bool isDisbursed = false;
                    
                    isDisbursed  = AccountService.AddAccountBalance(loanContract.AccountNumber, loanContract.LoanAmount);
                    if (!isDisbursed)
                    {
                        throw new Exception("Lỗi khi giai ngan!");
                    }

                    if (isContractSaved && isScheduleSaved && isDisbursed)
                    {
                        scope.Complete(); // Lệnh này tương đương với Commit
                        return true;
                    }
                    else
                    {
                        return false; 
                    }
                }
                catch (Exception ex)
                {
                    // Bắt lỗi và đẩy lên cho Form hiển thị
                    throw new Exception("Lỗi Service khi xử lý khoản vay: " + ex.Message);
                }
            }
        }


        private static List<LoanSchedulesDTO> GenerateSchedulesLogic(LoanContractDTO loanContract)
        {
            List<LoanSchedulesDTO> schedules = new List<LoanSchedulesDTO>();

            decimal principalPerMonth = Math.Round(loanContract.LoanAmount / loanContract.TermMonths, 0);
            decimal currentBalance = loanContract.LoanAmount;
            decimal totalPrincipalDistributed = 0;

            // Biến lưu mốc thời gian để đếm số ngày thực tế
            DateTime lastDate = DateTime.Now.Date; // Bắt đầu tính từ ngày giải ngân hôm nay

            for (int i = 1; i < loanContract.TermMonths; i++)
            {
                // 1. Xác định ngày đến hạn của kỳ này
                DateTime currentDate = DateTime.Now.Date.AddMonths(i);

                // 2. Đếm số ngày thực tế giữa 2 kỳ
                int actualDays = (currentDate - lastDate).Days;

                // 3. TÍNH LÃI THEO CÔNG THỨC 
                decimal expectedInterest = Math.Round(currentBalance * (loanContract.InterestRate / 365m) * actualDays, 0);

                schedules.Add(new LoanSchedulesDTO
                {
                    ContractID = loanContract.ContractID,
                    DueDate = currentDate,
                    ExpectedPrincipal = principalPerMonth,
                    ExpectedInterest = expectedInterest,
                    Status = "Pending",
                    PrincipalPaid = 0,
                    InterestPaid = 0,
                    PenaltyAmount = 0
                });

                currentBalance -= principalPerMonth;
                totalPrincipalDistributed += principalPerMonth;

                // Cập nhật lại mốc thời gian cho vòng lặp tiếp theo
                lastDate = currentDate;
            }

           
            DateTime lastDueDate = DateTime.Now.Date.AddMonths(loanContract.TermMonths);
            int lastActualDays = (lastDueDate - lastDate).Days;

            decimal lastMonthPrincipal = loanContract.LoanAmount - totalPrincipalDistributed;

            // Tính lãi tháng cuối theo số ngày thực tế
            decimal lastMonthInterest = Math.Round(currentBalance * (loanContract.InterestRate / 365m) * lastActualDays, 0);

            schedules.Add(new LoanSchedulesDTO
            {
                ContractID = loanContract.ContractID,
                DueDate = lastDueDate,
                ExpectedPrincipal = lastMonthPrincipal,
                ExpectedInterest = lastMonthInterest,
                Status = "Pending",
                PrincipalPaid = 0,
                InterestPaid = 0,
                PenaltyAmount = 0
            });

            return schedules;
        }

        public static DateTime GetNextDueDate(string contractID)
        {
            return LoanDAL.GetNextDueDate(contractID);
        }

        public static List<LoanContractDTO> GetLoanContractsByAccountNumber(string accountNumber)
        {
            return LoanDAL.GetLoanContractsByAccountNumber(accountNumber);
        }

        public static LoanSchedulesDTO GetNextPendingSchedule(string contractID)
        {
            return LoanDAL.GetNextPendingSchedule(contractID);
        }

        public static List<LoanSchedulesDTO> GetAllSchedulesByContractId(string contractID)
        {
            return LoanDAL.GetAllSchedulesByContractId(contractID);
        }

        public static bool ProcessPayment(string contractID, decimal amountPaid, out decimal actualAmountDeducted)
        {
            actualAmountDeducted = 0;
            try
            {
                LoanContractDTO loanContract = LoanDAL.GetLoanContractByContractId(contractID);
                if (loanContract == null) {
                    return false;                       
                }
                List<LoanSchedulesDTO> loanSchedule = LoanDAL.GetUnpaidListSchedules(contractID);

                if (loanSchedule == null) {
                    return false;
                }
                decimal moneyLeft = amountPaid;
                decimal totalPrincipalCollected = 0;
                decimal totalInterestCollected = 0;
                decimal totalPenaltyCollected = 0;
                decimal penaltyRate = loanContract.InterestRate * 1.5m;

                List<LoanSchedulesDTO> schedulesToUpdate = new List<LoanSchedulesDTO>();
                bool isFutureSchedule = false;
                foreach(var session in loanSchedule)
                {
                    if (moneyLeft <= 0 || isFutureSchedule) break;

                    // Xu ly phat

                    if (session.DueDate < DateTime.Now.Date && session.Status != "Paid") {
                        int overdueDays = (DateTime.Now.Date - session.DueDate).Days;
                        decimal principalDebtUnpaid = session.ExpectedPrincipal - (session.PrincipalPaid );
                        decimal totalPenaltyAccrued = Math.Round(principalDebtUnpaid * (penaltyRate / 365m) * overdueDays, 0);
                        session.PenaltyAmount = totalPenaltyAccrued - session.PenaltyPaid;
                    }
                   
                    if (session.PenaltyAmount > 0 && moneyLeft > 0)
                    {
                        if (moneyLeft >= session.PenaltyAmount)
                        {
                            decimal penaltyToPay = session.PenaltyAmount;
                            moneyLeft -= penaltyToPay;
                            totalPenaltyCollected += penaltyToPay;
                            session.PenaltyPaid += penaltyToPay;
                            session.PenaltyAmount = 0;
                        }
                        else
                        {
                            totalPenaltyCollected += moneyLeft;
                            session.PenaltyPaid += moneyLeft;
                            session.PenaltyAmount -= moneyLeft;
                            moneyLeft = 0;
                        }
                    }
                    
                    decimal interestDebt = session.ExpectedInterest - session.InterestPaid;
                    if (interestDebt > 0 && moneyLeft > 0)
                    {
                        if (moneyLeft >= interestDebt)
                        {
                            moneyLeft -= interestDebt;
                            session.InterestPaid += interestDebt;
                            totalInterestCollected += interestDebt;
                        }
                        else
                        {
                            session.InterestPaid += moneyLeft;
                            totalInterestCollected += moneyLeft;
                            moneyLeft = 0;
                        }
                    }
                    
                    decimal principalDebt = session.ExpectedPrincipal - session.PrincipalPaid;
                    if (principalDebt > 0 && moneyLeft > 0)
                    {
                        if (moneyLeft >= principalDebt)
                        {
                            moneyLeft -= principalDebt;
                            session.PrincipalPaid += principalDebt;
                            totalPrincipalCollected += principalDebt;
                        }
                        else
                        {
                            session.PrincipalPaid += moneyLeft;
                            totalPrincipalCollected += moneyLeft;
                            moneyLeft = 0;
                        }
                    }
                    
                    if (session.PenaltyAmount == 0 && session.InterestPaid == session.ExpectedInterest && session.PrincipalPaid == session.ExpectedPrincipal)
                        session.Status = "Paid";
                    else if (session.DueDate < DateTime.Now.Date)
                        session.Status = "Overdue";
                    else
                        session.Status = "Partially Paid";

                    schedulesToUpdate.Add(session);
                    if (session.Status == "Paid" && session.DueDate >= DateTime.Now.Date)
                    {
                        isFutureSchedule = true;
                    }
                }

                // Xử lý trả nợ trước hạn và tái sinh lịch trình
                loanContract.RemainingBalance -= totalPrincipalCollected;
                decimal actualAmountUsed = amountPaid;
                List<LoanSchedulesDTO> newFutureSchedules = null;
                if (moneyLeft > 0 && loanContract.RemainingBalance > 0)
                {
                   
                    decimal prepaymentFeeRate = 0.02m;
                    decimal feeToClose = loanContract.RemainingBalance * prepaymentFeeRate;

                    
                    decimal amountNeededToClose = loanContract.RemainingBalance + feeToClose;

                    if (moneyLeft >= amountNeededToClose)
                    {
                        // TRƯỜNG HỢP 1: ĐỦ TIỀN TẤT TOÁN TOÀN BỘ (Gốc + Phí Phạt)
                        decimal excessMoney = moneyLeft - amountNeededToClose; // Coi thử có dư ko

                        totalPrincipalCollected += loanContract.RemainingBalance;
                       
                        totalPenaltyCollected += feeToClose;

                        loanContract.RemainingBalance = 0;
                        loanContract.Status = "Closed";
                        actualAmountUsed = amountPaid - excessMoney; 
                    }
                    else
                    {
                        // TRƯỜNG HỢP 2: TRẢ TRƯỚC HẠN 1 PHẦN
                        // Tính phần phạt được tính bằng 2% của sô tiène giảm 
                        decimal principalReduced = Math.Round(moneyLeft / (1 + prepaymentFeeRate), 0);
                        decimal partialFee = moneyLeft - principalReduced; // phí phạt để giảm tiền nợ

                        loanContract.RemainingBalance -= principalReduced;
                        totalPrincipalCollected += principalReduced;
                        totalPenaltyCollected += partialFee;

                        actualAmountUsed = amountPaid; 

                        // GỌI HÀM SINH LẠI LỊCH MỚI VÌ DƯ NỢ ĐÃ GIẢM
                        var futurePending = loanSchedule.Where(s => !schedulesToUpdate.Contains(s)).ToList();
                        newFutureSchedules = RegenerateSchedules(loanContract, futurePending);
                    }
                }else if (loanContract.RemainingBalance <= 0)
                {
                    actualAmountUsed = totalInterestCollected + totalPenaltyCollected + totalPrincipalCollected;
                       
                }

                if (loanContract.RemainingBalance <= 0) { loanContract.RemainingBalance = 0; loanContract.Status = "Closed"; }

                LoanRepaymentDTO history = new LoanRepaymentDTO
                {
                    ContractID = contractID,
                    PrincipalPaid = totalPrincipalCollected,
                    InterestPaid = totalInterestCollected,
                    PaymentDate = DateTime.Now,
                    PenaltyPaid = totalPenaltyCollected,
                };

                LoanDAL.SaveRepaymentWithRegeneration(loanContract, schedulesToUpdate, newFutureSchedules, history, actualAmountUsed);
                actualAmountDeducted = actualAmountUsed;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi Service khi xử lý khoản vay: " + ex.Message);

            }
        }
        private static List<LoanSchedulesDTO> RegenerateSchedules(LoanContractDTO contract, List<LoanSchedulesDTO> oldFutureSchedules)
        {
            List<LoanSchedulesDTO> newSchedules = new List<LoanSchedulesDTO>();
            int remainingMonths = oldFutureSchedules.Count;

            if (remainingMonths == 0) return newSchedules;

            decimal principalPerMonth = Math.Round(contract.RemainingBalance / remainingMonths, 0);
            decimal currentBalance = contract.RemainingBalance;
            decimal totalPrinDistributed = 0;

            DateTime lastDate = DateTime.Now.Date; // Tính ngày thực tế từ hôm nay

            for (int i = 0; i < remainingMonths; i++)
            {
                DateTime dueDate = oldFutureSchedules[i].DueDate; // Giữ nguyên ngày trả nợ của lịch cũ
                int actualDays = (dueDate - lastDate).Days;
                decimal expectedInterest = Math.Round(currentBalance * (contract.InterestRate / 365m) * actualDays, 0);

                // Tháng cuối xử lý sai số gốc
                decimal expectedPrincipal = (i == remainingMonths - 1)
                                            ? (contract.RemainingBalance - totalPrinDistributed)
                                            : principalPerMonth;

                newSchedules.Add(new LoanSchedulesDTO
                {
                    ContractID = contract.ContractID,
                    DueDate = dueDate,
                    ExpectedPrincipal = expectedPrincipal,
                    ExpectedInterest = expectedInterest,
                    Status = "Pending",
                    PrincipalPaid = 0,
                    InterestPaid = 0,
                    PenaltyAmount = 0
                });

                currentBalance -= expectedPrincipal;
                totalPrinDistributed += expectedPrincipal;
                lastDate = dueDate;
            }

            return newSchedules;
        }

        public static List<LoanRepaymentDTO> GetLoanRepaymentsByContractId(string contractId)
        {
            return LoanDAL.GetLoanRepaymentsByContractId(contractId);
        }

        public static List<LoanRepaymentDTO> GetLoanRepaymentsByAccountNumber(string accountNumber)
        {
            return LoanDAL.GetLoanRepaymentsByAccountNumber(accountNumber);
        }
        public static List<LoanRepaymentDTO> GetRepaymentsByAccountNumber(string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                return new List<LoanRepaymentDTO>();
            }

            
            return LoanDAL.GetRepaymentsByAccountNumber(accountNumber.Trim());
        }
        public static LoanSchedulesDTO GetNextPendingScheduleByAccountNumber(List<LoanContractDTO> loanContracts)
        {
            try
            {
                if (loanContracts == null || loanContracts.Count == 0)
                {
                    return null;
                }

                LoanSchedulesDTO nextSchedule = null;
                DateTime nearestDueDate = DateTime.MaxValue;

                foreach (var contract in loanContracts)
                {
                    LoanSchedulesDTO nextScheduleForContract = LoanDAL.GetNextPendingSchedule(contract.ContractID);

                    if (nextScheduleForContract != null && nextScheduleForContract.DueDate < nearestDueDate)
                    {
                        nextSchedule = nextScheduleForContract;
                        nearestDueDate = nextScheduleForContract.DueDate;
                    }
                }

                return nextSchedule;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy lịch trả nợ tiếp theo theo tài khoản: " + ex.Message);
            }
        }

        public static LoanSchedulesDTO GetNextPendingScheduleByAccountNumber(string accountNumber)
        {
            try
            {
                // Lấy tất cả hợp đồng vay của tài khoản
                List<LoanContractDTO> loanContracts = LoanDAL.GetLoanContractsByAccountNumber(accountNumber);

                if (loanContracts == null || loanContracts.Count == 0)
                {
                    return null;
                }

                // Tìm lịch trả nợ tiếp theo soonest (có ngày đến hạn gần nhất)
                LoanSchedulesDTO nextSchedule = null;
                DateTime nearestDueDate = DateTime.MaxValue;

                foreach (var contract in loanContracts)
                {
                    LoanSchedulesDTO nextScheduleForContract = LoanDAL.GetNextPendingSchedule(contract.ContractID);

                    if (nextScheduleForContract != null && nextScheduleForContract.DueDate < nearestDueDate)
                    {
                        nextSchedule = nextScheduleForContract;
                        nearestDueDate = nextScheduleForContract.DueDate;
                    }
                }

                return nextSchedule;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy lịch trả nợ tiếp theo theo tài khoản: " + ex.Message);
            }
        }

        public static LoanContractDTO GetLoanContractByContractId(string contractId)
        {
            return LoanDAL.GetLoanContractByContractId(contractId);
        }
        public static decimal CalculateSettlementAmount(decimal remainingPrincipal, decimal penaltyRate = 0.02m)
        {
            if (remainingPrincipal <= 0) return 0;

            decimal penaltyFee = remainingPrincipal * penaltyRate;
            decimal totalAmount = remainingPrincipal + penaltyFee;

            return totalAmount;
        }
       
        public static bool ProcessFullSettlement(LoanContractDTO contract, out decimal actualAmountDeducted)
        {
            actualAmountDeducted = 0;

            try
            {
                if (contract == null || contract.Status == "Closed")
                {
                   
                    return false;
                }

               
                decimal penaltyRate = 0.02m;
                decimal penaltyFee = contract.RemainingBalance * penaltyRate;

                
                decimal totalAmountToPay = CalculateSettlementAmount(contract.RemainingBalance, penaltyRate);

                
                var repaymentHistory = new LoanRepaymentDTO
                {
                    ContractID = contract.ContractID,
                    PrincipalPaid = contract.RemainingBalance, 
                    InterestPaid = 0,                          
                    PenaltyPaid = penaltyFee,                
                    PaymentDate = DateTime.Now
                };

                
                LoanDAL.SaveFullSettlement(contract, repaymentHistory, totalAmountToPay);

                actualAmountDeducted = totalAmountToPay;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tất toán hợp đồng vay: " + ex.Message);

            }
        }
    }
}

