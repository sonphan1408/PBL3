using System;
using System.Collections.Generic;
using DAL.Repositories;
using DTO.Models;

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
            return FinancialDAL.GetTotalLoans(customerId, 0);
        }
    }
}
