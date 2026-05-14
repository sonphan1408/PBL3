using BLL.Services;
using DTO.Models;
using GUI.Session;
using Krypton.Toolkit;
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
    public partial class ucSaving : UserControl
    {
        public Action<UserControl> NavigateTo;
       

        int[] allowedMonths = { 1, 3, 6, 12, 24, 36 };
        public ucSaving()
        {
            InitializeComponent();
        }

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
        {



        }

        private void kryptonLabel2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonLabel3_Click(object sender, EventArgs e)
        {

        }

        private void kryptonTrackBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            int currentIndex = trackBarTerm.Value;


            if (currentIndex >= 0 && currentIndex < allowedMonths.Length)
            {
                int actualMonth = allowedMonths[currentIndex];
                lblTermMonths.Text = actualMonth.ToString() + " months";


            }
            UpdatePreviewCard();
        }

        private void ucSaving_Load(object sender, EventArgs e)
        {


            trackBarTerm.Minimum = 0;
            trackBarTerm.Maximum = allowedMonths.Length - 1;
            trackBarTerm.Value = 0;
            lblTermMonths.Text = "1 months";
            lblInterestRate.Text = "0%";
            lblMaturityInterest.Text = "0VNĐ";
            btnTermSaving.Checked = true;
            label4.Text = UserSession.CurrentUser.Balance.ToString("N2") + "VNĐ";



        }

        private void lblTermMonths_Click(object sender, EventArgs e)
        {

        }
        private void UpdatePreviewCard()
        {
            decimal principalAmount = 0;
            if (!decimal.TryParse(txtPrincipalAmount.Text, out  principalAmount))
            {
                lblInterestRate.Text = "0%";
                lblMaturityInterest.Text = "0VNĐ";
                return;
            }
            string savingType = "";
            int termMonths = allowedMonths[trackBarTerm.Value];
             savingType = btnTermSaving.Checked ? "Term" : "";
                



            if (savingType != "" && principalAmount != 0)
            {
                //SavingsPreviewDTO previewResult = FinancialService.CalculateSavingsPreview(principalAmount, termMonths, savingType);

                //lblInterestRate.Text = previewResult.InterestRate.ToString() + "%";
                //lblMaturityInterest.Text = Math.Round(previewResult.MaturityInterest, 2).ToString("N2") + "VNĐ";

            }
        }

    
        

        private void txtPrincipalAmount_TextChanged(object sender, EventArgs e)
        {
            UpdatePreviewCard();
        }

        private void btnTermSaving_CheckedChanged(object sender, EventArgs e)
        {
            if (btnTermSaving.Checked)
            {
                UpdatePreviewCard();
            }
                
            
        }

        private void kryptonGroup1_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonLabel2_Click_1(object sender, EventArgs e)
        {

        }

        private void btnInstallment_MouseEnter(object sender, EventArgs e)
        {
           
            btnInstallment.StateCommon.Border.Color1 = Color.Red; // Viền đỏ rõ
            btnInstallment.Cursor = Cursors.Hand; // Đổi con trỏ thành bàn tay
            btnInstallment.StateCommon.Border.Width = 2;
        }

        private void btnInstallment_MouseLeave(object sender, EventArgs e)
        {

            btnInstallment.StateCommon.Border.Color1 = Color.Black;
            btnInstallment.StateCommon.Border.Width = 1;
        }

       
        private void btnTerm_MouseEnter(object sender, EventArgs e)
        {
            btnTerm.StateCommon.Border.Color1 = Color.Blue;
            btnTerm.Cursor = Cursors.Hand; 
            btnTerm.StateCommon.Border.Width = 2;

        }

        private void btnTerm_MouseLeave(object sender, EventArgs e)
        {

            btnTerm.StateCommon.Border.Color1 = Color.Black;
            btnTerm.StateCommon.Border.Width = 1;
        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void btnInstallment_Panel_Click(object sender, EventArgs e)
        {
            string savingType = "Installment";
            uccreateSaving createSaving = new uccreateSaving(savingType);
            createSaving.NavigateTo = this.NavigateTo;
            if (NavigateTo != null)
            {        
                NavigateTo(createSaving);
            }
           
        }

        private void btnTerm_Panel_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btnTerm_Panel_Click(object sender, EventArgs e)
        {
            string savingType = "Term";
            uccreateSaving createSaving = new uccreateSaving(savingType);
            createSaving.NavigateTo = this.NavigateTo;
            if (NavigateTo != null)
            {
                NavigateTo(createSaving);
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            ucListSaving  listSaving = new ucListSaving();
            listSaving.NavigateTo = this.NavigateTo;
            NavigateTo(listSaving);
        }

        private void kryptonGroup1_Panel_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
