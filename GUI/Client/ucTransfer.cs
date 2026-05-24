using System;
using System.Windows.Forms;
using BLL.Services;
using DTO.Models;
using GUI.Session;
using GUI;   // ToastNotification
using Krypton.Toolkit;

namespace GUI.Client
{
    public partial class ucTransfer : UserControl
    {
        private TransferService _transferService = new TransferService();
        private ucSelectBank _ucSelectBank = null;

        private AccountCustomerDTO _senderAccount = null;
        private AccountCustomerDTO _recipientAccount = null;
        private decimal _transferAmount = 0;
        private ExternalBankDTO _selectedBank = null;

        public ucTransfer()
        {
            InitializeComponent();
            SetupEventHandlers();
            LoadSenderInfo();
        }

        private void InitializeBankSelector()
        {
            // Create ucSelectBank on-demand when needed
            if (_ucSelectBank == null)
            {
                _ucSelectBank = new ucSelectBank();
                _ucSelectBank.Location = new System.Drawing.Point(94, 334);
                // Size to fit content properly without excessive white space
                _ucSelectBank.Size = new System.Drawing.Size(350, 280);
                _ucSelectBank.BankSelected += (s, e) =>
                {
                    _selectedBank = _ucSelectBank.SelectedBank;
                    if (lblNganHang != null)
                        lblNganHang.Text = _selectedBank.BankName;
                    // Clear recipient when bank changes
                    if (txtTenNguoiNhan != null)
                        txtTenNguoiNhan.Text = "";
                    _recipientAccount = null;

                    // Remove and dispose the selector after selection
                    if (this.Controls.Contains(_ucSelectBank))
                    {
                        this.Controls.Remove(_ucSelectBank);
                        _ucSelectBank.Dispose();
                        _ucSelectBank = null;
                    }

                    // Refresh the form to clean up any remaining artifacts
                    this.Refresh();
                };
            }
        }

        private void ShowBankSelector()
        {
            InitializeBankSelector();
            if (_ucSelectBank != null)
            {
                // Position ucSelectBank below lblNganHang
                if (lblNganHang != null)
                {
                    _ucSelectBank.Location = new System.Drawing.Point(
                        lblNganHang.Location.X,
                        lblNganHang.Location.Y + lblNganHang.Height - 70
                    );
                }

                if (!this.Controls.Contains(_ucSelectBank))
                {
                    this.Controls.Add(_ucSelectBank);
                    _ucSelectBank.BringToFront();
                }
            }
        }

        private void SetupEventHandlers()
        {
            if (btnTim != null)
                btnTim.Click += BtnFind_Click;
            if (btnCK != null)
                btnCK.Click += BtnTransfer_Click;
            if (btnSelectBank != null)
                btnSelectBank.Click += btnSelectBank_Click;
        }

        private void btnSelectBank_Click(object sender, EventArgs e)
        {
            ShowBankSelector();
        }

