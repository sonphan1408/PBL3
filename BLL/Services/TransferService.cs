using System;
using System.Collections.Generic;
using DTO.Models;
using DAL.Repositories;

namespace BLL.Services
{
    public class TransferService
    {
        private TransferDAL _transferDAL = new TransferDAL();
        private const decimal MIN_TRANSFER_AMOUNT = 2000m;  // 2,000 VND
        private const decimal MAX_TRANSFER_AMOUNT = 10000000m;  // 10,000,000 VND

        public AccountCustomerDTO GetRecipientByAccountNumber(string accountNumber)
        {
            var account = _transferDAL.GetAccountByAccountNumber(accountNumber);
            if (account == null)
                throw new Exception($"Không tìm thấy tài khoản người nhận: {accountNumber}");

            if (account.Status != "Active")
                throw new Exception($"Tài khoản {accountNumber} có trạng thái '{account.Status}', không thể chuyển khoản. Tài khoản cần có trạng thái 'Active'.");

            return account;
        }

        public AccountCustomerDTO GetSenderByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("Vui lòng nhập tên đăng nhập.");

            var account = _transferDAL.GetAccountByUsername(username);
            if (account == null)
                throw new Exception("Không tìm thấy tài khoản người gửi.");

            if (account.Status != "Active")
                throw new Exception("Tài khoản người gửi không hoạt động.");

            return account;
        }

        public string GetCustomerName(int customerID)
        {
            try
            {
                return _transferDAL.GetCustomerNameByID(customerID);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin khách hàng: " + ex.Message);
            }
        }

        public string GetExternalAccountName(string accountNumber, string bankCode)
        {
            try
            {
                return _transferDAL.GetExternalAccountName(accountNumber, bankCode);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin tài khoản: " + ex.Message);
            }
        }

        private void ValidateTransferAmount(decimal amount)
        {
            if (amount <= 0)
                throw new Exception("Số tiền chuyển khoản phải lớn hơn 0.");

            if (amount < MIN_TRANSFER_AMOUNT)
                throw new Exception($"Số tiền chuyển khoản tối thiểu là {MIN_TRANSFER_AMOUNT:N0} VND.");

            if (amount > MAX_TRANSFER_AMOUNT)
                throw new Exception($"Số tiền chuyển khoản tối đa là {MAX_TRANSFER_AMOUNT:N0} VND.");
        }

        private void ValidateSufficientBalance(decimal balance, decimal amount)
        {
            if (balance < amount)
                throw new Exception($"Số dư tài khoản không đủ. Số dư hiện tại: {balance:N0} VND");
        }

        private void ValidateDifferentAccounts(string senderAccountNumber, string recipientAccountNumber)
        {
            if (senderAccountNumber == recipientAccountNumber)
                throw new Exception("Không thể chuyển khoản cho chính mình.");
        }

        public bool ExecuteTransfer(string senderUsername, string recipientAccountNumber, decimal amount, string notes = "")
        {
            try
            {
                // Default to HTTS Bank (internal transfer)
                return ExecuteTransfer(senderUsername, recipientAccountNumber, amount, notes, "HTTS");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi chuyển khoản: " + ex.Message);
            }
        }

        public bool ExecuteTransfer(string senderUsername, string recipientAccountNumber, decimal amount, string notes, string bankCode)
        {
            try
            {
                AccountCustomerDTO senderAccount = GetSenderByUsername(senderUsername);

                AccountCustomerDTO recipientAccount;
                if (bankCode == "HTTS")
                {
                    // Nội bộ
                    recipientAccount = GetRecipientByAccountNumber(recipientAccountNumber);
                }
                else
                {
                    // LNH
                    recipientAccount = GetRecipientByAccountNumberAndBank(recipientAccountNumber, bankCode);
                }

                ValidateTransferAmount(amount);

                ValidateSufficientBalance(senderAccount.Balance, amount);

                if (bankCode == "HTTS")
                {
                    ValidateDifferentAccounts(senderAccount.AccountNumber, recipientAccount.AccountNumber);
                }

                return _transferDAL.ExecuteTransfer(senderAccount.AccountNumber, recipientAccount.AccountNumber, amount, notes, bankCode);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi chuyển khoản: " + ex.Message);
            }
        }

        public decimal GetAvailableBalance(string username)
        {
            try
            {
                AccountCustomerDTO account = GetSenderByUsername(username);
                return account.Balance;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy số dư: " + ex.Message);
            }
        }

        public List<ExternalBankDTO> GetAllExternalBanks()
        {
            try
            {
                return _transferDAL.GetAllExternalBanks();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách ngân hàng: " + ex.Message);
            }
        }

        public AccountCustomerDTO GetRecipientByAccountNumberAndBank(string accountNumber, string bankCode)
        {
            var account = _transferDAL.GetRecipientByAccountNumberAndBank(accountNumber, bankCode);
            if (account == null)
                throw new Exception("Không tìm thấy tài khoản người nhận.");

            if (account.Status != "Active")
                throw new Exception("Tài khoản người nhận không hoạt động.");

            return account;
        }
    }
}
