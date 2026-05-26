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
    public partial class ucListLoanSchedule : UserControl
    {
        public Action<UserControl> NavigateTo1;
        public ucListLoanSchedule()
        {
            InitializeComponent();
        }
        private void SetupScheduleDataGridView()
        {
            dgvLoanSchedules.AutoGenerateColumns = false;
            dgvLoanSchedules.AllowUserToAddRows = false;
            dgvLoanSchedules.ReadOnly = true;
            dgvLoanSchedules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoanSchedules.BackgroundColor = Color.White;
            dgvLoanSchedules.RowTemplate.Height = 40;
            dgvLoanSchedules.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);

            // DÒNG CODE "PHÉP THUẬT": Tự động giãn các cột để lấp đầy khoảng trống bên phải
            dgvLoanSchedules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvLoanSchedules.Columns.Clear();

            // 1. Kỳ
            dgvLoanSchedules.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "InstallmentNumber",
                HeaderText = "Kỳ",
                Width = 50,
                FillWeight = 50
            });

            // 2. Ngày đến hạn
            dgvLoanSchedules.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DueDate",
                HeaderText = "Hạn thanh toán",
                Width = 110,
                FillWeight = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            // 3. (MỚI THÊM) Tiền gốc 
            dgvLoanSchedules.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ExpectedPrincipal",
                HeaderText = "Gốc phải trả",
                Width = 110,
                FillWeight = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            // 4. (MỚI THÊM) Tiền lãi
            dgvLoanSchedules.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ExpectedInterest",
                HeaderText = "Lãi phải trả",
                Width = 110,
                FillWeight = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            // 5. Tiền phạt
            dgvLoanSchedules.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PenaltyAmount",
                HeaderText = "Phạt (nếu có)",
                Width = 100,
                FillWeight = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", ForeColor = Color.Red }
            });

            // 6. Tổng tiền dự kiến (Gốc + Lãi + Phạt)
            dgvLoanSchedules.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalExpectedAmount",
                HeaderText = "Tổng cần trả",
                Width = 120,
                FillWeight = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Font = new Font(dgvLoanSchedules.Font, FontStyle.Bold) }
            });

            // 7. Tổng tiền đã thanh toán
            dgvLoanSchedules.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalPaidAmount",
                HeaderText = "Đã thanh toán",
                Width = 120,
                FillWeight = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", ForeColor = Color.ForestGreen }
            });

            // 8. Trạng thái
            dgvLoanSchedules.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Trạng thái",
                Name = "colStatus",
                Width = 100,
                FillWeight = 100
            });
        }
        private void LoadLoanScheduleData()
        {
            try
            {
                dgvLoanSchedules.DataSource = null;
                SetupScheduleDataGridView();

                List<LoanSchedulesDTO> schedules = LoanService.GetSchedulesByAccountNumber(UserSession.CurrentUser.AccountNumber);
                if (schedules == null || schedules.Count == 0) return;

                dgvLoanSchedules.DataSource = schedules;

                // Tô màu cột trạng thái
                foreach (DataGridViewRow row in dgvLoanSchedules.Rows)
                {
                    if (row.Cells["colStatus"].Value != null)
                    {
                        string status = row.Cells["colStatus"].Value.ToString();
                        var style = row.Cells["colStatus"].Style;
                        style.Font = new Font(dgvLoanSchedules.Font, FontStyle.Bold);

                        if (status == "Paid")
                            style.ForeColor = Color.ForestGreen;
                        else if (status == "Overdue")
                            style.ForeColor = Color.Firebrick;
                        else
                            style.ForeColor = Color.DarkOrange;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị danh sách lịch trả nợ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ucListLoanSchedule_Load(object sender, EventArgs e)
        {
            UserSession.DataLoanChanged += LoadLoanScheduleData;

            this.Disposed += UcLoanSchedule_Disposed;
            LoadLoanScheduleData();
        }
        private void UcLoanSchedule_Disposed(object sender, EventArgs e)
        {

            UserSession.DataLoanChanged -= LoadLoanScheduleData;
        }
    }
}
