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
        private void ucAccountInfo_Load(object sender, EventArgs e)
        {
            try
            {
                // Cat avatar 
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, picAvatar.Width, picAvatar.Height);
                picAvatar.Region = new Region(path);

                // load thong tin tai khoan tu session 
                var currentAccount = GUI.Session.UserSession.CurrentUser;
                if (currentAccount != null)
                {
                    // Goi database de lay thong tin khach hang, tranh truong hop thong tin trong session bi sai lech voi database (Vi co the tai khoan vua bi cap nhat o 1 noi khac, ma session chua kip cap nhat)
                    var dbAccount = AccountService.GetAccountByUsername(currentAccount.Username);

                    if (dbAccount != null)
                    {
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

                    // thong tin tai khoan thi lay tu session la chinh xac roi, khong can goi database nua
                    txtUsername.Text = currentAccount.Username;
                    txtUsername.ReadOnly = true;
                    lblBalance.Text = currentAccount.Balance.ToString("N0") + " VND";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load giao diện: " + ex.Message + "\n\nChi tiết: " + ex.StackTrace,
                                "Bắt quả tang lỗi ngầm",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        

        // Ham load avatar
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
                    // Neu chua co anh dai dien, hoac duong dan khong hop le, thi hien thi avatar mac dinh
                    // picAvatar.Image = Properties.Resources.default_avatar;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tải ảnh đại diện: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ucClientHome ucHome = new ucClientHome();
            ucHome.NavigateTo = this.NavigateTo;
            NavigateTo?.Invoke(ucHome);
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ucChangePassword ucChangePass = new ucChangePassword();
            ucChangePass.NavigateTo = this.NavigateTo;
            NavigateTo?.Invoke(ucChangePass);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var currentAccount = GUI.Session.UserSession.CurrentUser;

            string newFullName = txtFullName.Text.Trim();
            string newPhoneNumber = txtPhoneNumber.Text.Trim();
            string newEmail = txtEmail.Text.Trim();
            string newAddress = txtAddress.Text.Trim();

            // Goi thang BLL de cap nhat thong tin
            string errorMessage = AccountService.UpdateCustomerInfo(currentAccount.AccountNumber, newFullName, newPhoneNumber, newEmail, newAddress);

            if (errorMessage == "")
            {
                MessageBox.Show("Cập nhật thông tin tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Goi form dashboard
                var dashboardForm = this.FindForm() as frmClientDashboard;
                if (dashboardForm != null)
                {
                    // dashboardForm.RefreshHeaderUserInfo(); 
                }
            }
            else
            {
                // BLL bao loi
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
