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

namespace GUI
{
    public partial class ucConfirmSaving : UserControl
    {
        public Action<UserControl> NavigateTo;
        private SavingContractsDTO Data;
        public ucConfirmSaving(SavingContractsDTO draff)
        {
            InitializeComponent();
            Data = draff;
        }

        private void ucConfirmSaving_Load(object sender, EventArgs e)
        {
            if (Data != null)
            {
               
                lblPrincipalAmount.Text = Data.PrincipalAmount.ToString("N0") + " VNĐ";

                lblTermMonths.Text = Data.TermMonths.ToString() + " tháng";
                lblRate.Text = Data.InterestRate.ToString("0.00") + " %/năm";

               lblMaturityInterest.Text = Data.AccruedInterest.ToString("N0") + " VNĐ";

                lblStartDate.Text = Data.StartDate.ToString("dd/MM/yyyy");
                lblEndDate.Text = Data.EndDate.ToString("dd/MM/yyyy");
                lblGoal.Text = Data.Goal;
            }
        }
    }
}
