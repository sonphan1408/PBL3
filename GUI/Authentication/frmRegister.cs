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

namespace GUI.Authentication
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirm.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DigitalBankingDB;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string sqlCustomer = @"INSERT INTO Customers (FullName, Gender, DateOfBirth, Address, PhoneNumber, Email, IDCard) 
                                   OUTPUT INSERTED.CustomerID 
                                   VALUES (@name, @gender, @dob, @address, @phone, @email, @idcard)";

                    int newCustomerId = 0;
                    using (SqlCommand cmd = new SqlCommand(sqlCustomer, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@name", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@gender", bxGender.Text);
                        cmd.Parameters.AddWithValue("@dob", dtDayofBirth.Value);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@phone", txtSDT.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@idcard", txtCCCD.Text);

                        newCustomerId = (int)cmd.ExecuteScalar();
                    }

                    string newAccountNumber = "8888000" + newCustomerId.ToString();

                    string sqlAccount = @"INSERT INTO Accounts (AccountNumber, CustomerID, Username, Password, Balance, Status) 
                                  VALUES (@accNum, @custId, @user, @pass, 0, 'Active')";

                    using (SqlCommand cmd = new SqlCommand(sqlAccount, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@accNum", newAccountNumber);
                        cmd.Parameters.AddWithValue("@custId", newCustomerId);
                        cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show($"Đăng ký thành công!\nSố tài khoản ngân hàng của bạn là: {newAccountNumber}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                    frmLogin login = new frmLogin();
                    login.Show();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi đăng ký (Có thể Username hoặc SĐT đã tồn tại): \n" + ex.Message, "Lỗi Hệ Thống");
                }
            }
        }
    }
}
