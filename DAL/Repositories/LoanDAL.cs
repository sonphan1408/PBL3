using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class LoanDAL
    {

        public static bool CreateLoanContract(LoanContractDTO loanContract)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var newContract = new LoanContract
                    {
                        ContractID = loanContract.ContractID,
                        AccountNumber = loanContract.AccountNumber,
                        LoanAmount = loanContract.LoanAmount,
                        RemainingBalance = loanContract.LoanAmount,
                        InterestRate = loanContract.InterestRate,
                        TermMonths = loanContract.TermMonths,
                        StartDate = loanContract.StartDate,
                        EndDate = loanContract.EndDate,
                        Status = "Active",
                        Collateral = loanContract.Collateral

                    };

                    db.LoanContracts.Add(newContract);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tạo hợp đồng vay: " + ex.Message);
            }


        }
        public static List<LoanSchedulesDTO> GetSchedulesByAccountNumber(string accountNumber)
        {
            using (var db = new DigitalBankingDBEntities())
            {
                // 1. Join và lấy dữ liệu thô (để tránh lỗi Entity Framework)
                var query = from s in db.LoanSchedules
                            join c in db.LoanContracts on s.ContractID equals c.ContractID
                            where c.AccountNumber == accountNumber
                            orderby s.DueDate ascending
                            select new
                            {
                                ScheduleEntity = s,
                                InterestRate = c.InterestRate
                            };

                var rawData = query.AsNoTracking().ToList();
                List<LoanSchedulesDTO> result = new List<LoanSchedulesDTO>();

                DateTime today = DateTime.Now.Date;
                int count = 1;

                // 2. Tính phạt Real-time và Map vào DTO của bạn
                foreach (var item in rawData)
                {
                    var s = item.ScheduleEntity;
                    decimal penaltyRate = item.InterestRate * 1.5m;

                    decimal principalPaid = s.PrincipalPaid ?? 0;
                    decimal interestPaid = s.InterestPaid ?? 0;
                    decimal penaltyPaid = s.PenaltyPaid ?? 0;
                    decimal currentPenalty = 0;

                    // Tính toán tiền phạt nếu quá hạn
                    if (s.DueDate < today && s.Status != "Paid")
                    {
                        int overdueDays = (today - s.DueDate).Days;
                        decimal principalDebtUnpaid = s.ExpectedPrincipal - principalPaid;

                        if (principalDebtUnpaid > 0)
                        {
                            decimal totalPenaltyAccrued = Math.Round(principalDebtUnpaid * (penaltyRate / 365m) * overdueDays, 0);
                            currentPenalty = totalPenaltyAccrued - penaltyPaid;
                            if (currentPenalty < 0) currentPenalty = 0;
                        }
                    }

                    result.Add(new LoanSchedulesDTO
                    {
                        ScheduleID = s.ScheduleID,
                        ContractID = s.ContractID,
                        DueDate = s.DueDate,
                        ExpectedPrincipal = s.ExpectedPrincipal,
                        ExpectedInterest = s.ExpectedInterest,
                        PenaltyAmount = currentPenalty,
                        PrincipalPaid = principalPaid,
                        InterestPaid = interestPaid,
                        PenaltyPaid = penaltyPaid,
                        Status = s.Status,
                        InstallmentNumber = count++
                    });
                }

                return result;
            }
        }

        public static bool CreateLoanSchedules(List<LoanSchedulesDTO> listSchedules)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    // Chuyển List DTO thành List Entity của Entity Framework
                    List<LoanSchedule> entities = new List<LoanSchedule>();

                    foreach (var dto in listSchedules)
                    {
                        entities.Add(new LoanSchedule
                        {
                            ContractID = dto.ContractID,
                            DueDate = dto.DueDate,
                            ExpectedPrincipal = dto.ExpectedPrincipal,
                            ExpectedInterest = dto.ExpectedInterest,
                            Status = dto.Status,
                            PrincipalPaid = dto.PrincipalPaid,
                            InterestPaid = dto.InterestPaid,
                            PenaltyAmount = dto.PenaltyAmount
                        });
                    }


                    db.LoanSchedules.AddRange(entities);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lưu danh sách lịch trả nợ xuống Database: " + ex.Message);
            }
        }

        public static DateTime GetNextDueDate(string contractID)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var nextSchedule = db.LoanSchedules
                        .Where(s => s.ContractID == contractID && s.Status != "Paid")
                        .OrderBy(s => s.DueDate)
                        .FirstOrDefault();

                    if (nextSchedule != null)
                    {
                        return nextSchedule.DueDate;
                    }
                    else
                    {
                        return DateTime.MinValue;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy ngày đến hạn tiếp theo: " + ex.Message);
            }
        }

        public static List<LoanContractDTO> GetLoanContractsByAccountNumber(string accountNumber)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    var loanContracts = db.LoanContracts
                        .Where(lc => lc.AccountNumber == accountNumber && lc.Status != "Closed")
                        .ToList();

                    List<LoanContractDTO> result = new List<LoanContractDTO>();
                    foreach (var contract in loanContracts)
                    {
                        result.Add(new LoanContractDTO
                        {
                            ContractID = contract.ContractID,
                            AccountNumber = contract.AccountNumber,
                            LoanAmount = contract.LoanAmount,
                            RemainingBalance = contract.RemainingBalance,
                            InterestRate = contract.InterestRate,
                            StartDate = contract.StartDate,
                            EndDate = contract.EndDate,
                            TermMonths = contract.TermMonths,
                            Collateral = contract.Collateral,
                            Status = contract.Status
                        });
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách hợp đồng vay: " + ex.Message);
            }
        }

        public static LoanSchedulesDTO GetNextPendingSchedule(string contractID)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    
                    var nextPendingSchedule = db.LoanSchedules
                        .Where(s => s.ContractID == contractID && s.Status != "Paid")
                        .OrderBy(s => s.DueDate)
                        .FirstOrDefault();

                    if (nextPendingSchedule != null)
                    {
                        
                        int currentInstallmentNumber = db.LoanSchedules
                            .Where(s => s.ContractID == contractID && s.DueDate <= nextPendingSchedule.DueDate)
                            .Count();

                       
                        var contract = db.LoanContracts.FirstOrDefault(c => c.ContractID == contractID);
                        decimal penaltyRate = contract != null ? contract.InterestRate * 1.5m : 0;

                       
                        DateTime today = DateTime.Now.Date;
                        decimal principalPaid = nextPendingSchedule.PrincipalPaid ?? 0;
                        decimal penaltyPaid = nextPendingSchedule.PenaltyPaid ?? 0;
                        decimal currentPenalty = 0;

                        
                        if (nextPendingSchedule.DueDate < today)
                        {
                            int overdueDays = (today - nextPendingSchedule.DueDate).Days;
                            decimal principalDebtUnpaid = nextPendingSchedule.ExpectedPrincipal - principalPaid;

                            if (principalDebtUnpaid > 0 && penaltyRate > 0)
                            {
                                
                                decimal totalPenaltyAccrued = Math.Round(principalDebtUnpaid * (penaltyRate / 365m) * overdueDays, 0);

                                currentPenalty = totalPenaltyAccrued - penaltyPaid;
                                if (currentPenalty < 0) currentPenalty = 0;
                            }
                        }

                        
                        return new LoanSchedulesDTO
                        {
                            ScheduleID = nextPendingSchedule.ScheduleID,
                            ContractID = nextPendingSchedule.ContractID,
                            DueDate = nextPendingSchedule.DueDate,
                            ExpectedPrincipal = nextPendingSchedule.ExpectedPrincipal,
                            ExpectedInterest = nextPendingSchedule.ExpectedInterest,
                            Status = nextPendingSchedule.Status,
                            PrincipalPaid = principalPaid,
                            InterestPaid = nextPendingSchedule.InterestPaid ?? 0,
                            PenaltyPaid = penaltyPaid,            
                            PenaltyAmount = currentPenalty,       
                            InstallmentNumber = currentInstallmentNumber
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy kỳ hạn tiếp theo: " + ex.Message);
            }
        }

        public static List<LoanSchedulesDTO> GetUnpaidListSchedules(string contractId)
        {
            using (var db = new DigitalBankingDBEntities())
            {
                return db.LoanSchedules
                 .AsNoTracking()
                 .Where(s => s.ContractID == contractId && s.Status != "Paid")
                 .OrderBy(s => s.DueDate)
                 .Select(s => new LoanSchedulesDTO
                 {
                     ScheduleID = s.ScheduleID,
                     ContractID = s.ContractID,
                     DueDate = s.DueDate,
                     ExpectedPrincipal = s.ExpectedPrincipal,
                     ExpectedInterest = s.ExpectedInterest,
                     Status = s.Status,
                     PrincipalPaid = s.PrincipalPaid.HasValue ? s.PrincipalPaid.Value : 0,
                     InterestPaid = s.InterestPaid.HasValue ? s.InterestPaid.Value : 0,
                     PenaltyAmount = s.PenaltyAmount.HasValue ? s.PenaltyAmount.Value : 0
                 })
                 .ToList();
             }
        }



        public static LoanContractDTO GetLoanContractByContractId(string contractId)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    return db.LoanContracts
                        .AsNoTracking()
                        .Where(lc => lc.ContractID == contractId)
                        .Select(lc => new LoanContractDTO
                        {
                            ContractID = lc.ContractID,
                            AccountNumber = lc.AccountNumber,
                            LoanAmount = lc.LoanAmount,
                            RemainingBalance = lc.RemainingBalance,
                            InterestRate = lc.InterestRate,
                            StartDate = lc.StartDate,
                            EndDate = lc.EndDate,
                            TermMonths = lc.TermMonths,
                            Collateral = lc.Collateral,
                            Status = lc.Status
                        })
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin hợp đồng vay: " + ex.Message);
            }
        }

        public static List<LoanSchedulesDTO> GetAllSchedulesByContractId(string contractId)
        {
            using (var db = new DigitalBankingDBEntities())
            {
                // 1. Lấy Hợp đồng để lấy Lãi suất (Dùng cho công thức tính phạt)
                var contract = db.LoanContracts.AsNoTracking().FirstOrDefault(c => c.ContractID == contractId);
                if (contract == null) return new List<LoanSchedulesDTO>();

                decimal penaltyRate = contract.InterestRate * 1.5m;
                DateTime today = DateTime.Now.Date;


                var schedulesFromDb = db.LoanSchedules
                    .AsNoTracking()
                    .Where(s => s.ContractID == contractId)
                    .OrderBy(s => s.DueDate)
                    .ToList();

                // 3. Map sang DTO và xử lý toán học
                List<LoanSchedulesDTO> result = new List<LoanSchedulesDTO>();
                int count = 1;
                foreach (var item in schedulesFromDb)
                {

                    decimal principalPaid = item.PrincipalPaid ?? 0;
                    decimal penaltyPaid = item.PenaltyPaid ?? 0;

                    decimal currentPenalty = 0;


                    if (item.DueDate < today && item.Status != "Paid")
                    {
                        int overdueDays = (today - item.DueDate).Days;
                        decimal principalDebtUnpaid = item.ExpectedPrincipal - principalPaid;

                        if (principalDebtUnpaid > 0)
                        {

                            decimal totalPenaltyAccrued = Math.Round(principalDebtUnpaid * (penaltyRate / 365m) * overdueDays, 0);


                            currentPenalty = totalPenaltyAccrued - penaltyPaid;

                            if (currentPenalty < 0) currentPenalty = 0;
                        }
                    }
                    result.Add(new LoanSchedulesDTO
                    {
                        ScheduleID = item.ScheduleID,
                        ContractID = item.ContractID,
                        DueDate = item.DueDate,
                        ExpectedPrincipal = item.ExpectedPrincipal,
                        ExpectedInterest = item.ExpectedInterest,
                        Status = item.Status,
                        PrincipalPaid = principalPaid,
                        InterestPaid = item.InterestPaid ?? 0,
                        PenaltyPaid = penaltyPaid,
                        PenaltyAmount = currentPenalty,
                        InstallmentNumber = count++
                    });



                }
                return result;
            }
        }
        
        public static void InsertRepaymentHistory(string contractId,
                                           decimal principal,
                                           decimal interest,
                                           decimal penalty)
        {
            using (var db = new DigitalBankingDBEntities())
            {
                db.LoanRepayments.Add(new LoanRepayment
                {
                    ContractID = contractId,
                    PrincipalPaid = principal,
                    InterestPaid = interest,
                    // Nếu có cột PenaltyPaid thì thêm:
                    // PenaltyPaid = penalty,
                    PaymentDate = DateTime.Now
                });

                db.SaveChanges();
            }
        }
        public static List<LoanRepaymentDTO> GetLoanRepaymentsByContractId(string contractId)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    return db.LoanRepayments
                        .AsNoTracking()
                        .Where(r => r.ContractID == contractId)
                        .OrderByDescending(r => r.PaymentDate)
                        .Select(r => new LoanRepaymentDTO
                        {
                            RepaymentID = r.RepaymentID,
                            ContractID = r.ContractID,
                            PrincipalPaid = r.PrincipalPaid ?? 0m,
                            InterestPaid = r.InterestPaid ?? 0m,
                            PenaltyPaid = r.PenaltyPaid ?? 0m,
                            PaymentDate = r.PaymentDate.HasValue ? r.PaymentDate.Value : DateTime.MinValue
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách lịch sử thanh toán: " + ex.Message);
            }
        }

        public static List<LoanRepaymentDTO> GetLoanRepaymentsByAccountNumber(string accountNumber)
        {
            try
            {
                using (var db = new DigitalBankingDBEntities())
                {
                    return db.LoanRepayments
                        .AsNoTracking()
                        .Where(r => db.LoanContracts.Any(c => c.AccountNumber == accountNumber && c.ContractID == r.ContractID))
                        .OrderBy(r => r.PaymentDate)
                        .Select(r => new LoanRepaymentDTO
                        {
                            RepaymentID = r.RepaymentID,
                            ContractID = r.ContractID,
                            PrincipalPaid = r.PrincipalPaid ?? 0m,
                            InterestPaid = r.InterestPaid ?? 0m,
                            PenaltyPaid = r.PenaltyPaid ?? 0m,
                            PaymentDate = r.PaymentDate.HasValue ? r.PaymentDate.Value : DateTime.MinValue
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách lịch sử thanh toán theo tài khoản: " + ex.Message);
            }
        }

        public static void SaveRepaymentWithRegeneration(
     LoanContractDTO contractDTO,
     List<LoanSchedulesDTO> schedulesToUpdateDTO,
     List<LoanSchedulesDTO> newFutureSchedulesDTO,
     LoanRepaymentDTO historyDTO,
     decimal actualAmountUsed)
        {
            using (var db = new DigitalBankingDBEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // ==========================================
                        // 1. CẬP NHẬT HỢP ĐỒNG
                        // ==========================================
                        // Kéo hợp đồng thật từ DB lên (nó sẽ tự động được EF theo dõi)
                        var existingContract = db.LoanContracts.Find(contractDTO.ContractID);
                        if (existingContract != null)
                        {
                            // Chỉ cập nhật những cột bị thay đổi (Dư nợ và Trạng thái)
                            existingContract.RemainingBalance = contractDTO.RemainingBalance;
                            existingContract.Status = contractDTO.Status;
                        }

                        // ==========================================
                        // 2. CẬP NHẬT CÁC KỲ HẠN VỪA THANH TOÁN
                        // ==========================================
                        foreach (var dto in schedulesToUpdateDTO)
                        {
                            // Lấy ra kỳ hạn bằng ID (Giả sử DTO của bạn có thuộc tính ScheduleID)
                            var existingSchedule = db.LoanSchedules.Find(dto.ScheduleID);
                            if (existingSchedule != null)
                            {
                                // Gán đè các số tiền vừa được BLL tính toán xong
                                existingSchedule.Status = dto.Status;
                                existingSchedule.PrincipalPaid = dto.PrincipalPaid;
                                existingSchedule.InterestPaid = dto.InterestPaid;
                                existingSchedule.PenaltyAmount = dto.PenaltyAmount;
                                existingSchedule.PenaltyPaid = dto.PenaltyPaid;
                            }
                        }

                        // ==========================================
                        // 3. TÁI SINH LỊCH TRÌNH (TRẢ TRƯỚC HẠN)
                        // ==========================================
                        if (newFutureSchedulesDTO != null && newFutureSchedulesDTO.Count > 0)
                        {
                            // Xóa lịch cũ
                            var oldFutureSchedules = db.LoanSchedules
                                                       .Where(s => s.ContractID == contractDTO.ContractID && s.Status == "Pending")
                                                       .ToList();
                            db.LoanSchedules.RemoveRange(oldFutureSchedules);

                            // Thêm lịch mới (Map từ DTO sang Entity mới)
                            List<LoanSchedule> newEntities = new List<LoanSchedule>();
                            foreach (var dto in newFutureSchedulesDTO)
                            {
                                newEntities.Add(new LoanSchedule
                                {
                                    ContractID = dto.ContractID,
                                    DueDate = dto.DueDate,
                                    ExpectedPrincipal = dto.ExpectedPrincipal,
                                    ExpectedInterest = dto.ExpectedInterest,
                                    Status = dto.Status,
                                    PrincipalPaid = dto.PrincipalPaid,
                                    InterestPaid = dto.InterestPaid,
                                    PenaltyAmount = dto.PenaltyAmount
                                });
                            }
                            db.LoanSchedules.AddRange(newEntities);
                        }

                        // ==========================================
                        // 4. LƯU LỊCH SỬ NỘP TIỀN
                        // ==========================================
                        // Map từ DTO sang Entity Lịch sử mới
                        db.LoanRepayments.Add(new LoanRepayment
                        {
                            ContractID = historyDTO.ContractID,
                            PrincipalPaid = historyDTO.PrincipalPaid,
                            InterestPaid = historyDTO.InterestPaid,
                            PaymentDate = historyDTO.PaymentDate,
                            PenaltyPaid = historyDTO.PenaltyPaid
                            // Nếu bảng của bạn có cột PenaltyPaid thì nhớ map thêm vào đây nhé
                        });

                        // ==========================================
                        // 5. TRỪ TIỀN TRONG THẺ CỦA KHÁCH
                        // ==========================================
                        var account = db.Accounts.Find(contractDTO.AccountNumber);
                        if (account != null)
                        {
                            account.Balance -= actualAmountUsed;
                        }

                        // ==========================================
                        // 6. CHỐT SỔ VÀ LƯU VÀO DATABASE
                        // ==========================================
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Lỗi Database khi gạch nợ: " + ex.Message);
                    }
                }
            }
        }
        public static void SaveFullSettlement(
    LoanContractDTO contractDTO,
    LoanRepaymentDTO historyDTO,
    decimal totalAmountToDeduct)
        {
            using (var db = new DigitalBankingDBEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        
                        var existingContract = db.LoanContracts.Find(contractDTO.ContractID);
                        if (existingContract != null)
                        {
                            existingContract.RemainingBalance = 0;
                            existingContract.Status = "Closed";
                        }

                       
                        // 2. XÓA SẠCH LỊCH TRÌNH TƯƠNG LAI
                       
                        // Lấy ra tất cả các kỳ hạn chưa đóng của hợp đồng này
                        var pendingSchedules = db.LoanSchedules
                                                 .Where(s => s.ContractID == contractDTO.ContractID && s.Status == "Pending")
                                                 .ToList();

                        // Xóa chúng khỏi Database (vì khách đã trả hết nợ rồi, không cần đòi nữa)
                        if (pendingSchedules.Count > 0)
                        {
                            db.LoanSchedules.RemoveRange(pendingSchedules);
                        }

                        
                        db.LoanRepayments.Add(new LoanRepayment
                        {
                            ContractID = historyDTO.ContractID,
                            PrincipalPaid = historyDTO.PrincipalPaid,
                            InterestPaid = historyDTO.InterestPaid,
                            PenaltyPaid = historyDTO.PenaltyPaid,
                            PaymentDate = historyDTO.PaymentDate
                        });

                       
                        var account = db.Accounts.Find(contractDTO.AccountNumber);
                        if (account != null)
                        {
                            account.Balance -= totalAmountToDeduct;
                        }

                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Lỗi Database khi tất toán: " + ex.Message);
                    }
                }
            }
        }
        public static List<LoanRepaymentDTO> GetRepaymentsByAccountNumber(string accountNumber)
        {
            using (var db = new DigitalBankingDBEntities())
            {
                var query = from r in db.LoanRepayments
                             join c in db.LoanContracts on r.ContractID equals c.ContractID
                             where c.AccountNumber == accountNumber
                             orderby r.PaymentDate descending 
                             select new LoanRepaymentDTO
                             {
                                 RepaymentID = r.RepaymentID,
                                 ContractID = r.ContractID,
                                 PrincipalPaid = r.PrincipalPaid ?? 0m,
                                 InterestPaid = r.InterestPaid ?? 0m,
                                 PenaltyPaid = r.PenaltyPaid ?? 0m,
                                 PaymentDate = r.PaymentDate ?? DateTime.MinValue
                             };

                return query.AsNoTracking().ToList();
            }
        }

    }
}
