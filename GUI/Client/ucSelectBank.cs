using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL.Services;
using DTO.Models;

namespace GUI.Client
{
    public partial class ucSelectBank : UserControl
    {
        private TransferService _transferService = new TransferService();
        private List<ExternalBankDTO> _banks = new List<ExternalBankDTO>();
        private ExternalBankDTO _selectedBank = null;

        public event EventHandler BankSelected;

        public ExternalBankDTO SelectedBank
        {
            get { return _selectedBank; }
            set { _selectedBank = value; }
        }

        public ucSelectBank()
        {
            InitializeComponent();
            LoadBanks();
            pnlBankList.Visible = true;
        }

        private void LoadBanks()
        {   
            try
            {
                _banks = _transferService.GetAllExternalBanks();

                // Add Http Bank for internal transfers at the beginning
                var httpBank = new ExternalBankDTO
                {
                    BankCode = "HTTS",
                    BankName = "HTTS Bank",
                    FullName = "HTTS Bank - Chuyển khoản nội bộ"
                };
                _banks.Insert(0, httpBank);

                DisplayBanks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách ngân hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayBanks()
        {
            pnlBankList.Controls.Clear();

            foreach (var bank in _banks)
            {
                Panel bankItem = CreateBankItem(bank);
                pnlBankList.Controls.Add(bankItem);
            }
        }

        private Panel CreateBankItem(ExternalBankDTO bank)
        {
            Panel itemPanel = new Panel
            {
                Size = new System.Drawing.Size(350, 60),
                Margin = new Padding(0, 5, 0, 5),
                BorderStyle = BorderStyle.None,
                BackColor = System.Drawing.Color.White,
                Cursor = Cursors.Hand
            };

            // Bank Icon (placeholder)
            PictureBox pbIcon = new PictureBox
            {
                Size = new System.Drawing.Size(40, 40),
                Location = new System.Drawing.Point(10, 10),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = System.Drawing.Color.Transparent
            };

            // Load icon from resources if available, otherwise use placeholder
            try
            {
                pbIcon.Image = GUI.Properties.Resources.ResourceManager.GetObject(bank.BankCode.ToLower()) as System.Drawing.Image;
            }
            catch
            {
                // Use a default icon or leave empty
                pbIcon.Image = null;
            }

            // Bank Name Label
            Label lblBankName = new Label
            {
                Text = bank.BankName,
                Location = new System.Drawing.Point(60, 10),
                Size = new System.Drawing.Size(280, 25),
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                BackColor = System.Drawing.Color.Transparent,
                ForeColor = System.Drawing.Color.Black
            };

            // Bank Full Name Label
            Label lblFullName = new Label
            {
                Text = bank.FullName,
                Location = new System.Drawing.Point(60, 35),
                Size = new System.Drawing.Size(280, 20),
                Font = new System.Drawing.Font("Arial", 9),
                BackColor = System.Drawing.Color.Transparent,
                ForeColor = System.Drawing.Color.Gray
            };

            itemPanel.Controls.Add(pbIcon);
            itemPanel.Controls.Add(lblBankName);
            itemPanel.Controls.Add(lblFullName);

            // Click handler
            itemPanel.Click += (s, e) => SelectBank(bank);
            pbIcon.Click += (s, e) => SelectBank(bank);
            lblBankName.Click += (s, e) => SelectBank(bank);
            lblFullName.Click += (s, e) => SelectBank(bank);

            return itemPanel;
        }

        private void SelectBank(ExternalBankDTO bank)
        {
            _selectedBank = bank;
            // No need to update lblSelectedBank since pnlSelectBank is hidden
            // Trigger event to notify parent that a bank was selected
            BankSelected?.Invoke(this, EventArgs.Empty);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            foreach (Control control in pnlBankList.Controls)
            {
                if (control is Panel panel)
                {
                    bool found = false;
                    foreach (Control ctrl in panel.Controls)
                    {
                        if (ctrl is Label lbl && lbl.Text.ToLower().Contains(searchText))
                        {
                            found = true;
                            break;
                        }
                    }
                    panel.Visible = found;
                }
            }
        }
    }
}
