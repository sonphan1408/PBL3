using BLL.Services;
using DTO.Models;
using GUI.Client;
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

namespace GUI
{
    public partial class ucConfirmSaving : UserControl
    {
        public Action<UserControl> NavigateTo;
        public Action<UserControl> NavigateTo1;
        private SavingContractsDTO Data;
        public ucConfirmSaving(SavingContractsDTO draff)
        {
            InitializeComponent();
            Data = draff;
        }

        private void ucConfirmSaving_Load(object sender, EventArgs e)
        {
            // Ẩn panel check password ban đầu
           panelCheckPassword.Visible = false;
            
            if (Data != null)
            {
                
                
                lblPrincipalAmount.Text = Data.PrincipalAmount.ToString("N0") + " VNĐ";
                lblContractId.Text = Data.ContractID.ToString();
                lblTermMonths.Text = Data.TermMonths.ToString() + " tháng";
                lblRate.Text = Data.InterestRate.ToString("0.00") + " %/năm";
                if(Data.SavingType == "Installment")
                {
                    lblSavingType.Text = "Gửi góp";
                }
                else
                {
                    lblSavingType.Text = "Có kỳ hạn";
                }

               lblMaturityInterest.Text = Data.AccruedInterest.ToString("N0") + " VNĐ";

                lblStartDate.Text = Data.StartDate.ToString("dd/MM/yyyy");
                lblEndDate.Text = Data.EndDate.ToString("dd/MM/yyyy");
                lblGoal.Text = Data.Goal;

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

                // Mật khẩu chính xác, tạo tài khoản tiết kiệm với xác thực mật khẩu, trừ tiền và tạo ghi chép
                bool success = FinancialService.CreateSavingAccount(Data);

                if (success)
                {
                    MessageBox.Show("Tài khoản tiết kiệm đã được tạo thành công!.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    panelCheckPassword.Visible = false;
                    txtCheckPassword.Clear();

                    // ✅ Hiển thị Toast Notification
                    ToastNotification.ShowSaving(Data.PrincipalAmount, Data.TermMonths);

                    UserSession.UpdateBalance(Data.PrincipalAmount);
                    UserSession.LoadSavingData();

                    var notifData = new DTO.Models.NotificationMessageDTO
                    {
                        OperationType = "savings",
                        NotificationType = "success",
                        PrincipalAmount = Data.PrincipalAmount,
                        TermMonths = Data.TermMonths,
                        InterestRate = Data.InterestRate
                    };
                    UserSession.RaiseNotification(notifData);

                    ucListSaving listSaving = new ucListSaving();
                    listSaving.NavigateTo = this.NavigateTo;
                    listSaving.NavigateTo1 = this.NavigateTo1;

                    NavigateTo(listSaving);
                }
                else
                {
                    MessageBox.Show("Lỗi khi tạo tài khoản tiết kiệm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isProcessing = false;
                }
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
