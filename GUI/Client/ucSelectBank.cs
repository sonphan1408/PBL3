using System;
using System.Collections.Generic;
using System.IO;
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
        private Label _lblNoResult;

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
                    BankName = "HTTS",
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

            _lblNoResult = new Label
            {
                Text = "Không tìm thấy ngân hàng phù hợp",
                AutoSize = true,
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic),
                ForeColor = System.Drawing.Color.Gray,
                Visible = false,
                Margin = new Padding(10, 20, 0, 0)
            };
            pnlBankList.Controls.Add(_lblNoResult);

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
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = System.Drawing.Color.White,
                Cursor = Cursors.Hand
            };

            // Bank Icon
            PictureBox pbIcon = new PictureBox
            {
                Size = new System.Drawing.Size(50, 50),
                Location = new System.Drawing.Point(5, 5),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.None
            };

            // Load icon from file path based on BankName
            try
            {
                string iconPath = GetBankIconPath(bank.BankName);
                System.Diagnostics.Debug.WriteLine($"Loading icon for {bank.BankName}: {iconPath}");

                if (!string.IsNullOrEmpty(iconPath) && File.Exists(iconPath))
                {
                    // Load image directly using Bitmap
                    pbIcon.Image = new System.Drawing.Bitmap(iconPath);
                    System.Diagnostics.Debug.WriteLine($"✓ Loaded icon for {bank.BankName}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"✗ Icon file not found for {bank.BankName}: {iconPath}");
                    pbIcon.BackColor = System.Drawing.Color.LightGray;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"✗ Error loading bank icon for {bank.BankName}: {ex.Message}");
                pbIcon.BackColor = System.Drawing.Color.LightGray;
            }

            // Bank Name Label
            Label lblBankName = new Label
            {
                Text = bank.BankName,
                Location = new System.Drawing.Point(60, 10),
                Size = new System.Drawing.Size(280, 25),
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                BackColor = System.Drawing.Color.Transparent,
                ForeColor = System.Drawing.Color.Black,
                AutoSize = false
            };

            // Bank Full Name Label
            Label lblFullName = new Label
            {
                Text = bank.FullName,
                Location = new System.Drawing.Point(60, 35),
                Size = new System.Drawing.Size(280, 20),
                Font = new System.Drawing.Font("Arial", 9),
                BackColor = System.Drawing.Color.Transparent,
                ForeColor = System.Drawing.Color.Gray,
                AutoSize = false
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

        private string GetBankIconPath(string bankName)
        {
            if (string.IsNullOrEmpty(bankName))
                return null;

            // Try multiple path possibilities
            string[] possiblePaths = new string[]
            {
                // Path 1: Relative to application startup path
                Path.Combine(Application.StartupPath, "Resources", "Banks", $"{bankName}.png"),

                // Path 2: Relative to application startup path (go up directories for DLL)
                Path.Combine(Application.StartupPath, "..", "..", "Resources", "Banks", $"{bankName}.png"),

                // Path 3: Relative to application base directory
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Banks", $"{bankName}.png"),

                // Path 4: Relative to application base directory (go up for DLL)
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Resources", "Banks", $"{bankName}.png"),
            };

            foreach (string path in possiblePaths)
            {
                string fullPath = Path.GetFullPath(path);
                System.Diagnostics.Debug.WriteLine($"Checking path for {bankName}: {fullPath} - Exists: {File.Exists(fullPath)}");

                if (File.Exists(fullPath))
                {
                    System.Diagnostics.Debug.WriteLine($"Found icon at: {fullPath}");
                    return fullPath;
                }
            }

            System.Diagnostics.Debug.WriteLine($"No icon found for {bankName}");
            return null;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            bool anyFound = false;

            pnlBankList.SuspendLayout();
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
                    if (found) anyFound = true;
                }
            }

            if (_lblNoResult != null)
            {
                _lblNoResult.Visible = !anyFound;
            }
            pnlBankList.ResumeLayout();
        }
    }
}
