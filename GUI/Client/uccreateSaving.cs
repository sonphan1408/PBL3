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

namespace GUI.Client
{
    public partial class uccreateSaving : UserControl
    {
        public Action<UserControl> NavigateTo;

        public uccreateSaving()
        {
            InitializeComponent();
        }

       

        private void uccreateSaving_Load(object sender, EventArgs e)
        {
            //kryptonTextBox1.StateCommon.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.None;
            //kryptonTextBox1.StateActive.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.None;
            //kryptonComboBox1.StateCommon.ComboBox.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.None;
            //kryptonComboBox1.StateActive.ComboBox.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.None;
            LoadComboBoxRate("Installment");
            lblAccountNumber.Text = UserSession.CurrentUser.AccountNumber.ToString();
            lblBalance.Text = UserSession.CurrentUser.Balance.ToString("N2") + "VNĐ";
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

            dynamic valueCb = cbTermMonths.SelectedItem;
            decimal rate = valueCb.value;
            int termMonths = valueCb.termMonths;
            string goal = txtDesc.Text;


            ucConfirmSaving confirmSaving = new ucConfirmSaving();
            confirmSaving.NavigateTo = this.NavigateTo;

            if (NavigateTo != null)
            {
                NavigateTo( confirmSaving);
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            ucSaving saving = new ucSaving();
           

            if (NavigateTo != null)
            {
                NavigateTo(saving);
            }

        }
    }
}
