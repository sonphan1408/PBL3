using BLL.Services;
using DTO.Models;
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
    public partial class ucCardLoan : UserControl
    {
        private LoanContractDTO Data;
        public Action<UserControl> NavigateTo;
        public Action<UserControl> NavigateTo1;
        public event Action<LoanContractDTO> FinalSettlement;
        public ucCardLoan()
        {
            InitializeComponent();
        }

        public void LoadData(LoanContractDTO loanContract)  
        {
            Data = loanContract;
            lblLoanAmount.Text = loanContract.LoanAmount.ToString("N0") + " VNĐ";
            lblContractID.Text = loanContract.ContractID;
            string status = loanContract.Status;
            if (status == "Active")
            {
                status = "Đang thanh toán";

            }
            else if (status == "Overdue")
            {
                status = "Quá hạn";
            }
            else if (status == "Closed")
            {
                status = "Đã tất toán";
            }
            lblStartDate.Text =  status;
            lblRemainingBalance.Text =  loanContract.RemainingBalance.ToString("N0") + " VNĐ";
            lblTermMonth.Text = loanContract.TermMonths.ToString() + " tháng";

            
                DateTime nextDueDate = LoanService.GetNextDueDate(loanContract.ContractID);
                if (nextDueDate != DateTime.MinValue)
                {
                    lblDueDate.Text = nextDueDate.ToString("dd/MM/yyyy");
                }
                else
                {
                    lblDueDate.Text = "N/A";
                }
            
        }

        private void ucCardLoan_Load(object sender, EventArgs e)
        {

        }

        private void lblTermMonth_Click(object sender, EventArgs e)
        {

        }

     

        private void btnDetail_Click(object sender, EventArgs e)
        {
            ucDetailLoan detailLoan = new ucDetailLoan();
            detailLoan.LoadData(Data);
            detailLoan.NavigateTo = NavigateTo;
            detailLoan.NavigateTo1 = NavigateTo1;
            NavigateTo1(detailLoan);

        }

        private void btnFinalSettlement_Click(object sender, EventArgs e)
        {
            FinalSettlement?.Invoke(Data);

        }
    }
}
