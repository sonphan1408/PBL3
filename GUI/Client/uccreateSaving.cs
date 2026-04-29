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
using Krypton.Toolkit;

namespace GUI.Client
{
    public partial class uccreateSaving : UserControl
    {
        private string savingType;
        public Action<UserControl> NavigateTo;
        public Action<UserControl> NavigateTo1;

        public uccreateSaving(string savingType)
        {
            this.savingType = savingType;
            InitializeComponent();
        }

       

        private void uccreateSaving_Load(object sender, EventArgs e)
        {
            //kryptonTextBox1.StateCommon.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.None;
            //kryptonTextBox1.StateActive.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.None;
            //kryptonComboBox1.StateCommon.ComboBox.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.None;
            //kryptonComboBox1.StateActive.ComboBox.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.None;
            LoadComboBoxRate(savingType);
            lblAccountNumber.Text = UserSession.CurrentUser.AccountNumber.ToString();
            lblBalance.Text = UserSession.CurrentUser.Balance.ToString("N2") + "VNĐ";
            txtPrincialAmount.TextChanged += TxtPrincialAmount_TextChanged;
        }
        private void LoadComboBoxRate(string savingType)

        {
            List<InterestRateDTO> interestRate = FinancialService.GetRatesByCategory(savingType);
            var valueCombox = interestRate.Select(r => new
            {
                display = r.TermMonths + " tháng (Lãi: " + r.RateValue.ToString("0.00") + "%)",
                value = r.RateValue,
                termMonths = r.TermMonths,

            }).ToList();
            cbTermMonths.DataSource = valueCombox;
            cbTermMonths.DisplayMember = "display";
            cbTermMonths.ValueMember = "value";
        }

        private void btnHouse_Click(object sender, EventArgs e)
        {
            txtDesc.Text = "Nhà";
        }

        private void btnCar_Click(object sender, EventArgs e)
        {
            txtDesc.Text = "Xe";
        }

        private void btnWedding_Click(object sender, EventArgs e)
        {
            txtDesc.Text = "Đám cưới";
        }

        private void btnTour_Click(object sender, EventArgs e)
        {
            txtDesc.Text = "Du lịch";
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (cbTermMonths.SelectedItem == null) return;

            // Validate principal amount input
            if (string.IsNullOrWhiteSpace(txtPrincialAmount.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền gửi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal principalAmount;
            if (!decimal.TryParse(txtPrincialAmount.Text, out principalAmount))
            {
                MessageBox.Show("Số tiền gửi không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate minimum amount (50000)
            if (principalAmount <= 50000)
            {
                MessageBox.Show("Số tiền gửi phải lớn hơn 50,000 VNĐ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate maximum amount (cannot exceed account balance)
            if (principalAmount > UserSession.CurrentUser.Balance)
            {
                MessageBox.Show("Số tiền gửi không được vượt quá số dư tài khoản (" + UserSession.CurrentUser.Balance.ToString("N0") + " VNĐ)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic valueCb = cbTermMonths.SelectedItem;
            decimal rate = valueCb.value;
            int termMonths = valueCb.termMonths;
            string goal = txtDesc.Text;
            


            SavingContractsDTO draff = FinancialService.CreateSavingDraft(principalAmount, termMonths, savingType, goal, rate, UserSession.CurrentUser.AccountNumber);


            ucConfirmSaving confirmSaving = new ucConfirmSaving(draff);
            confirmSaving.NavigateTo = this.NavigateTo;
            confirmSaving.NavigateTo1 = this.NavigateTo1;

            if (NavigateTo1 != null)  
            {
                NavigateTo1( confirmSaving);
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
          this.Dispose();

        }

        private void TxtPrincialAmount_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrincialAmount.Text))
            {
                ResetTextBoxColor();
                return;
            }

            decimal principalAmount;
            if (!decimal.TryParse(txtPrincialAmount.Text, out principalAmount))
            {
                SetTextBoxError();
                return;
            }

           
            if (principalAmount <= 50000 || principalAmount > UserSession.CurrentUser.Balance)
            {
                SetTextBoxError();
            }
            else
            {
                SetTextBoxValid();
            }
        }

        private void SetTextBoxError()
        {
            txtPrincialAmount.StateCommon.Back.Color1 = Color.FromArgb(255, 200, 200); // Light red
            txtPrincialAmount.StateCommon.Border.Color1 = Color.Red;
            txtPrincialAmount.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
        }

        private void SetTextBoxValid()
        {
            txtPrincialAmount.StateCommon.Back.Color1 = Color.White;
            txtPrincialAmount.StateCommon.Border.Color1 = Color.Green;
            txtPrincialAmount.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
        }

        private void ResetTextBoxColor()
        {
            txtPrincialAmount.StateCommon.Back.Color1 = Color.White;
            txtPrincialAmount.StateCommon.Border.Color1 = Color.Empty;
        }
    }
}
