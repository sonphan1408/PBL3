using BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Client
{
    public partial class ucAccountInfo : UserControl
    {
        public Action<UserControl> NavigateTo { get; set; }
        public ucAccountInfo()
        {
            InitializeComponent();
        }

        // Sự kiện chạy khi vừa mở trang Thông tin tài khoản
        private void ucAccountInfo_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Cắt viền Avatar thành hình tròn (Code cũ của bạn)
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, picAvatar.Width, picAvatar.Height);
                picAvatar.Region = new Region(path);

                // 2. Load thông tin người dùng từ Session
                var currentAccount = GUI.Session.UserSession.CurrentUser;
                if (currentAccount != null)
                {
                    // 🌟 CÁCH SỬA LỖI Ở ĐÂY: 
                    // Gọi Database lấy lại toàn bộ thông tin Account dựa vào Username (để chắc chắn có CustomerID chuẩn)
                    var dbAccount = AccountService.GetAccountByUsername(currentAccount.Username);

                    if (dbAccount != null)
                    {
                        // Dùng dbAccount.CustomerID thay vì currentAccount.CustomerID
                        var customerInfo = AccountService.GetCustomerInfo(dbAccount.CustomerID);

                        if (customerInfo != null)
                        {
                            txtFullName.Text = customerInfo.FullName;
                            txtPhoneNumber.Text = customerInfo.PhoneNumber;
                            txtEmail.Text = customerInfo.Email;
                            txtAddress.Text = customerInfo.Address;
                            LoadAvatar(customerInfo.AvatarPath);
                        }
                    }

                    // Đổ thông tin tài khoản
                    txtUsername.Text = currentAccount.Username;
                    txtUsername.ReadOnly = true;
                    lblBalance.Text = currentAccount.Balance.ToString("N0") + " VND";
                }
            }
            catch (Exception ex)
            {
                // 🌟 NẾU CÓ LỖI NGẦM, NÓ SẼ HÉT LÊN Ở ĐÂY CHO MÌNH BIẾT
                MessageBox.Show("Lỗi khi load giao diện: " + ex.Message + "\n\nChi tiết: " + ex.StackTrace,
                                "Bắt quả tang lỗi ngầm",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        

        // Hàm hỗ trợ Load ảnh chống bị khóa file (Lock File)
        private void LoadAvatar(string avatarPath)
        {
            try
            {
                if (!string.IsNullOrEmpty(avatarPath) && File.Exists(avatarPath))
                {
                    using (FileStream fs = new FileStream(avatarPath, FileMode.Open, FileAccess.Read))
                    {
                        picAvatar.Image = Image.FromStream(fs);
                        picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    // Nếu khách hàng chưa có ảnh, có thể để trống hoặc gán 1 ảnh mặc định ở đây
                    // picAvatar.Image = Properties.Resources.default_avatar;
                }
            }
            catch (Exception ex)
            {
                // Log lỗi nhẹ nhàng, không làm sập phần mềm
                Console.WriteLine("Lỗi tải ảnh đại diện: " + ex.Message);
            }
        }

        // Sự kiện khi bấm nút Thoát
        private void btnExit_Click(object sender, EventArgs e)
        {
            // Gọi lại trang chủ (Dashboard)
            ucClientHome ucHome = new ucClientHome();
            ucHome.NavigateTo = this.NavigateTo;
            NavigateTo?.Invoke(ucHome);
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Gọi trang Đổi mật khẩu
            ucChangePassword ucChangePass = new ucChangePassword();
            ucChangePass.NavigateTo = this.NavigateTo;
            NavigateTo?.Invoke(ucChangePass);
        }

        // Sự kiện khi bấm nút Cập nhật
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Lấy người dùng hiện tại
            var currentAccount = GUI.Session.UserSession.CurrentUser;

            string newFullName = txtFullName.Text.Trim();
            string newPhoneNumber = txtPhoneNumber.Text.Trim();
            string newEmail = txtEmail.Text.Trim();
            string newAddress = txtAddress.Text.Trim();

            // Gọi thẳng BLL: Ném dữ liệu cho BLL tự lo việc Validate Regex và gọi xuống SQL
            string errorMessage = AccountService.UpdateCustomerInfo(currentAccount.AccountNumber, newFullName, newPhoneNumber, newEmail, newAddress);

            if (errorMessage == "")
            {
                MessageBox.Show("Cập nhật thông tin tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // (Tùy chọn) Ra lệnh cho Form mẹ cập nhật lại chữ trên góc phải màn hình
                var dashboardForm = this.FindForm() as frmClientDashboard;
                if (dashboardForm != null)
                {
                    // dashboardForm.RefreshHeaderUserInfo(); 
                }
            }
            else
            {
                // BLL báo lỗi (Nhập sai định dạng, thiếu độ dài...) -> In thẳng lỗi của BLL ra cho khách đọc
                MessageBox.Show(errorMessage, "Cảnh báo nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void kryptonLabel2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
