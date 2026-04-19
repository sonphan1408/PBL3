using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BLL.Services
{
    public class FinancialService
    {
        public static List<FinancialProductDTO> GetSavingsByCustomer(int customerId)
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
        public static SavingsPreviewDTO CalculateSavingsPreview(double principalAmount, int termMonths, string savingType)
        {
            SavingsPreviewDTO result = new SavingsPreviewDTO();
            double rateValue = FinancialDAL.GetExactRateValue(savingType, termMonths);
            result.InterestRate = rateValue;
            if (rateValue == 0 || termMonths == 0) return result;
            if (savingType == "Term")
            {
                result.MaturityInterest = principalAmount * (rateValue / 100.0) / 12.0 * termMonths;
            }
            else if (savingType == "Installment")
            {

            }
            return result;
        }

    }
}
