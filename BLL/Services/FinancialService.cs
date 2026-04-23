using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BLL.Services
{
    public class FinancialService
    {
        public static List<SavingContractsDTO> GetSavingsByCustomer(int customerId)
        {
            return FinancialDAL.GetSavingsByCustomer(customerId);
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
        public static SavingsPreviewDTO CalculateSavingsPreview(decimal principalAmount, int termMonths, string savingType)
        {
            SavingsPreviewDTO result = new SavingsPreviewDTO();

            decimal rateValue = FinancialDAL.GetExactRateValue(savingType, termMonths);
            result.InterestRate = rateValue;

            if (rateValue == 0 || termMonths == 0)
                return result;

            if (savingType.Equals("Term", StringComparison.OrdinalIgnoreCase))
            {
                result.MaturityInterest = principalAmount * (rateValue / 100m) / 12m * termMonths;
            }
            else if (savingType.Equals("Installment", StringComparison.OrdinalIgnoreCase))
            {
                // TODO: xử lý góp
            }

            return result;
        }
        private static string GenerateContractID()
        {
            string prefix = "TK";
            string timePart = DateTime.Now.ToString("yyMMddHHmmss");
            string miliSecond = DateTime.Now.ToString("fff");
            string newContractID = prefix + timePart + miliSecond;
            return newContractID;
        }

        private static decimal CalculateInterest(decimal principalAmount, decimal rate, int termMonths, DateTime startDate, DateTime endDate)
        {
            int day = (endDate.Date - startDate.Date).Days;
            if (day <= 0) return 0m;
            decimal interest = (principalAmount * (rate / 100m) * day) / 365m;
            return interest;
        }

        private static decimal CalculateInterestTerm(decimal principalAmount, decimal rate, int termMonths)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddMonths(termMonths);
            return CalculateInterest(principalAmount, rate, termMonths, startDate, endDate);
        }

        private static decimal CalculateInterestInstallment(decimal newPrincipalAmount, decimal rate, int termMonths, DateTime endDate)
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
            draft.Status = "Chờ xác nhận";
            draft.AccountNumber = accountNumber;

            draft.StartDate = DateTime.Now;
            draft.EndDate = draft.StartDate.AddMonths(termMonths);
            draft.AccruedInterest = CalculateInterest(principalAmount, rate, termMonths, draft.StartDate, draft.EndDate);

            return draft;
        }
    }
}
