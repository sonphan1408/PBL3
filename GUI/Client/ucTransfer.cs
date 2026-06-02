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
            LoadSenderInfo();
        }

        private void InitializeBankSelector()
        {
            if (_ucSelectBank == null)
            {
                _ucSelectBank = new ucSelectBank();
                _ucSelectBank.Location = new System.Drawing.Point(94, 334);
                _ucSelectBank.Size = new System.Drawing.Size(380, 250);
                _ucSelectBank.BankSelected += (s, e) =>
                {
                    _selectedBank = _ucSelectBank.SelectedBank;
                    if (lblNganHang != null)
                        lblNganHang.Text = _selectedBank.BankName;
                    if (txtTenNguoiNhan != null)
                        txtTenNguoiNhan.Text = "";
                    _recipientAccount = null;

                    if (this.Controls.Contains(_ucSelectBank))
                    {
                        this.Controls.Remove(_ucSelectBank);
                        _ucSelectBank.Dispose();
                        _ucSelectBank = null;
                    }

                    this.Refresh();
                };
            }
        }

        private void LoadSenderInfo()
        {
            try
            {
                _senderAccount = _transferService.GetSenderByUsername(UserSession.CurrentUser.Username);
                if (_senderAccount != null)
                {
                    txtIDUser.Text = _senderAccount.AccountNumber;
                    txtSoDu.Text = _senderAccount.Balance.ToString("N0") + " VND";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin người gửi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectBank_Click(object sender, EventArgs e)
        {
            InitializeBankSelector();
            if (_ucSelectBank != null)
            {
                if (this.Controls.Contains(_ucSelectBank))
                {
                    // Đã hiển thị -> Ẩn đi
                    this.Controls.Remove(_ucSelectBank);
                }
                else
                {
                    // Chưa hiển thị -> Hiện ra
                    if (lblNganHang != null)
                    {
                        _ucSelectBank.Location = new System.Drawing.Point(
                            lblNganHang.Location.X - 90 ,
                            lblNganHang.Location.Y + lblNganHang.Height - 105
                        );
                    }
                    this.Controls.Add(_ucSelectBank);
                    _ucSelectBank.BringToFront();
                }
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
                try
                {
                    if (_selectedBank.BankCode == "HTTS")
                    {
                        // CK nội bộ
                        _recipientAccount = _transferService.GetRecipientByAccountNumber(accountNumber);
                    }
                    else
                    {
                        // CK liên ngân hàng
                        _recipientAccount = _transferService.GetRecipientByAccountNumberAndBank(accountNumber, _selectedBank.BankCode);
                    }

                    if (_recipientAccount != null)
                    {
                        string recipientName = "";

                        if (_selectedBank.BankCode == "HTTS")
                        {
                            // Nội bộ
                            recipientName = _transferService.GetCustomerName(_recipientAccount.CustomerID);
                        }
                        else
                        {
                            // Liên ngân hàng
                            recipientName = _transferService.GetExternalAccountName(accountNumber, _selectedBank.BankCode);
                        }

                        txtTenNguoiNhan.Text = recipientName;
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

        private void BtnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (_recipientAccount == null)
                {
                    MessageBox.Show("Vui lòng tìm kiếm tài khoản người nhận", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal transferAmount = 0;
                if (txtSoTien != null && !string.IsNullOrWhiteSpace(txtSoTien.Text))
                {
                    string amountText = txtSoTien.Text.Replace(",", "").Replace(".", "").Trim();
                    try
                    {
                        transferAmount = decimal.Parse(amountText);
                    }
                    catch
                    {
                        MessageBox.Show("Số tiền nhập không hợp lệ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (transferAmount <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số tiền chuyển khoản", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check có đủ tiền ko
                if (_senderAccount == null || _senderAccount.Balance < transferAmount)
                {
                    MessageBox.Show("Số dư tài khoản không đủ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiện panel nhập mật khẩu
                panelCheckPassword.Visible = true;
                txtCheckPassword.Clear();
                txtCheckPassword.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isProcessing = false;

        private void btnPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (isProcessing) return;
                isProcessing = true;
                string password = txtCheckPassword.Text;

                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isProcessing = false;
                    return;
                }

                bool passwordValid = FinancialService.CheckPassword(_senderAccount.AccountNumber, password);

                if (!passwordValid)
                {
                    MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCheckPassword.Clear();
                    isProcessing = false;
                    return;
                }

                // Mật khẩu đúng -> Thực hiện chuyển tiền
                decimal transferAmount = decimal.Parse(txtSoTien.Text.Replace(",", "").Replace(".", "").Trim());
                string notes = "";
                if (txtNDCK != null && !string.IsNullOrWhiteSpace(txtNDCK.Text))
                    notes = txtNDCK.Text;

                string bankCode = _selectedBank?.BankCode;
                bool result = _transferService.ExecuteTransfer(UserSession.CurrentUser.Username, _recipientAccount.AccountNumber, transferAmount, notes, bankCode);

                if (result)
                {
                    string senderName = _transferService.GetCustomerName(_senderAccount.CustomerID);

                    string recipientName = "";
                    if (bankCode == "HTTS")
                    {
                        // Nội bộ
                        recipientName = _transferService.GetCustomerName(_recipientAccount.CustomerID);
                    }
                    else
                    {
                        // Liên nh
                        recipientName = _transferService.GetExternalAccountName(_recipientAccount.AccountNumber, bankCode);
                    }

                    // ✅ Hiển thị Toast Notification
                    ToastNotification.ShowTransfer(recipientName, _recipientAccount.AccountNumber, transferAmount);

                    // Trigger notification with structured data (for Sender)
                    var notificationData = new NotificationMessageDTO
                    {
                        OperationType = "transfer",
                        NotificationType = "transaction",
                        RecipientName = recipientName,
                        RecipientAccount = _recipientAccount.AccountNumber,
                        TransferAmount = transferAmount
                    };
                    UserSession.RaiseNotification(notificationData);

                    BLL.Services.NotificationService.CreateNotification(
                        _recipientAccount.Username,
                        $"Tài khoản nhận được +{transferAmount:N0} VND từ {senderName}. Nội dung: {notes}",
                        "transaction"
                    );

                    // Update tiền hiện tại của ng dùng
                    UserSession.UpdateBalance(transferAmount);

                    // Ẩn panel sau khi thành công
                    panelCheckPassword.Visible = false;
                    txtCheckPassword.Clear();

                    frmBill bill = new frmBill(
                        amount: transferAmount,
                        senderAccount: _senderAccount.AccountNumber,
                        senderName: senderName,
                        recipientAccount: _recipientAccount.AccountNumber,
                        recipientName: recipientName,
                        notes: notes
                    );
                    
                    bill.ShowDialog();
                    ClearForm();
                    LoadSenderInfo();
                }
                else
                {
                    MessageBox.Show("Chuyển khoản thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                isProcessing = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chuyển khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isProcessing = false;
            }
        }

        private void btnExitCheckPassword_Click(object sender, EventArgs e)
        {
            panelCheckPassword.Visible = false;
            txtCheckPassword.Clear();
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
            try
            {
                if (panelCheckPassword != null)
                {
                    panelCheckPassword.Visible = false;
                }
            }
            catch { }
        }
    }
}