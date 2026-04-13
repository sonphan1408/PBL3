using System;
using System.Collections.Generic;
using DAL.Repositories;
using DTO.Models;

namespace BLL.Services
{
    public class AccountService
    {
        public static AccountDTO GetAccountByUsername(string username)
        {
            return AccountDAL.GetAccountByUsername(username);
        }

        public static CustomerDTO GetCustomerInfo(int customerId)
        {
            return AccountDAL.GetCustomerInfo(customerId);
        }

        public static List<AccountDTO> GetAccountsByCustomer(int customerId)
        {
            return AccountDAL.GetAccountsByCustomer(customerId);
        }
    }
}
