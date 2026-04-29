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
    public partial class ucSavingTransactionCard : UserControl
    {
        public ucSavingTransactionCard()
        {
            InitializeComponent();
        }
        public void LoadData(SavingTransactionDTO transaction,SavingContractsDTO savingContract)
        {
            lblTransactionType.Text = transaction.TransactionType;
            lblAmount.Text = transaction.Amount.ToString("N0") + " VNĐ";
            lblTransactionDate.Text = transaction.TransactionDate.ToString("dd/MM/yyyy");
            lblDate.Text = savingContract.StartDate.ToString("dd/MM/yyyy") + " - " + savingContract.EndDate.ToString("dd/MM/yyyy");
            lblnterestRate.Text = "Lãi suất: " + "(" + savingContract.InterestRate.ToString("0.00") + "/năm)";



        }
        private void ucSavingTransactionCard_Load(object sender, EventArgs e)
        {


        }
    }
}
