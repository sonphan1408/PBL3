using BLL.Services;
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
using System.Windows.Markup;

namespace GUI
{
    public partial class ucConfirmDeposit : UserControl
    {
        public Action<UserControl> NavigateTo;
        public Action<UserControl> NavigateTo1;
        private string _contractId;
        
        private decimal _depositAmount;
        private decimal _newInterest;

        public void LoadData(string contractId, decimal depositAmount, decimal newInterest)

        {
            _newInterest = newInterest;
            _contractId = contractId;
            
            _depositAmount = depositAmount;
        }
        public ucConfirmDeposit()
        {
            InitializeComponent();
        }

        private void ucConfirmDeposit_Load(object sender, EventArgs e)
        {
            lblAccountNumber.Text = UserSession.CurrentUser.AccountNumber;
            lblContracId.Text = _contractId;
            lblDepositAmount.Text = _depositAmount.ToString("N0") + " VNĐ";
            lblFullName.Text = AccountService.GetFullNameByCustomerId(UserSession.CurrentUser.CustomerID);
            panelCheckPassword.Visible = false;

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            panelCheckPassword.Visible = true;

            txtCheckPassword.Focus();

        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            string password = txtCheckPassword.Text;

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kiểm tra mật khẩu từ database
                bool passwordValid = FinancialService.CheckPassword(UserSession.CurrentUser.AccountNumber, password);

                if (!passwordValid)
                {
                    MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCheckPassword.Clear();
                    return;
                }

                bool isDeposit = FinancialService.Deposit(UserSession.CurrentUser.AccountNumber, _contractId, _newInterest, _depositAmount);
                if (!isDeposit)
                {
                    MessageBox.Show("Lo khi gui them", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCheckPassword.Clear();
                    return;
                }
                



                if (isDeposit)
                {
                    MessageBox.Show("Tài khoản tiết kiệm đã gui them !.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelCheckPassword.Visible = false;
                    txtCheckPassword.Clear();
                    UserSession.UpdateBalance(_depositAmount);
                    UserSession.LoadSavingData();
                    ucListSaving listSaving = new ucListSaving();
                    listSaving.NavigateTo = this.NavigateTo;
                    listSaving.NavigateTo1 = this.NavigateTo1;

                    NavigateTo(listSaving);
                }
                else
                {
                    MessageBox.Show("Lỗi khi tạo tài khoản tiết kiệm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExitCheckPassword_Click(object sender, EventArgs e)
        {
            panelCheckPassword.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
