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

namespace GUI.Client.Loan
{
    public partial class ucDetailLoan : UserControl
    {
        private LoanContractDTO data;
        private LoanSchedulesDTO schedule;
        public Action<UserControl> NavigateTo;
        public Action<UserControl> NavigateTo1;
        public ucDetailLoan()
        {
            InitializeComponent();

            
        }   
        private void RefreshData()
        {
            LoadDataByEvent(data.ContractID);
        }
        private void LoadDataByEvent(string contractId)
        {
            LoanContractDTO loanContract = LoanService.GetLoanContractByContractId(contractId);
            LoadData(loanContract);
        }
        private void ucDetailLoan_Load(object sender, EventArgs e)
        {
            UserSession.DataLoanChanged += RefreshData;
            this.Disposed += UcDetailLoan_Disposed;
            LoadData(data);
        }
        private void UcDetailLoan_Disposed(object sender, EventArgs e)
        {
                
            UserSession.DataLoanChanged -= RefreshData;
        }
        public void LoadData(LoanContractDTO loanContract)
        {
            this.data = loanContract;
            panelPaidAmount.Visible = false;
            LoadDataLoanCOntract(loanContract);
            LoadDataLoanSchedule(loanContract);
            LoadLoanSchedulesTable(loanContract);
        }
        private void LoadDataLoanCOntract(LoanContractDTO loanContract)
        {
                
                lblContractID.Text = loanContract.ContractID;
                lblLoanAmount.Text = loanContract.LoanAmount.ToString("N0") + " VNĐ";
                lblInterestRate.Text = loanContract.InterestRate.ToString("0.00") + "%/năm";
                lblTermMonths.Text = loanContract.TermMonths + " tháng";
                lblRemainingBalance.Text = loanContract.RemainingBalance.ToString("N0") + " VNĐ";
            
           
        }
        private void LoadDataLoanSchedule(LoanContractDTO loanContract)
        {
            LoanSchedulesDTO schedules = LoanService.GetNextPendingSchedule(loanContract.ContractID);
            this.schedule = schedules;

            if (schedules != null)
            {
                lblInstallmentNumber.Text =  schedules.InstallmentNumber.ToString();
                lblDueDate.Text = schedules.DueDate.ToString("dd/MM/yyyy");
                lblExpectedPrincipal.Text = schedules.ExpectedPrincipal.ToString("N0") + " VNĐ";
                lblExpectedInterest.Text = schedules.ExpectedInterest.ToString("N0") + " VNĐ";
                lblPenaltyAmount.Text = schedules.PenaltyAmount.ToString("N0") + " VNĐ";
                lblStatus.Text = schedules.Status == "Pending" ? "Đang chờ thanh toán" : "Quá hạn thanh toán";
                lblAmountPaid.Text = (schedules.PrincipalPaid + schedules.InterestPaid).ToString("N0") + " VNĐ";

               
                
            }
           else
            {
                lblDueDate.Text = "Không có lịch trả nào";
                lblExpectedPrincipal.Text = "";
                lblExpectedInterest.Text = "";
                lblPenaltyAmount.Text = "";
                lblStatus.Text = "";
                lblAmountPaid.Text = "";
            }

        }
        private void SetupDataGridView()
        {
            
            dgvLoanSchedules.AutoGenerateColumns = false;
            dgvLoanSchedules.AllowUserToAddRows = false;
            dgvLoanSchedules.ReadOnly = true;
            dgvLoanSchedules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoanSchedules.BackgroundColor = Color.White;
            dgvLoanSchedules.RowTemplate.Height = 40;
            dgvLoanSchedules.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 246, 250);

            // 2. Xóa cột cũ
            dgvLoanSchedules.Columns.Clear();

