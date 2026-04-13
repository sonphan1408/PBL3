using System;
using System.Collections.Generic;
using DAL.Repositories;
using DTO.Models;

namespace BLL.Services
{
    public class TransactionService
    {
        public static List<TransactionDTO> GetTransactionsByAccount(string accountNumber, int limit = 10)
        {
            return TransactionDAL.GetTransactionsByAccount(accountNumber, limit);
        }

        public static decimal GetTotalIncome(string accountNumber)
        {
            return TransactionDAL.GetTotalIncome(accountNumber);
        }

        public static decimal GetTotalExpense(string accountNumber)
        {
            return TransactionDAL.GetTotalExpense(accountNumber);
        }
    }
}
