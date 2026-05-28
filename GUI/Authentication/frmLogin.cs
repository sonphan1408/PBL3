using BLL.Services;
using DTO.Models;
using GUI.Admin;
using GUI.Client;
using GUI.Session;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.Authentication
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void TaiKhoan_Enter(object sender, EventArgs e)
        {
            if (TaiKhoan.Text == "Username")
            {
                TaiKhoan.Text = "";
                TaiKhoan.ForeColor = Color.Black;
            }
        }

        private void TaiKhoan_Leave(object sender, EventArgs e)
        {
            if (TaiKhoan.Text == "")
            {
                TaiKhoan.Text = "Username";
                TaiKhoan.ForeColor = Color.Gray;
            }
        }

        private void MatKhau_Enter(object sender, EventArgs e)
        {
            if (MatKhau.Text == "Password")
            {
                MatKhau.Text = "";
                MatKhau.ForeColor = Color.Black;
                MatKhau.UseSystemPasswordChar = true;
            }
        }

        private void MatKhau_Leave(object sender, EventArgs e)
        {
            if (MatKhau.Text == "")
            {
                MatKhau.Text = "Password";
                MatKhau.ForeColor = Color.Gray;
                MatKhau.UseSystemPasswordChar = false;
            }
        }

        Boolean check_click_back = false;
        private void Back_Click(object sender, EventArgs e)
        {
            check_click_back = true;
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmRegister registerForm = new frmRegister();
            registerForm.ShowDialog();
            if (!this.IsDisposed)
            {
                this.Show();
            }
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (TaiKhoan.Text == "Username" || TaiKhoan.Text == "" ||
                MatKhau.Text == "Password" || MatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                //Lưu tạm mật khẩu để sau check đổi mật khẩu
                string Matkhaukhachnhap = MatKhau.Text;

                AccountCustomerDTO account = AuthService.LoginCustomer(TaiKhoan.Text, MatKhau.Text);

                TaiKhoan.Text = "Username";
                MatKhau.Text = "Password";
                TaiKhoan.ForeColor = Color.Gray;
                MatKhau.ForeColor = Color.Gray;
                MatKhau.UseSystemPasswordChar = false;
               

                if(account != null)
                {
                    account.Password = Matkhaukhachnhap;

                    UserSession.CurrentUser = account;
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                    this.Hide();
                    if (account.Role == "Customer")
                    {
                        frmClientDashboard customerForm = new frmClientDashboard();
                        customerForm.ShowDialog();
                    }
                    else if (account.Role == "Admin" || account.Role == "Teller")
                    {
                        //frmAdminDashboard employeeForm = new frmAdminDashboard();
                        //employeeForm.ShowDialog();
                    }
                    this.Show();
                }
                else MessageBox.Show("Tài khoản hoặc mật khẩu bị sai!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Tắt luôn ctrinh khi bấm X (nch là cho đỡ phiền :v)
        //Nếu bấm back thì quay lại Home
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!check_click_back)
                Application.Exit();
        }
    }
}