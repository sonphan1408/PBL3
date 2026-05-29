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
using System.Windows.Forms.VisualStyles;

namespace GUI.Client.Loan
{
    public partial class ucCreateLoan : UserControl
    {
        public Action<UserControl> NavigateTo;
        public Action<UserControl> NavigateTo1;
        public ucCreateLoan()
        {
            InitializeComponent();
        }

        private void btn200_Click(object sender, EventArgs e)
        {
            txtLoanAmount.Text = "200000";
        }

        private void btn500_Click(object sender, EventArgs e)
        {
            txtLoanAmount.Text = "500000";
        }

        private void btn100_Click(object sender, EventArgs e)
        {
            txtLoanAmount.Text = "100000";
        }

        private void btn1000_Click(object sender, EventArgs e)
        {
            txtLoanAmount.Text = "1000000";
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
        private void ucCreateLoan_Load(object sender, EventArgs e)
        {
            LoadComboBoxRate("Loan");
        }
        private void SetTextBoxError()
        {
            txtLoanAmount.StateCommon.Back.Color1 = Color.FromArgb(255, 200, 200); // Light red
            txtLoanAmount.StateCommon.Border.Color1 = Color.Red;
            txtLoanAmount.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
        }

        private void SetTextBoxValid()
        {
            txtLoanAmount.StateCommon.Back.Color1 = Color.White;
            txtLoanAmount.StateCommon.Border.Color1 = Color.Green;
            txtLoanAmount.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
        }

        private void ResetTextBoxColor()
        {
            txtLoanAmount.StateCommon.Back.Color1 = Color.White;
            txtLoanAmount.StateCommon.Border.Color1 = Color.Empty;
        }
        private void txtLoanAmount_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLoanAmount.Text))
            {
                ResetTextBoxColor();
                return;
            }

            decimal loanAmount;
            if (!decimal.TryParse(txtLoanAmount.Text, out loanAmount))
            {
                SetTextBoxError();
                return;
            }


            if (loanAmount < 50000 || loanAmount > UserSession.CurrentUser.Balance)
            {
                SetTextBoxError();
            }
            else
            {
                SetTextBoxValid();
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            // Validate loan amount
            if (string.IsNullOrWhiteSpace(txtLoanAmount.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền vay", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal loanAmount;
            if (!decimal.TryParse(txtLoanAmount.Text, out loanAmount))
            {
                MessageBox.Show("Số tiền vay không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (loanAmount < 50000)
            {
                MessageBox.Show("Số tiền vay phải tối thiểu 50,000", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           

            // Validate term months
            if (cbTermMonths.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn kỳ hạn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validation passed - create LoanContractDTO
            try
            {
                // Lấy dữ liệu từ combobox
                dynamic selectedItem = cbTermMonths.SelectedItem;
                int termMonths = selectedItem.termMonths;
                decimal interestRate = selectedItem.value;

                

                // Tạo LoanContractDTO
                LoanContractDTO loanDraft = new LoanContractDTO
                {
                    ContractID = FinancialService.GenerateContractID("VV"),
                    AccountNumber = UserSession.CurrentUser.AccountNumber,
                    LoanAmount = loanAmount,
                    RemainingBalance = loanAmount,
                    InterestRate = interestRate,
                    TermMonths = termMonths,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(termMonths),
                    Collateral = "", 
                    Status = "Pending"
                };

                // Chuyển tới ucConfirmLoan
                ucConfirmLoan confirmLoan = new ucConfirmLoan(loanDraft);
                confirmLoan.NavigateTo = this.NavigateTo;
                confirmLoan.NavigateTo1 = this.NavigateTo1;
                

                if (NavigateTo1 != null)
                {
                    NavigateTo1(confirmLoan);
                }
                else if (NavigateTo != null)
                {
                    NavigateTo(confirmLoan);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
