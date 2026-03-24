using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
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

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DigitalBankingDB;Integrated Security=True;TrustServerCertificate=True";
            string sql = @"SELECT 'Customer' AS UserRole FROM Accounts WHERE Username = @u AND Password = @p
               UNION
               SELECT Role AS UserRole FROM Employees WHERE Username = @u AND Password = @p";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@u", TaiKhoan.Text);
                    cmd.Parameters.AddWithValue("@p", MatKhau.Text);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string role = result.ToString();
                        string username = TaiKhoan.Text;

                        MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                        TaiKhoan.Text = "Username";
                        MatKhau.Text = "Password";
                        TaiKhoan.ForeColor = Color.Gray;
                        MatKhau.ForeColor = Color.Gray;
                        MatKhau.UseSystemPasswordChar = false;

                        this.Hide();
                        if(role == "Customer")
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
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
