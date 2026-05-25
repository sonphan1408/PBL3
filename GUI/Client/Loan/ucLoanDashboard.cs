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
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;
using System.Windows.Markup;
using ContentAlignment = System.Windows.Forms.VisualStyles.ContentAlignment;

namespace GUI.Client.Loan
{
    public partial class ucLoanDashboard : UserControl
    {
        public Action<UserControl> NavigateTo;
        public Action<UserControl> NavigateTo1;
        private LoanContractDTO currentContract;
        private LoanSchedulesDTO _nextSchedule;
        public ucLoanDashboard()
        {
            InitializeComponent();
        }

        private void ucLoanDashboard_Load(object sender, EventArgs e)
        {
            UserSession.DataLoanChanged += LoadData;

            this.Disposed += UcLoanDashboard_Disposed;
            LoadData();
        }
        private void UcLoanDashboard_Disposed(object sender, EventArgs e)
        {
            
            UserSession.DataLoanChanged -= LoadData;
        }
        private void LoadData()
        {
            try
            {
                panelPaidAmount.Visible = false;
                List<LoanContractDTO> loanContracts = LoanService.GetLoanContractsByAccountNumber(UserSession.CurrentUser.AccountNumber);
                List<LoanRepaymentDTO> loanRepayments = LoanService.GetLoanRepaymentsByAccountNumber(UserSession.CurrentUser.AccountNumber);

                if (loanContracts == null || loanContracts.Count == 0)
                {
                    Label emptyLabel = new Label 
                    { 
                        Text = "Không có khoản vay nào", 
                        AutoSize = true, 
                        Dock = DockStyle.Top, 
                        TextAlign = (System.Drawing.ContentAlignment)ContentAlignment.Center 
                    };
                    flowLayoutListLoan.Controls.Add(emptyLabel);
                    return;
                }

                DrawModernSplineAreaChart(loanRepayments);
                LoadLoanContracts(loanContracts);
                LoadNextDueSchedule(loanContracts);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách vay: " + ex.Message);
            }
        }

        private void LoadNextDueSchedule(List<LoanContractDTO> loanContracts)
        {
            try
            {
          
                LoanSchedulesDTO nextSchedule = LoanService.GetNextPendingScheduleByAccountNumber(loanContracts);
                if (nextSchedule == null)
                {
                    lblDueDate.Text = "Không có khoản nợ cần trả";
                    lblTotalExpectedAmount.Text = "---";
                    return;
                }
                _nextSchedule = nextSchedule;
                
                lblDueDate.Text = nextSchedule.DueDate.ToString("dd/MM/yyyy");

           
                decimal totalExpectedAmount = nextSchedule.TotalExpectedAmount;
                lblTotalExpectedAmount.Text = totalExpectedAmount.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch trả nợ tiếp theo: " + ex.Message);
            }
        }
        private void LoadLoanContracts(List<LoanContractDTO> loanContracts)
        {
            try
            {
                // Xóa các card cũ
                flowLayoutListLoan.Controls.Clear();
                decimal  total = 0;
                // Thêm từng loan card vào FlowLayout
                foreach (var loanContract in loanContracts)
                {
                    total += loanContract.RemainingBalance;
                    ucCardLoan loanCard = new ucCardLoan();
                    loanCard.LoadData(loanContract);
                    loanCard.NavigateTo = this.NavigateTo;
                    loanCard.NavigateTo1 = this.NavigateTo1;
                    loanCard.FinalSettlement += btnFinalSettlement_Click;
                    // Thiết lập kích thước card để fit với FlowLayout
                    loanCard.Width = flowLayoutListLoan.Width - 20; // Trừ đi padding

                    // Thêm card vào FlowLayout
                    flowLayoutListLoan.Controls.Add(loanCard);
                }
                lblTotalAmount.Text = total.ToString("N0") + " VND";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách khoản vay: " + ex.Message);
            }
        }

