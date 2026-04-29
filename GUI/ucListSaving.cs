using BLL.Services;
using DTO.Models;
using GUI.Client;
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
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;
using ContentAlignment = System.Windows.Forms.VisualStyles.ContentAlignment;

namespace GUI
{
    public partial class ucListSaving : UserControl
    {
        public Action<UserControl> NavigateTo;
        public Action<UserControl> NavigateTo1;
        public ucListSaving()
        {
            InitializeComponent();
        }

        private void ucListSaving_Load(object sender, EventArgs e)
        {
            
            LoadData();  
           
        }
        private void LoadData()
        {
            List<SavingContractsDTO> savingContracts = FinancialService.GetSavingContractsByAccountNumber(UserSession.CurrentUser.AccountNumber);

            if (savingContracts == null || savingContracts.Count == 0)
            {

                Label emptyLabel = new Label { Text = "Không có tiết kiệm nào", AutoSize = true, Dock = DockStyle.Top, TextAlign = (System.Drawing.ContentAlignment)ContentAlignment.Center };
                flowLayoutListSaving.Controls.Add(emptyLabel);
                return;
            }
            LoadSavingContracts(savingContracts);
            UpdateCharts(savingContracts);

        }

        private void LoadSavingContracts(List<SavingContractsDTO> savingContracts)
        {
            try
            {
                // Xóa các card cũ
                flowLayoutListSaving.Controls.Clear();
                decimal totalDeposit = 0m;
                decimal totalExpectedInterest = 0m;
                // Thêm từng saving card vào FlowLayout
                foreach (var savingContract in savingContracts)
                {
                    // Tạo ucSavingCardInstallment để hiển thị dữ liệu
                    if(savingContract.SavingType == "Installment")
                          
                    {
                        ucSavingCardInstallment savingCard = new ucSavingCardInstallment();
                        savingCard.SetData(savingContract);
                        savingCard.NavigateTo = this.NavigateTo;
                        savingCard.NavigateTo1 = this.NavigateTo1;
                        // Thiết lập kích thước card để fit với FlowLayout
                        savingCard.Width = flowLayoutListSaving.Width - 20; // Trừ đi padding
                                                                            //savingCard.Height = 200; // Chiều cao card
                                                                            //savingCard.Width = flowLayoutListSaving.ClientSize.Width - 25;
                                                                            // Thêm card vào FlowLayout
                        flowLayoutListSaving.Controls.Add(savingCard);

                    }else if(savingContract.SavingType == "Term")
                    {
                        ucSavingCardTerm savingCard = new ucSavingCardTerm();
                        savingCard.SetData(savingContract);
                        savingCard.NavigateTo = this.NavigateTo;
                        savingCard.NavigateTo1 = this.NavigateTo1;
                        // Thiết lập kích thước card để fit với FlowLayout
                        savingCard.Width = flowLayoutListSaving.Width - 20; // Trừ đi padding
                                                                            //savingCard.Height = 200; // Chiều cao card
                                                                            //savingCard.Width = flowLayoutListSaving.ClientSize.Width - 25;
                                                                            // Thêm card vào FlowLayout
                        flowLayoutListSaving.Controls.Add(savingCard);
                    }

                    totalDeposit += savingContract.CurrentBalance;
                    totalExpectedInterest += savingContract.AccruedInterest;
                }
                lblTotalDeposit.Text = totalDeposit.ToString("N0") + "  VNĐ";
                lblTotalExpectedInterest.Text = totalExpectedInterest.ToString("N0") + "  VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách tiết kiệm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Làm mới danh sách tiết kiệm
        /// </summary>
        //public void RefreshList()
        //{
        //    LoadSavingContracts();
        //}
        private void ConfigureChartStyle(Chart chart, string titleText)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Legends.Clear();
            chart.Titles.Clear();

            // Tiêu đề màu Xanh Navy đậm
            Title title = new Title(titleText);
            title.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(0, 51, 102);
            chart.Titles.Add(title);

            ChartArea ca = new ChartArea();
            ca.BackColor = Color.Transparent;
            ca.Area3DStyle.Enable3D = true;   // Giữ hiệu ứng 3D khối nổi
            ca.Area3DStyle.Inclination = 45;
            ca.Area3DStyle.Rotation = 10;
            chart.ChartAreas.Add(ca);

            // Cấu hình Chú thích (Legend) - Nơi tập trung toàn bộ thông tin
            Legend leg = new Legend();
            leg.Docking = Docking.Right;
            leg.Alignment = StringAlignment.Center;
            leg.BackColor = Color.Transparent;
            leg.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            // Cho phép hiển thị tên và số tiền trên cùng 1 dòng trong chú thích
            leg.LegendStyle = LegendStyle.Table;
            chart.Legends.Add(leg);

            Series sr = new Series("Data");
            sr.ChartType = SeriesChartType.Doughnut; // Kiểu hình nhẫn có lỗ ở giữa
            sr["DoughnutRadius"] = "45";

            // QUAN TRỌNG: Tắt toàn bộ nhãn dán trên hình để biểu đồ trông sạch hơn
            sr.IsValueShownAsLabel = false;

            chart.Series.Add(sr);
        }

        // 2. HÀM ĐỔ DỮ LIỆU: GHÉP TÊN + TIỀN VÀO BẢNG CHÚ THÍCH
        private void UpdateCharts(List<SavingContractsDTO> data)
        {
            
            ConfigureChartStyle(chartSavingType, "Loại tiết kiệm");

            // Bảng màu xanh chuyển sắc chuyên nghiệp cho ngân hàng
            Color[] bluePalette = new Color[]
            {
        Color.FromArgb(0, 102, 204),   // Royal Blue
        Color.FromArgb(51, 153, 255),  // Sky Blue
        Color.FromArgb(0, 76, 153),    // Dark Blue
        Color.FromArgb(153, 204, 255), // Light Blue
        Color.FromArgb(0, 128, 255)    // Azure
            };

            // --- BIỂU ĐỒ MỤC TIÊU ---
           

            // --- BIỂU ĐỒ LOẠI TIẾT KIỆM ---
            var typeStats = data.GroupBy(s => s.SavingType)
                     .Select(g => new
                     {
                         // Cú pháp: Nếu là Installment -> Gửi góp. Nếu Term -> Kỳ hạn. Còn lại -> Lấy tên gốc
                         Name = g.Key == "Installment" ? "Gửi góp" :
                                g.Key == "Term" ? "Kỳ hạn" :
                                (g.Key ?? "Khác"),

                         Total = g.Sum(s => s.PrincipalAmount)
                     })
                     .ToList();

            int j = 0;
            foreach (var item in typeStats)
            {
                int idx = chartSavingType.Series["Data"].Points.AddXY(item.Name, (double)item.Total);

                // GHÉP TÊN VÀ SỐ TIỀN VÀO CHÚ THÍCH (VD: "Gửi góp: 1,000,000 VNĐ")
                chartSavingType.Series["Data"].Points[idx].LegendText = $"{item.Name}\n{item.Total:N0} VNĐ";

                chartSavingType.Series["Data"].Points[idx].Color = bluePalette[(bluePalette.Length - 1 - (j % bluePalette.Length))];
                j++;
            }
        }
      
        private void flowLayoutListSaving_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chartSavingGoal_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnInstallment_Click(object sender, EventArgs e)
        {
            string savingType = "Installment";
            uccreateSaving createSaving = new uccreateSaving(savingType);
            createSaving.NavigateTo = this.NavigateTo;
            createSaving.NavigateTo1 = this.NavigateTo1;
            if (NavigateTo1 != null)
            {
                NavigateTo1(createSaving);
            }
        }

        private void btnTerm_Click(object sender, EventArgs e)
        {
            string savingType = "Term";
            uccreateSaving createSaving = new uccreateSaving(savingType);
            createSaving.NavigateTo = this.NavigateTo;
            createSaving.NavigateTo1 = this.NavigateTo1;
            if (NavigateTo1 != null)
            {
                NavigateTo1(createSaving);
            }
        }
    }
}