            dgvLoanSchedules.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "InstallmentNumber",
                HeaderText = "Kỳ",
                Name = "colKy",
                Width = 80
            });

            dgvLoanSchedules.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DueDate",
                HeaderText = "Ngày đến hạn",
                Name = "colNgay",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            
            dgvLoanSchedules.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalExpectedAmount", 
                HeaderText = "Tổng tiền phải trả (VNĐ)",
                Name = "colTongPhaiTra",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

           
            dgvLoanSchedules.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalPaidAmount", 
                HeaderText = "Tổng tiền đã trả (VNĐ)",
                Name = "colTongDaTra",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });
            dgvLoanSchedules.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ExpectedInterest",
                HeaderText = " Tiền lãi (VNĐ)",
                Name = "colTienlai",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvLoanSchedules.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Trạng thái",
                Name = "colTrangThai",
                Width = 120
            });
        }
        private void LoadLoanSchedulesTable(LoanContractDTO loanContract)
        {
            try
            {
                dgvLoanSchedules.DataSource = null;
                dgvLoanSchedules.Columns.Clear();
                SetupDataGridView();
                List<LoanSchedulesDTO> schedules = LoanService.GetAllSchedulesByContractId(loanContract.ContractID);
                

                dgvLoanSchedules.DataSource = schedules;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch trả nợ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void SetTextBoxError()
        {
            txtAmount.StateCommon.Back.Color1 = Color.FromArgb(255, 200, 200); // Light red
            txtAmount.StateCommon.Border.Color1 = Color.Red;
            txtAmount.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
        }

        private void SetTextBoxValid()
        {
            txtAmount.StateCommon.Back.Color1 = Color.White;
            txtAmount.StateCommon.Border.Color1 = Color.Green;
            txtAmount.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
        }

        private void ResetTextBoxColor()
        {
            txtAmount.StateCommon.Back.Color1 = Color.White;
            txtAmount.StateCommon.Border.Color1 = Color.Empty;
        }
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                ResetTextBoxColor();
                return;
            }

            decimal loanAmount;
            if (!decimal.TryParse(txtAmount.Text, out loanAmount))
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

        private void panelCheckPassword_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExitCheckPassword_Click(object sender, EventArgs e)
        {
            panelPaidAmount.Visible = false;
            txtCheckPassword.Clear();
        }
        bool isProcessing = false;
        private void btnPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (isProcessing) return;
                isProcessing = true;
                string password = txtCheckPassword.Text;
               
                if (string.IsNullOrWhiteSpace(txtAmount.Text))
                {
                    MessageBox.Show("Vui lòng nhập số tiền ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal amountPaid;
                if (!decimal.TryParse(txtAmount.Text, out amountPaid))
                {
                    MessageBox.Show("Số tiền  không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (amountPaid < 50000)
                {
                    MessageBox.Show("Số tiền  phải tối thiểu 50,000", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (amountPaid > UserSession.CurrentUser.Balance)
                {
                    MessageBox.Show("Số tiền vay không được vượt quá số dư của bạn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isProcessing = false;
                    return;
                }

                bool passwordValid = FinancialService.CheckPassword(data.AccountNumber, password);

                if (!passwordValid)
                {
                    MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCheckPassword.Clear();
                    isProcessing = false;
                    return;
                }
                decimal actualAmountDeducted;
                // Thuc hien tinh tien ta no theo ky han
                bool isPaid = LoanService.ProcessPayment(data.ContractID, amountPaid,out actualAmountDeducted);
                if (!isPaid)
                {
                    MessageBox.Show("Có lỗi xảy ra khi thanh toán. Vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isProcessing = false;
                    return;
                }
                // Thanh toán khoản vay!
                MessageBox.Show("Thanh toán khoản vay!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelPaidAmount.Visible = false;
                txtCheckPassword.Clear();

                //Thuc hien truừ tiền tài khoản trên ram
                UserSession.UpdateBalance(actualAmountDeducted);

                


                //Gọi sự kiện cập nhật
               UserSession.LoadLoanData();





            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isProcessing = false;
            }

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
           
            DateTime allowedPaymentDate = schedule.DueDate.Date.AddMonths(-1);
            DateTime currentDate = DateTime.Now.Date;

            if (currentDate < allowedPaymentDate)
            {
                MessageBox.Show($"Chưa đến thời gian thanh toán cho kỳ này.\nBạn chỉ được phép thanh toán từ ngày {allowedPaymentDate:dd/MM/yyyy}.",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            txtAmount.Text = "";
            btnPassword.Visible = true;
            btnConfirm.Visible = false;
            kryptonLabel1.Text = "Lưu ý: Bạn có thể nộp dư để khấu trừ vào nợ gốc";

            decimal amountToPay = schedule.TotalExpectedAmount - schedule.TotalPaidAmount;
            lblExpectedTotalAmount.Text = amountToPay.ToString("N0") + " VNĐ";

            txtAmount.ReadOnly = false;
            panelPaidAmount.Visible = true;
            txtAmount.Focus();
        }

        private void btnFinalSettlement_Click(object sender, EventArgs e)
        {

            btnPassword.Visible = false;
            btnConfirm.Visible = true;
            kryptonLabel1.Text = "Số tiền để tất toán khoản vay";
            lblExpectedTotalAmount.Text = "";
            decimal amountToPay = LoanService.CalculateSettlementAmount(data.RemainingBalance);
            txtAmount.Text = amountToPay.ToString("N0");
            panelPaidAmount.Visible = true;
            txtAmount.Focus();
            txtAmount.ReadOnly = true;


        }

        private void dgvLoanSchedules_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLoanSchedules.Columns[e.ColumnIndex].Name == "colTrangThai" && e.Value != null)
            {
                string status = e.Value.ToString();
                e.CellStyle.Font = new Font(dgvLoanSchedules.Font, FontStyle.Bold);

                if (status == "Paid")
                {
                    e.Value = "Đã thanh toán"; 
                    e.CellStyle.ForeColor = Color.SeaGreen;
                }
                else if (status == "Pending")
                {
                    e.Value = "Chưa thanh toán";
                    e.CellStyle.ForeColor = Color.DarkOrange;
                }
                else if (status == "Overdue")
                {
                    e.Value = "Quá hạn";
                    e.CellStyle.ForeColor = Color.Crimson;
                }
                else if(status == "Partially Paid")
                {
                    e.Value = "Thanh toán một phần";
                    e.CellStyle.ForeColor = Color.Crimson;
                }
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }
        bool isProcessingFinal = false;
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (isProcessingFinal) return;
                isProcessingFinal = true;
                string password = txtCheckPassword.Text;

                

                decimal amountPaid;
                if (!decimal.TryParse(txtAmount.Text, out amountPaid))
                {
                    MessageBox.Show("Số tiền  không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (amountPaid > UserSession.CurrentUser.Balance)
                {
                    MessageBox.Show("Số tiền vay không được vượt quá số dư của bạn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isProcessingFinal = false;
                    return;
                }

                bool passwordValid = FinancialService.CheckPassword(data.AccountNumber, password);

                if (!passwordValid)
                {
                    MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCheckPassword.Clear();
                    isProcessingFinal = false;
                    return;
                }
                decimal actualAmountDeducted;
                // Thuc hien tinh tien ta no theo ky han
                bool isPaid = LoanService.ProcessFullSettlement(data, out actualAmountDeducted);
                if (!isPaid)
                {
                    MessageBox.Show("Có lỗi xảy ra khi tất toán khoản vay. Vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isProcessingFinal = false;
                    return;
                }
                // Thanh toán khoản vay!
                MessageBox.Show("Tất toán khoản vay thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var notifData = new DTO.Models.NotificationMessageDTO
                {
                    OperationType = "withdrawal",
                    NotificationType = "transaction",
                    Amount = actualAmountDeducted,
                    Description = $"Tất toán khoản vay ({data.ContractID})"
                };
                GUI.Session.UserSession.RaiseNotification(notifData);
                panelPaidAmount.Visible = false;
                txtCheckPassword.Clear();

                //Thuc hien truừ tiền tài khoản trên ram
                UserSession.UpdateBalance(actualAmountDeducted);




                //Gọi sự kiện cập nhật
                UserSession.LoadLoanData();





            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isProcessingFinal = false;
            }
        }
    }
}