        private void btnCreateLoan_Click(object sender, EventArgs e)
        {
            ucCreateLoan createLoan = new ucCreateLoan();
            createLoan.NavigateTo = this.NavigateTo;
            createLoan.NavigateTo1 = this.NavigateTo1;
            this.NavigateTo1(createLoan);

        }
        private void DrawModernSplineAreaChart(List<LoanRepaymentDTO> repaymentHistory)
        {
            try
            {
                // 1. CHUẨN BỊ DỮ LIỆU
                if (repaymentHistory == null || repaymentHistory.Count == 0) return;

                var chartData = repaymentHistory
                    .GroupBy(r => r.PaymentDate.Date)
                    .Select(g => new
                    {
                        Date = g.Key,
                        TotalPaid = g.Sum(x => x.PrincipalPaid + x.InterestPaid)
                    })
                    .OrderBy(x => x.Date)
                    .ToList();
                decimal total = 0; 
                foreach (var chart in chartData)
                {
                    total+= chart.TotalPaid;
                }

                lblAmountRepayment.Text = total.ToString("N0") + " VND"; 
                // 2. LÀM SẠCH BIỂU ĐỒ
                chartAmount.Series.Clear();
                chartAmount.ChartAreas.Clear();
                chartAmount.Legends.Clear();

                // ==========================================
                // 3. CẤU HÌNH VÙNG VẼ (CHART AREA) TỐI GIẢN
                // ==========================================
                ChartArea chartArea = new ChartArea("MainArea");

                // Nền trắng muốt
                chartArea.BackColor = Color.White;

                // Lưới (Grid): Chỉ giữ lại đường ngang, màu cực kỳ nhạt
                chartArea.AxisX.MajorGrid.Enabled = false;
                chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
                chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Solid;

                // Tắt các vạch chia (Tick marks) và viền trục để bảng trông "thoát" hơn
                chartArea.AxisX.MajorTickMark.Enabled = false;
                chartArea.AxisY.MajorTickMark.Enabled = false;

                // Nếu kỹ hơn, bạn có thể tắt luôn cả vạch chia phụ (nếu có)
                chartArea.AxisX.MinorTickMark.Enabled = false;
                chartArea.AxisY.MinorTickMark.Enabled = false;
                chartArea.AxisX.LineColor = Color.Transparent;
                chartArea.AxisY.LineColor = Color.Transparent;

                // Định dạng chữ (Chữ màu xám, Tháng viết tắt kiểu Jan, Feb, Mar...)
                chartArea.AxisX.LabelStyle.Format = "MMM";
                chartArea.AxisX.LabelStyle.ForeColor = Color.Gray;
                chartArea.AxisY.LabelStyle.ForeColor = Color.Gray;

                // MẸO: Thêm chữ 'K' cho trục Y giống ảnh (Rút gọn hàng nghìn)
                // Ví dụ: 20,000 -> 20K. (Nếu số quá lớn tiền triệu thì bạn đổi lại thành "N0" nhé)
                chartArea.AxisY.LabelStyle.Format = "#,##0,k";

                chartAmount.ChartAreas.Add(chartArea);

                // ==========================================
                // 4. BIẾN HÌNH THÀNH SPLINE AREA (MÀU MINT GREEN)
                // ==========================================
                Series series = new Series("TienDaTra");

                // ĐỔI SANG SPLINE AREA (Cong và đổ bóng)
                series.ChartType = SeriesChartType.SplineArea;

                // Màu chủ đạo: Xanh bạc hà (Mint Green/Teal) giống hình
                Color mintGreen = Color.FromArgb(46, 204, 113);

                // Vẽ cái đường viền cong cong phía trên cùng
                series.BorderColor = mintGreen;
                series.BorderWidth = 3;

                // Vẽ phần Gradient đổ bóng phía dưới (Từ xanh đậm nhạt dần xuống trong suốt)
                series.Color = Color.FromArgb(100, mintGreen); // Độ mờ alpha = 100 (Cao nhất là 255)
                series.BackGradientStyle = GradientStyle.TopBottom;
                series.BackSecondaryColor = Color.FromArgb(10, mintGreen); // Càng xuống dưới càng trong suốt

                // Tắt chấm tròn đi để đường line mượt mà trơn tru y như ảnh mẫu
                series.MarkerStyle = MarkerStyle.None;

                // 5. ĐỔ DỮ LIỆU
                foreach (var item in chartData)
                {
                    series.Points.AddXY(item.Date, item.TotalPaid);
                }

                chartAmount.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi vẽ biểu đồ: " + ex.Message);
            }
        }

        private void chartAmount_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Số tiền tra không được vượt quá số dư của bạn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isProcessingFinal = false;
                    return;
                }

                bool passwordValid = FinancialService.CheckPassword(currentContract.AccountNumber, password);

                if (!passwordValid)
                {
                    MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCheckPassword.Clear();
                    isProcessingFinal = false;
                    return;
                }
                decimal actualAmountDeducted;
                // Thuc hien tinh tien ta no theo ky han
                bool isPaid = LoanService.ProcessFullSettlement(currentContract, out actualAmountDeducted);
                if (!isPaid)
                {
                    MessageBox.Show("Có lỗi xảy ra khi tất toán khoản vay. Vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isProcessingFinal = false;
                    return;
                }
                // Thanh toán khoản vay!
                MessageBox.Show("Tất toán khoản vay thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                bool passwordValid = FinancialService.CheckPassword(UserSession.CurrentUser.AccountNumber, password);

                if (!passwordValid)
                {
                    MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCheckPassword.Clear();
                    isProcessing = false;
                    return;
                }
                decimal actualAmountDeducted;
                // Thuc hien tinh tien ta no theo ky han
                bool isPaid = LoanService.ProcessPayment(_nextSchedule.ContractID, amountPaid, out actualAmountDeducted);
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

            DateTime allowedPaymentDate = _nextSchedule.DueDate.Date.AddMonths(-1);
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
            decimal amountToPay = _nextSchedule.TotalExpectedAmount - _nextSchedule.TotalPaidAmount;
            lblExpectedTotalAmount.Text = "Số tiền bạn cần phải trả trong kỳ này là: " + amountToPay.ToString("N0") + " VNĐ";
            txtAmount.ReadOnly = false;
            panelPaidAmount.Visible = true;
            txtAmount.Focus();
        }
        private void btnFinalSettlement_Click(LoanContractDTO loanContract)
        {
            currentContract = loanContract;
            btnPassword.Visible = false;
            btnConfirm.Visible = true;
            kryptonLabel1.Text = "Số tiền để tất toán khoản vay";
            lblExpectedTotalAmount.Text = "";
            decimal amountToPay = LoanService.CalculateSettlementAmount(loanContract.RemainingBalance);
            txtAmount.Text = amountToPay.ToString("N0");
            panelPaidAmount.Visible = true;
            txtAmount.Focus();
            txtAmount.ReadOnly = true;
        }

        private void btnExitCheckPassword_Click(object sender, EventArgs e)
        {
            panelPaidAmount.Visible = false;
        }

        private void btnRepayment_Click(object sender, EventArgs e)
        {
           ucLoanRepayment loanRepayment = new ucLoanRepayment();
            loanRepayment.NavigateTo1 = this.NavigateTo1;
            this.NavigateTo1(loanRepayment);
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            ucListLoanSchedule loanSchedule = new ucListLoanSchedule();
            loanSchedule.NavigateTo1 = this.NavigateTo1;
            this.NavigateTo1(loanSchedule);
        }
    }
}
