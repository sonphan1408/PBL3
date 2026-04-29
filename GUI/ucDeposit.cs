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
using System.Windows.Markup;

namespace GUI
{
    public partial class ucDeposit : UserControl
    {
        private SavingContractsDTO _savingData;
        public Action<UserControl> NavigateTo;
        public Action<UserControl> NavigateTo1;
        public ucDeposit()
        {
            InitializeComponent();
        }

        private void ucDeposit_Load(object sender, EventArgs e)
        {

        }
        public void LoadData(SavingContractsDTO savingContract)
        {
            _savingData = savingContract;
            lblAccountNumber.Text = savingContract.AccountNumber;
           lblBalanceSaving.Text = savingContract.CurrentBalance.ToString("N0") + " VNĐ";
            lblContractId.Text = savingContract.ContractID;
            lblBalance.Text = UserSession.CurrentUser.Balance.ToString("N0") + " VNĐ";
            lblInterest.Text = savingContract.AccruedInterest.ToString("N0") + " VNĐ";

        }
        private void SetTextBoxError()
        {
                txtDeposit.StateCommon.Back.Color1 = Color.FromArgb(255, 200, 200); // Light red
            txtDeposit.StateCommon.Border.Color1 = Color.Red;
            txtDeposit.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
        }

        private void SetTextBoxValid()
        {
            txtDeposit.StateCommon.Back.Color1 = Color.White;
            txtDeposit.StateCommon.Border.Color1 = Color.Green;
            txtDeposit.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
        }

        private void ResetTextBoxColor()
        {
            txtDeposit.StateCommon.Back.Color1 = Color.White;
            txtDeposit.StateCommon.Border.Color1 = Color.Empty;
        }

        private void txtDeposit_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDeposit.Text))
            {
                ResetTextBoxColor();
                return;
            }

            decimal deposit;
            if (!decimal.TryParse(txtDeposit.Text, out deposit))
            {
                SetTextBoxError();
                return;
            }


            if (deposit < 50000 || deposit > UserSession.CurrentUser.Balance)
            {
                SetTextBoxError();
            }
            else
            {
                SetTextBoxValid();
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            decimal depositAmount;
            if (string.IsNullOrWhiteSpace(txtDeposit.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền gửi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtDeposit.Text, out depositAmount))
            {
                MessageBox.Show("Số tiền gửi không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (depositAmount > UserSession.CurrentUser.Balance)
            {
                MessageBox.Show("Số tiền gửi không được vượt quá số dư tài khoản (" + UserSession.CurrentUser.Balance.ToString("N0") + " VNĐ)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (depositAmount < 50000)
            {
                MessageBox.Show("Số tiền gửi phải lớn hơn 50,000 VNĐ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            decimal newInterest = FinancialService.CalculateInterestInstallment(depositAmount, _savingData.InterestRate, _savingData.TermMonths, _savingData.EndDate);
            ucConfirmDeposit confirmDeposit = new ucConfirmDeposit();
            confirmDeposit.LoadData(_savingData.ContractID, depositAmount,newInterest);
            confirmDeposit.NavigateTo = this.NavigateTo;
            confirmDeposit.NavigateTo1 = this.NavigateTo1;
            NavigateTo1(confirmDeposit); 

        }

        private void lblContractId_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
