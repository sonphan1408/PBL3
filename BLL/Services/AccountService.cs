using System;
using System.Collections.Generic;
using DAL.Repositories;
using DTO.Models;

namespace BLL.Services
{
    public class AccountService
    {
        public static AccountCustomerDTO GetAccountByUsername(string username)
        {
            return AccountDAL.GetAccountByUsername(username);
        }

        public static CustomerDTO GetCustomerInfo(int customerId)
        {
            return AccountDAL.GetCustomerInfo(customerId);
        }

        public static List<AccountCustomerDTO> GetAccountsByCustomer(int customerId)
        {
            return AccountDAL.GetAccountsByCustomer(customerId);
        }

        public static string GetPasswordByAccountNumber(string accountNumber)
        {
            return AccountDAL.GetPasswordByAccountNumber(accountNumber);
        }

        public static decimal GetAccountBalance(string accountNumber)
        {
            return AccountDAL.GetAccountBalance(accountNumber);
        }

        public static bool DeductAccountBalance(string accountNumber, decimal amount)
        {
            return AccountDAL.DeductAccountBalance(accountNumber, amount);
        }

        public static bool AddAccountBalance(string accountNumber, decimal amount)
        {
            return AccountDAL.AddAccountBalance(accountNumber, amount);
        }
    }
}