        private void LoadSenderInfo()
        {
            try
            {
                _senderAccount = _transferService.GetSenderByUsername(UserSession.CurrentUser.Username);
                if (_senderAccount != null)
                {
                    if (txtIDUser != null)
                        txtIDUser.Text = _senderAccount.AccountNumber;
                    if (txtSoDu != null)
                        txtSoDu.Text = _senderAccount.Balance.ToString("N0") + " VND";
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
                if (_selectedBank == null)
                {
                    MessageBox.Show("Vui lòng chọn ngân hàng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtIDNguoiNhan == null || string.IsNullOrWhiteSpace(txtIDNguoiNhan.Text))
                {
                    MessageBox.Show("Vui lòng nhập số tài khoản người nhận", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string accountNumber = txtIDNguoiNhan.Text.Trim();

                // Determine if it's internal (HTTS Bank) or external transfer
                bool isInternalTransfer = _selectedBank.BankCode == "HTTS";

                try
                {
                    if (isInternalTransfer)
                    {
                        // Internal transfer - search only in internal accounts
                        _recipientAccount = _transferService.GetRecipientByAccountNumber(accountNumber);
                    }
                    else
                    {
                        // External transfer - search in external bank
                        _recipientAccount = _transferService.GetRecipientByAccountNumberAndBank(accountNumber, _selectedBank.BankCode);
                    }

                    if (_recipientAccount != null)
                    {
                        string recipientName = "";

                        if (isInternalTransfer)
                        {
                            // For internal transfer, get name from Customer table
                            recipientName = _transferService.GetCustomerName(_recipientAccount.CustomerID);
                        }
                        else
                        {
                            // For external transfer, get name from Mock_Napas_Accounts
                            recipientName = _transferService.GetExternalAccountName(accountNumber, _selectedBank.BankCode);
                        }

                        if (txtTenNguoiNhan != null)
                            txtTenNguoiNhan.Text = recipientName ?? "Người nhận";
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (txtTenNguoiNhan != null)
                            txtTenNguoiNhan.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không tìm thấy tài khoản: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _recipientAccount = null;
                    if (txtTenNguoiNhan != null)
                        txtTenNguoiNhan.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _recipientAccount = null;
                if (txtTenNguoiNhan != null)
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
                decimal transferAmount = 0;

                // Check if user manually entered an amount in txtSoTien
                if (txtSoTien != null && !string.IsNullOrWhiteSpace(txtSoTien.Text))
                {
                    string amountText = txtSoTien.Text.Replace(",", "").Replace(".", "").Trim();
                    if (decimal.TryParse(amountText, out decimal parsedAmount))
                    {
                        transferAmount = parsedAmount;
                    }
                }
                else if (_transferAmount > 0)
                {
                    transferAmount = _transferAmount;
                }

                if (transferAmount <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số tiền chuyển khoản (hoặc click một trong các nút nhanh)", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate sender account balance
                if (_senderAccount == null || _senderAccount.Balance < transferAmount)
                {
                    MessageBox.Show("Số dư tài khoản không đủ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string notes = "";
                if (txtNDCK != null && !string.IsNullOrWhiteSpace(txtNDCK.Text))
                    notes = txtNDCK.Text;

                // Get bankCode from selected bank
                string bankCode = _selectedBank?.BankCode ?? "HTTS";

                // Execute transfer with bankCode
                bool result = _transferService.ExecuteTransfer(UserSession.CurrentUser.Username, _recipientAccount.AccountNumber, transferAmount, notes, bankCode);

                if (result)
                {
                    string senderName = _transferService.GetCustomerName(_senderAccount.CustomerID);

                    // Get recipient name based on transfer type
                    string recipientName = "";
                    bool isInternalTransfer = bankCode == "HTTS";

                    if (isInternalTransfer)
                    {
                        // For internal transfer, get name from Customer table
                        recipientName = _transferService.GetCustomerName(_recipientAccount.CustomerID);
                    }
                    else
                    {
                        // For external transfer, get name from Mock_Napas_Accounts
                        recipientName = _transferService.GetExternalAccountName(_recipientAccount.AccountNumber, bankCode);
                    }

                    // ✅ Hiển thị Toast Notification
                    ToastNotification.ShowTransfer(recipientName, _recipientAccount.AccountNumber, transferAmount);

                    // Trigger notification with structured data
                    var notificationData = new NotificationMessageDTO
                    {
                        OperationType = "transfer",
                        NotificationType = "transaction",
                        RecipientName = recipientName,
                        RecipientAccount = _recipientAccount.AccountNumber,
                        TransferAmount = transferAmount
                    };
                    UserSession.RaiseNotification(notificationData);

                    // Update balance in session
                    UserSession.UpdateBalance(transferAmount);

                    frmBill bill = new frmBill(
                        amount: transferAmount,
                        senderAccount: _senderAccount.AccountNumber,
                        senderName: senderName,
                        recipientAccount: _recipientAccount.AccountNumber,
                        recipientName: recipientName,
                        notes: notes
                    );

                    bill.FormClosed += (s, args) => { ClearForm(); LoadSenderInfo(); };
                    bill.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Chuyển khoản thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chuyển khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            if (txtIDNguoiNhan != null)
                txtIDNguoiNhan.Text = "";
            if (txtSoTien != null)
                txtSoTien.Text = "";
            if (txtNDCK != null)
                txtNDCK.Text = "";
            if (txtTenNguoiNhan != null)
                txtTenNguoiNhan.Text = "";
            _recipientAccount = null;
            _transferAmount = 0;
        }

        private void ucTransfer_Load(object sender, EventArgs e)
        {
        }

        private void txtSoDu_Click(object sender, EventArgs e)
        {

        }
    }
}