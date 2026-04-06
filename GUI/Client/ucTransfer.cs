using System;
using System.Windows.Forms;
using BLL.Services;
using DTO.Models;

namespace GUI.Client
{
    public partial class ucTransfer : UserControl
    {
        public string CurrentUsername { get; private set; }

        private TransferService _transferService = new TransferService();

        private AccountDTO _senderAccount = null;
        private AccountDTO _recipientAccount = null;
        private decimal _transferAmount = 0;

        public ucTransfer()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        public void SetUsername(string username)
        {
            CurrentUsername = username;
            LoadSenderInfo();
        }

        private void SetupEventHandlers()
        {
            if (btnTim != null)
                btnTim.Click += BtnFind_Click;
            if (btnCK != null)
                btnCK.Click += BtnTransfer_Click;
            if (btn100 != null)
                btn100.Click += (s, e) => SelectAmount(100000);
            if (btn200 != null)
                btn200.Click += (s, e) => SelectAmount(200000);
            if (btn500 != null)
                btn500.Click += (s, e) => SelectAmount(500000);
            if (btn1000 != null)
                btn1000.Click += (s, e) => SelectAmount(1000000);
        }

        private void LoadSenderInfo()
        {
            try
            {
                _senderAccount = _transferService.GetSenderByUsername(CurrentUsername);
                if (_senderAccount != null)
                {
                    txtIDUser.Text = _senderAccount.AccountNumber;
                    txtTenUser.Text = _transferService.GetCustomerName(_senderAccount.CustomerID);
                    txtSoDu.Text = _senderAccount.Balance.ToString("N0") + " VND" ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin người gửi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIDNguoiNhan == null || string.IsNullOrWhiteSpace(txtIDNguoiNhan.Text))
                {
                    MessageBox.Show("Vui lòng nhập số tài khoản người nhận", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string accountNumber = txtIDNguoiNhan.Text.Trim();

                _recipientAccount = _transferService.GetRecipientByAccountNumber(accountNumber);

                if (_recipientAccount != null)
                {
                    txtIDNguoiNhan1.Text = _recipientAccount.AccountNumber;

                    string recipientName = _transferService.GetCustomerName(_recipientAccount.CustomerID);
                    txtTenNguoiNhan.Text = recipientName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _recipientAccount = null;
                txtIDNguoiNhan1.Text = "";
                txtTenNguoiNhan.Text = "";
            }
        }

        private void SelectAmount(decimal amount)
        {
            _transferAmount = amount;
            if (txtSoTien != null)
                txtSoTien.Text = amount.ToString("N0");
        }

        private void BtnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (_recipientAccount == null)
                {
                    MessageBox.Show("Vui lòng tìm kiếm tài khoản người nhận", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Try to get amount from user input or from selected amount
                decimal transferAmount = _transferAmount;

                // Check if user manually entered an amount in txtSoTien
                if (txtSoTien != null && !string.IsNullOrWhiteSpace(txtSoTien.Text))
                {
                    string amountText = txtSoTien.Text.Replace(",", "").Trim();
                    if (decimal.TryParse(amountText, out decimal parsedAmount))
                    {
                        transferAmount = parsedAmount;
                    }
                }

                if (transferAmount <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số tiền chuyển khoản (hoặc click một trong các nút nhanh)", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string notes = "";
                if (txtNDCK != null && !string.IsNullOrWhiteSpace(txtNDCK.Text))
                    notes = txtNDCK.Text;

                bool result = _transferService.ExecuteTransfer(CurrentUsername, _recipientAccount.AccountNumber, transferAmount, notes);

                if (result)
                {
                    MessageBox.Show("Chuyển khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadSenderInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chuyển khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            if (txtIDNguoiNhan != null) txtIDNguoiNhan.Text = "";
            if (txtSoTien != null) txtSoTien.Text = "";
            if (txtNDCK != null) txtNDCK.Text = "";
            txtIDNguoiNhan1.Text = "";
            txtTenNguoiNhan.Text = "";
            _recipientAccount = null;
            _transferAmount = 0;
        }
    }
}
