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
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace GUI
{
    public partial class ucDetailSaving : UserControl
    {
        //public Action<UserControl> NavigateTo;
        public Action<UserControl> NavigateTo1;
        private SavingContractsDTO _savingData;
        public ucDetailSaving()
        {
            InitializeComponent();

            panelPassedDay.StateCommon.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.None;
            panelPassedDay.StateCommon.Border.Width = 0;

            panelTotalDay.StateCommon.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.None;
            panelTotalDay.StateCommon.Border.Width = 0;
            

            // 2. Ép tọa độ và chiều cao bằng nhau
            panelPassedDay.Location = panelTotalDay.Location;
            panelPassedDay.Height = panelTotalDay.Height;

            // 3. Xóa Margin/Padding phòng hờ Krypton tự tạo khoảng trắng
            panelPassedDay.Margin = new Padding(0);
            panelTotalDay.Margin = new Padding(0);
            panelPassedDay.Padding = new Padding(0);
            panelTotalDay.Padding = new Padding(0);

            // 4. Đưa thanh xanh lên trên cùng
            panelPassedDay.BringToFront();
        }
        private void UpdateProgressBar()
        {
            if (_savingData == null)
                return;

            DateTime startDate = _savingData.StartDate;
            DateTime endDate = _savingData.EndDate;
            DateTime today = DateTime.Now;

            // Tính tổng số ngày
            int totalDays = (endDate - startDate).Days;

            // Tính số ngày đã trôi qua
            int passedDays = (today - startDate).Days;

            // Đảm bảo không vượt quá 100%
            if (passedDays > totalDays)
                passedDays = totalDays;

            if (passedDays < 0)
                passedDays = 0;

            // Tính phần trăm tiến độ
            double progressPercentage = totalDays > 0 ? (double)passedDays / totalDays * 100 : 0;

            // Cập nhật label thông tin tiến độ
            //lblProgressInfo.Text = string.Format("Tiến độ: {0:F1}% ({1}/{2} ngày)", progressPercentage, passedDays, totalDays);

            // Cập nhật kích thước panel tiến độ dựa trên tổng kích thước
            if (panelTotalDay.Width > 0)
            {
                int totalWidth = panelTotalDay.Width;
                int progressWidth = (int)(totalWidth * progressPercentage / 100);

                // Đảm bảo progressWidth không nhỏ hơn 0
                progressWidth = Math.Max(0, progressWidth);

                panelPassedDay.Width = progressWidth;
            }
        }
        private void LoadSavingData()
        {
            if (_savingData != null)
            {

                lblPrincipalAmount.Text = _savingData.CurrentBalance.ToString("N0") + " VNĐ";
                lblContractId.Text = _savingData.ContractID.ToString();
                lblTermMonths.Text = _savingData.TermMonths.ToString() + " tháng";
                lblRate.Text = _savingData.InterestRate.ToString("0.00") + " %/năm";
                if (_savingData.SavingType == "Installment")
                {
                    lblSavingType.Text = "Gửi góp";
                }
                else
                {
                    lblSavingType.Text = "Có kỳ hạn";
                }
                if (_savingData.Status == "Active")
                {
                    lblStatus.Text = "Đang hoạt động";
                }
                else
                {
                    lblStatus.Text = "Đã tất toán";
                }
                lblStartDate1.Text = _savingData.StartDate.ToString("dd/MM/yyyy");
                lblEndDate1.Text = _savingData.EndDate.ToString("dd/MM/yyyy");


                lblMaturityInterest.Text = _savingData.AccruedInterest.ToString("N0") + " VNĐ";

                lblStartDate.Text = _savingData.StartDate.ToString("dd/MM/yyyy");
                lblEndDate.Text = _savingData.EndDate.ToString("dd/MM/yyyy");
                lblGoal.Text = _savingData.Goal;


            }
        }
        public void LoadData(SavingContractsDTO savingContract)
        {
            _savingData = savingContract;
            LoadSavingData();
            UpdateProgressBar();
        }
        private void ucDetailSaving_Load(object sender, EventArgs e)
        {

        }

        private void kryptonDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFromDate.Value;
            DateTime toDate = dtpToDate.Value;

            // 2. Kiểm tra logic ngày
            if (fromDate > toDate)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Thông báo");
                return;
            }
            LoadSavingTransaction(fromDate, toDate);
        }




        private void LoadSavingTransaction(DateTime fromDate, DateTime toDate)
        {



            try {


                List<SavingTransactionDTO> savingTransactions = FinancialService.GetSavingTransactions(_savingData.ContractID, fromDate, toDate);

              

                if (savingTransactions == null || savingTransactions.Count == 0)
                {

                    Label emptyLabel = new Label();
                    emptyLabel.Text = "Không có giao dịch tiết kiệm nào";
                    emptyLabel.AutoSize = true;
                    emptyLabel.Dock = DockStyle.Top;
                    emptyLabel.TextAlign = ContentAlignment.MiddleCenter;
                    flowLayoutPanelSavingTransaction.Controls.Add(emptyLabel);
                    return;
                }

                flowLayoutPanelSavingTransaction.Controls.Clear();


                foreach (var savingTransaction in savingTransactions)
                {
                    // Tạo ucSavingCardInstallment để hiển thị dữ liệu
                    ucSavingTransactionCard savingTransactionCard = new ucSavingTransactionCard();
                    savingTransactionCard.LoadData(savingTransaction, _savingData);


                    // Thiết lập kích thước card để fit với FlowLayout
                    savingTransactionCard.Width = flowLayoutPanelSavingTransaction.Width - 20;

                    flowLayoutPanelSavingTransaction.Controls.Add(savingTransactionCard);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách tiết kiệm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFinalSettlement_Click(object sender, EventArgs e)
        {
           DialogResult warning = MessageBox.Show(
        "Nếu tất toán trước hạn, bạn chỉ nhận được lãi suất không kỳ hạn (0.5%). Bạn có chắc chắn muốn rút tiền về tài khoản chính không?",
        "Xác nhận tất toán",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning);

            if (warning == DialogResult.Yes)
            {
                
                decimal newInterestRate = 0.5m;

                decimal newAccruedInterest = FinancialService.CalculateInterest(_savingData.PrincipalAmount, newInterestRate, _savingData.TermMonths, _savingData.StartDate, DateTime.Now);
                decimal finalAmount = _savingData.PrincipalAmount + newAccruedInterest;

                bool result = FinancialService.FinalSettlement(_savingData.AccountNumber,_savingData, newAccruedInterest, finalAmount);
                if (result)
                {
                    UserSession.AddBalance(finalAmount);
                    MessageBox.Show($"Tất toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _savingData.Status = "Closed"; 
                    _savingData.CurrentBalance = 0m; 
                    _savingData.AccruedInterest = newAccruedInterest; 
                    _savingData.EndDate = DateTime.Now; 

                   
                    LoadSavingData();
                    UpdateProgressBar();
                    UserSession.LoadSavingData();
                    btnFinalSettlement.Enabled = false;
                    btnFinalSettlement.Text = "Đã tất toán";
                   
                }
                else
                {
                    MessageBox.Show("Lỗi hệ thống: Không thể tất toán sổ này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            this.Dispose();


        }
    }

    
}

