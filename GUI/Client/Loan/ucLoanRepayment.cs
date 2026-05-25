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

namespace GUI.Client.Loan
{

    public partial class ucLoanRepayment : UserControl
    {
        public Action<UserControl> NavigateTo1;

        public ucLoanRepayment()
        {
            InitializeComponent();
        }
        private void SetupRepaymentDataGridView()
        {
            dgvRepayments.AutoGenerateColumns = false;
            dgvRepayments.AllowUserToAddRows = false;
            dgvRepayments.ReadOnly = true;
            dgvRepayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRepayments.BackgroundColor = Color.White;
            dgvRepayments.RowTemplate.Height = 42; 

            
            dgvRepayments.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);

            dgvRepayments.Columns.Clear();

            // 1. Mã giao dịch
            dgvRepayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RepaymentID",
                HeaderText = "Mã GD",
                Name = "colRepaymentID",
                Width = 80
            });

            // 2. Mã hợp đồng
            dgvRepayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ContractID",
                HeaderText = "Mã hợp đồng",
                Name = "colContractID",
                Width = 150
            });

            // 3. Ngày giao dịch (Hiện đầy đủ cả ngày và giờ)
            dgvRepayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PaymentDate",
                HeaderText = "Thời gian giao dịch",
                Name = "colPaymentDate",
                Width = 160,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm:ss" }
            });

            // 4. Tiền gốc đã trả
            dgvRepayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrincipalPaid",
                HeaderText = "Tiền gốc (VNĐ)",
                Name = "colPrincipalPaid",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            // 5. Tiền lãi đã trả
            dgvRepayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "InterestPaid",
                HeaderText = "Tiền lãi (VNĐ)",
                Name = "colInterestPaid",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            // 6. Tiền phạt đã trả
            dgvRepayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PenaltyPaid",
                HeaderText = "Tiền phạt (VNĐ)",
                Name = "colPenaltyPaid",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });


            dgvRepayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalAmount",
                HeaderText = "Tổng thanh toán",
                Name = "colTotalAmount",
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",
                    ForeColor = Color.FromArgb(41, 128, 185), // Chữ màu xanh dương xịn sò
                    Font = new Font(dgvRepayments.Font, FontStyle.Bold) // In đậm
                }
            });
        }
        private void LoadRepaymentData()
        {
            try
            {
               
                dgvRepayments.DataSource = null;
                SetupRepaymentDataGridView();

                List<LoanRepaymentDTO> histories = LoanService.GetRepaymentsByAccountNumber(UserSession.CurrentUser.AccountNumber);

                if (histories == null || histories.Count == 0)
                {
                    return;
                }

                dgvRepayments.DataSource = histories;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải lịch sử thanh toán: " + ex.Message, "Lỗi đồ họa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ucLoanRepayment_Load(object sender, EventArgs e)
        {
            UserSession.DataLoanChanged += LoadRepaymentData;

            this.Disposed += UcLoanRepayment_Disposed;
            LoadRepaymentData();
        }
        private void UcLoanRepayment_Disposed(object sender, EventArgs e)
        {

            UserSession.DataLoanChanged -= LoadRepaymentData;
        }
    }
}
