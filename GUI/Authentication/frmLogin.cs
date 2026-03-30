using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Services;
using GUI.Client;
using GUI.Admin;

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
            if(TaiKhoan.Text == "Username")
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

        private void MatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (TaiKhoan.Text == "Username" || TaiKhoan.Text == "" ||
                MatKhau.Text  == "Password" || MatKhau.Text  == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string role = AuthService.Login(TaiKhoan.Text, MatKhau.Text);
                string username = TaiKhoan.Text;

                MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                TaiKhoan.Text = "Username";
                MatKhau.Text = "Password";
                TaiKhoan.ForeColor = Color.Gray;
                MatKhau.ForeColor = Color.Gray;
                MatKhau.UseSystemPasswordChar = false;

                this.Hide();
                if (role == "Customer")
                {
                    frmClientDashboard customerForm = new frmClientDashboard(username);
                    customerForm.ShowDialog();
                }
                else
                {
                    frmAdminDashboard employeeForm = new frmAdminDashboard(username);
                    employeeForm.ShowDialog();
                }
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
