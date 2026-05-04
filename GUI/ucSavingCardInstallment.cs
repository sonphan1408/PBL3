using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO.Models;

namespace GUI
{
    public partial class ucSavingCardInstallment : UserControl

    {
        public Action<UserControl> NavigateTo;
        public Action<UserControl> NavigateTo1;
        private SavingContractsDTO _savingData;

        public ucSavingCardInstallment()
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

        /// <summary>
        /// Thiết lập dữ liệu tiết kiệm cho card
        /// </summary>
        public void SetData(SavingContractsDTO savingContract)
        {
            _savingData = savingContract;
            LoadData();
        }

        /// <summary>
        /// Tải dữ liệu vào các control
        /// </summary>
        private void LoadData()
        {
            if (_savingData == null)
                return;

            try
            {
                // Thiết lập các label
                lblContractId.Text = _savingData.ContractID;
                lblBalance.Text = _savingData.CurrentBalance.ToString("N0") + " VNĐ";
                lblInterestRate.Text = "(" + _savingData.InterestRate.ToString() + "/năm)";
                lblAccruedInterest.Text = _savingData.AccruedInterest.ToString("N0") + " VNĐ";
                lblStartDate.Text = _savingData.StartDate.ToString("dd/MM/yyyy");
                lblEndDate.Text = _savingData.EndDate.ToString("dd/MM/yyyy");

                // Tính toán tiến độ
                UpdateProgressBar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cập nhật thanh tiến độ dựa trên thời gian đã trôi qua
        /// </summary>
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ucSavingCardInstallment_Load(object sender, EventArgs e)
        {
            UpdateProgressBar();
        }

        private void kryptonGroup2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            ucDetailSaving detailSaving = new ucDetailSaving();
            detailSaving.LoadData(_savingData);
            //detailSaving.NavigateTo = NavigateTo;
            detailSaving.NavigateTo1 = NavigateTo1;
            NavigateTo1(detailSaving);

        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (NavigateTo != null)
            {
                ucDeposit deposit = new ucDeposit();
                deposit.LoadData(_savingData);
                deposit.NavigateTo1 = this.NavigateTo1;
                deposit.NavigateTo = this.NavigateTo;
                NavigateTo1(deposit);
            }
        }
    }
}
