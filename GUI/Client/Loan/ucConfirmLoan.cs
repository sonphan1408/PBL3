using BLL.Services;
using DTO.Models;
using GUI.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Client.Loan
{
    public partial class ucConfirmLoan : UserControl
    {
        public Action<UserControl> NavigateTo;
        public Action<UserControl> NavigateTo1;
        private LoanContractDTO Data;
        public ucConfirmLoan(LoanContractDTO draff)
        {
            InitializeComponent();
            Data = draff;
        }

        private void ucConfirmLoan_Load(object sender, EventArgs e)
        {
            // Ẩn panel check password ban đầu
           panelCheckPassword.Visible = false;

            if (Data != null)
            {


                lblLoanAmount.Text = Data.LoanAmount.ToString("N0") + " VNĐ";
                lblContractId.Text = Data.ContractID.ToString();
                lblTermMonths.Text = Data.TermMonths.ToString() + " tháng";
                lblRate.Text = Data.InterestRate.ToString("0.00") + " %/năm";
              

                lblStartDate.Text = Data.StartDate.ToString("dd/MM/yyyy");
                lblEndDate.Text = Data.EndDate.ToString("dd/MM/yyyy");

                // Gắn event cho các nút
                btnConfirm.Click += BtnConfirm_Click;
                btnPassword.Click += BtnPassword_Click;
                btnExit.Click += BtnExit_Click;

            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            // Hiển thị panel check password
            if (!btnProvison.Checked)
            {
                MessageBox.Show("Vui lòng đồng ý với các điều khoản trước khi tiếp tục!");
                return;
            }
            panelCheckPassword.Visible = true;

            txtCheckPassword.Focus();

        }
        bool isProcessing = false;
        private void BtnPassword_Click(object sender, EventArgs e)
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

                bool passwordValid = FinancialService.CheckPassword(Data.AccountNumber, password);

                if (!passwordValid)
                {
                    MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCheckPassword.Clear();
                    isProcessing = false;
                    return;
                }

                bool isCreated = LoanService.ProcessNewLoanRegistration(Data);
                if (!isCreated)
                {
                    MessageBox.Show("Có lỗi xảy ra khi tạo hợp đồng vay. Vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isProcessing = false;
                    return;
                }
                // Mật khẩu chính xác, tạo hợp đồng vay
                MessageBox.Show("Hợp đồng vay đã được xác nhận thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var notifData = new DTO.Models.NotificationMessageDTO
                {
                    OperationType = "deposit",
                    NotificationType = "transaction",
                    Amount = Data.LoanAmount,
                    Description = $"Giải ngân khoản vay ({Data.ContractID})"
                };
                GUI.Session.UserSession.RaiseNotification(notifData);
                panelCheckPassword.Visible = false;
                txtCheckPassword.Clear();
                //UserSession.LoadLoanData();
                UserSession.AddBalance(Data.LoanAmount);
                UserSession.LoadLoanData();
                ucLoanDashboard loan = new ucLoanDashboard();
                loan.NavigateTo = this.NavigateTo;
                loan.NavigateTo1 = this.NavigateTo1;

                NavigateTo(loan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isProcessing = false;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            // Thoát khỏi form hoặc quay lại
            panelCheckPassword.Visible = false;
            txtCheckPassword.Clear();
            this.Dispose();
        }

        private void lblContractId_Click(object sender, EventArgs e)
        {

        }

        private void btnExitCheckPassword_Click(object sender, EventArgs e)
        {
            panelCheckPassword.Visible = false;
            txtCheckPassword.Clear();

        }

        private void panelCheckPassword_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProvison_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
