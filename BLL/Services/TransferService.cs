using System;
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
            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new Exception("Vui lòng nhập số tài khoản người nhận.");

            var account = _transferDAL.GetAccountByAccountNumber(accountNumber);
            if (account == null)
                throw new Exception("Không tìm thấy tài khoản người nhận.");

            if (account.Status != "Active")
                throw new Exception("Tài khoản người nhận không hoạt động.");

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
                // 1. Get sender account
                AccountCustomerDTO senderAccount = GetSenderByUsername(senderUsername);

                // 2. Get recipient account
                AccountCustomerDTO recipientAccount = GetRecipientByAccountNumber(recipientAccountNumber);

                // 3. Validate transfer amount
                ValidateTransferAmount(amount);

                // 4. Validate sufficient balance
                ValidateSufficientBalance(senderAccount.Balance, amount);

                // 5. Validate different accounts
                ValidateDifferentAccounts(senderAccount.AccountNumber, recipientAccount.AccountNumber);

                // 6. Execute transfer in DAL
                return _transferDAL.ExecuteTransfer(senderAccount.AccountNumber, recipientAccount.AccountNumber, amount, notes);
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
    }
}
