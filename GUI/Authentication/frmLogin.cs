using DAL.Repositories;
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

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmRegister registerForm = new frmRegister();
            registerForm.ShowDialog();
            this.Show();
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
               AccountCustomerDTO account = AuthDAL.LoginCustomer(TaiKhoan.Text, MatKhau.Text);

                MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                TaiKhoan.Text = "Username";
                MatKhau.Text = "Password";
                TaiKhoan.ForeColor = Color.Gray;
                MatKhau.ForeColor = Color.Gray;
                MatKhau.UseSystemPasswordChar = false;

                this.Hide();
                if (account != null)
                {
                    UserSession.CurrentUser = account;
                    frmClientDashboard customerForm = new frmClientDashboard();
                    customerForm.ShowDialog();
                }
               
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
