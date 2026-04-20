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
    }
}
