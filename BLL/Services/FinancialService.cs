using DAL;
using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Windows.Forms;
using System.Linq;


namespace BLL.Services
{
    public class FinancialService
    {
        //public static List<SavingContractsDTO> GetSavingsByCustomer(int customerId)
        //{
        //    return FinancialDAL.GetSavingsByCustomer(customerId);
        //}

        public static List<SavingContractsDTO> GetSavingContractsByAccountNumber(string accountNumber)
        {
            return FinancialDAL.GetSavingsByAccountNumber(accountNumber);
        }

        public static decimal GetTotalSavings(int customerId)
        {
            return FinancialDAL.GetTotalSavings(customerId);
        }

        public static decimal GetTotalLoans(int customerId)
        {
            return FinancialDAL.GetTotalLoans(customerId);
        }

        public static int GetTotalSavingsAccounts(int customerId)
        {
            return FinancialDAL.GetTotalSavingsAccounts(customerId);
        }

        public static int GetTotalLoansCount(int customerId)
        {
            return FinancialDAL.GetTotalLoanAccounts(customerId);
        }
        public static List<InterestRateDTO> GetRatesByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                throw new Exception("Loại sản phẩm không được để trống!");
            }


            return FinancialDAL.GetInterestRatesByCategory(category);
        }
        //public static SavingsPreviewDTO CalculateSavingsPreview(decimal principalAmount, int termMonths, string savingType)
        //{
        //    SavingsPreviewDTO result = new SavingsPreviewDTO();

        //    decimal rateValue = FinancialDAL.GetExactRateValue(savingType, termMonths);
        //    result.InterestRate = rateValue;

        //    if (rateValue == 0 || termMonths == 0)
        //        return result;

        //    if (savingType.Equals("Term", StringComparison.OrdinalIgnoreCase))
        //    {
        //        result.MaturityInterest = principalAmount * (rateValue / 100m) / 12m * termMonths;
        //    }
        //    else if (savingType.Equals("Installment", StringComparison.OrdinalIgnoreCase))
        //    {
        //        // TODO: xử lý góp
        //    }

        //    return result;
        //}
        private static string GenerateContractID()
        {
            string prefix = "TK";
            string timePart = DateTime.Now.ToString("yyMMddHHmmss");
            string miliSecond = DateTime.Now.ToString("fff");
            string newContractID = prefix + timePart + miliSecond;
            return newContractID;
        }

        public static decimal CalculateInterest(decimal principalAmount, decimal rate, int termMonths, DateTime startDate, DateTime endDate)
        {
            int day = (endDate.Date - startDate.Date).Days;
            if (day <= 0) return 0m;
            decimal interest = (principalAmount * (rate / 100m) * day) / 365m;
            return interest;
        }

        public static decimal CalculateInterestTerm(decimal principalAmount, decimal rate, int termMonths)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddMonths(termMonths);
            return CalculateInterest(principalAmount, rate, termMonths, startDate, endDate);
        }

        public static decimal CalculateInterestInstallment(decimal newPrincipalAmount, decimal rate, int termMonths, DateTime endDate)
        {
            DateTime updateDate = DateTime.Now;
            decimal newInterest = CalculateInterest(newPrincipalAmount, rate, termMonths, updateDate, endDate);
            return newInterest;
        }

        public static SavingContractsDTO CreateSavingDraft(decimal principalAmount, int termMonths, string savingType, string goal, decimal rate, string accountNumber)
        {
            SavingContractsDTO draft = new SavingContractsDTO();
            draft.ContractID = GenerateContractID();
            draft.TermMonths = termMonths;
            draft.PrincipalAmount = principalAmount;
            draft.SavingType = savingType;
            draft.Goal = goal;
            draft.CurrentBalance = 0;
            draft.InterestRate = rate;
            draft.Status = "Awaiting confirmation";
            draft.AccountNumber = accountNumber;

            draft.StartDate = DateTime.Now;
            draft.EndDate = draft.StartDate.AddMonths(termMonths);
            draft.AccruedInterest = CalculateInterest(principalAmount, rate, termMonths, draft.StartDate, draft.EndDate);

            return draft;
        }

        public static bool CreateSavingAccount(SavingContractsDTO savingContract)
        {
            bool deducted = false;
            string accountNumber = savingContract.AccountNumber;
            try
            {


                // Lấy số dư tài khoản hiện tại
                decimal currentBalance = AccountService.GetAccountBalance(accountNumber);

                // Kiểm tra xem có đủ tiền không
                if (currentBalance < savingContract.PrincipalAmount)
                {
                    throw new Exception("Tài khoản không đủ tiền để tạo tiết kiệm! Số tiền cần: " + savingContract.PrincipalAmount.ToString("N0") + ", Số dư: " + currentBalance.ToString("N0"));
                }

                // Trừ tiền từ tài khoản
                deducted = AccountService.DeductAccountBalance(accountNumber, savingContract.PrincipalAmount);

                if (!deducted)
                {
                    throw new Exception("Lỗi khi trừ tiền từ tài khoản!");
                }

                // Cập nhật status thành "Active" và balance của saving
                savingContract.Status = "Active";
                savingContract.CurrentBalance = savingContract.PrincipalAmount;

                // Lưu tiết kiệm vào database
                bool saved = FinancialDAL.CreateSavingAccount(savingContract);


                if (!saved)
                {


                    throw new Exception("Lỗi khi tạo tài khoản tiết kiệm!");
                }


                // Tạo ghi chép SavingTransaction
                FinancialDAL.CreateSavingTransaction(savingContract.ContractID, "Opening", savingContract.PrincipalAmount, "Mở tài khoản tiết kiệm");

                return true;
            }
            catch (Exception ex)

            {
                if (deducted)
                {
                    AccountService.AddAccountBalance(accountNumber, savingContract.PrincipalAmount);
                }
                string detailError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                throw new Exception("Lỗi hệ thống: " + detailError);
            }
        }

        public static bool CheckPassword(string accountNumber, string inputPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(accountNumber))
                {
                    throw new Exception("Số tài khoản không được để trống!");
                }

                if (string.IsNullOrWhiteSpace(inputPassword))
                {
                    throw new Exception("Mật khẩu không được để trống!");
                }


                string databasePassword = AccountService.GetPasswordByAccountNumber(accountNumber);

                if (string.IsNullOrWhiteSpace(databasePassword))
                {
                    throw new Exception("Không tìm thấy tài khoản!");
                }


                return inputPassword == databasePassword;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra mật khẩu: " + ex.Message);
            }
        }
        public static List<SavingTransactionDTO> GetSavingTransactions(string contractId, DateTime fromDate, DateTime toDate)
        {
            return FinancialDAL.GetSavingTransactions(contractId, fromDate, toDate);
        }
        public static bool UpdateFinalSettlement(string contractId, decimal finalAmount, decimal accruedInterest, DateTime endDate)
        {
            return FinancialDAL.UpdateFinalSettlement(contractId, finalAmount, accruedInterest, endDate);
        }
        public static bool FinalSettlement(string accountNumber, SavingContractsDTO savingContract, decimal newAccruedInterest, decimal finalAmount)
        {
            try
            {
                DateTime curDate = DateTime.Now;
                if (curDate < savingContract.EndDate)
                {

                    bool isUpdate = UpdateFinalSettlement(savingContract.ContractID, finalAmount, newAccruedInterest, curDate);
                    if (!isUpdate)
                    {
                        throw new Exception("Lỗi khi tất toán!");


                    }

                    bool isAddBalance = AccountService.AddAccountBalance(accountNumber, finalAmount);
                    if (!isAddBalance)
                    {
                        throw new Exception("Lỗi khi tất toán!");
                    }
                    FinancialDAL.CreateSavingTransaction(savingContract.ContractID, "Closed", finalAmount, "Tất toán tài khoản tiết kiệm");


                }
                return true;
            }
            catch (Exception ex)
            {
                string detailError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                throw new Exception("Lỗi hệ thống: " + detailError);
            }





        }



        public static bool Deposit(string accountNumber, string contractId, decimal newInterest, decimal depositAmount)
        {
            try
            {
                // 🌟 BẬT TÍNH NĂNG BẢO VỆ GIAO DỊCH (TRANSACTION)
                using (TransactionScope scope = new TransactionScope())
                {
                    // Bước 1: Trừ tiền tài khoản chính
                    bool deducted = AccountService.DeductAccountBalance(accountNumber, depositAmount);
                    if (!deducted)
                    {
                        throw new Exception("Lỗi trừ tiền tài khoản (Có thể số dư không đủ).");
                    }

                    // Bước 2: Cộng tiền và cập nhật lãi vào sổ
                    bool isDeposit = FinancialDAL.UpdateDeposit(contractId, depositAmount, newInterest);
                    if (!isDeposit)
                    {
                        throw new Exception("Lỗi khi cập nhật tiền vào sổ tiết kiệm!");
                    }

                    // Bước 3: Ghi nhận lịch sử giao dịch
                    FinancialDAL.CreateSavingTransaction(contractId, "Deposit", depositAmount, "Gửi thêm vào tài khoản tiết kiệm");

                    // 🌟 CHỐT HẠ: Lệnh này báo cho SQL Server biết "Mọi thứ đã an toàn, hãy lưu thật vào DB đi"
                    scope.Complete();

                    return true;
                }
            }
            catch (Exception ex)
            {
                // BẠN KHÔNG CẦN CODE HOÀN TIỀN THỦ CÔNG NỮA!
                // Nếu lỗi xảy ra, dòng 'scope.Complete()' chưa được gọi. 
                // SQL Server sẽ tự động Rollback (trả lại tiền y như cũ) 100% an toàn kể cả khi cúp điện.

                string detailError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                throw new Exception("Lỗi hệ thống: " + detailError);
            }
        }
        public static List<StatisticSavingTypesDTO> GroupBySavingTypes(List<SavingContractsDTO> data)
        {
            List<StatisticSavingTypesDTO> typeStats = data.GroupBy(s => s.SavingType)
         .Select(g => new StatisticSavingTypesDTO
         {
             // Cú pháp: Nếu là Installment -> Gửi góp. Nếu Term -> Kỳ hạn. Còn lại -> Lấy tên gốc
             Name = g.Key == "Installment" ? "Gửi góp" :
                    g.Key == "Term" ? "Kỳ hạn" :
                    (g.Key ?? "Khác"),

             Total = g.Sum(s => s.CurrentBalance)
         })
         .ToList();
            return typeStats;

        }

    }
}
