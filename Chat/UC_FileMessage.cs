using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

namespace APP_DOAN
{
    public partial class UC_FileMessage : UserControl
    {
        private string? _fileUrl;
        private string? _fileName;
        private string? _localFilePath;
        private bool _isDownloading = false;
        private bool _fileExists = false;

        public UC_FileMessage()
        {
            InitializeComponent();
            this.Cursor = Cursors.Hand;
            this.Click += FileBox_Click!;
        }

        public void SetFileData(string? fileUrl, string? fileName)
        {
            if (string.IsNullOrEmpty(fileUrl) || string.IsNullOrEmpty(fileName))
            {
                this.Visible = false;
                return;
            }

            _fileUrl = fileUrl;
            _fileName = fileName;
            _localFilePath = Path.Combine(Path.GetTempPath(), fileName);

            // Kiểm tra file đã tồn tại hay chưa
            _fileExists = File.Exists(_localFilePath);

            this.Visible = true;
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(UpdateUI));
                return;
            }

            // Xóa tất cả controls cũ
            this.Controls.Clear();

            // Tạo panel chứa file
            Panel filePanel = new Panel();
            filePanel.BackColor = Color.FromArgb(240, 240, 240);
            filePanel.BorderStyle = BorderStyle.FixedSingle;
            filePanel.Size = new Size(250, 80);
            filePanel.Dock = DockStyle.Fill;

            // Icon file
            Label iconLabel = new Label();
            iconLabel.Text = "📄";
            iconLabel.Font = new Font("Arial", 24);
            iconLabel.AutoSize = true;
            iconLabel.Location = new Point(10, 15);

            // Tên file
            Label fileNameLabel = new Label();
            fileNameLabel.Text = _fileName ?? string.Empty;
            fileNameLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            fileNameLabel.AutoSize = true;
            fileNameLabel.Location = new Point(60, 10);
            fileNameLabel.MaximumSize = new Size(180, 0);

            // Trạng thái (Tải về / Mở file)
            Label statusLabel = new Label();
            statusLabel.Font = new Font("Segoe UI", 9);
            statusLabel.ForeColor = Color.Gray;
            statusLabel.Location = new Point(60, 35);

            if (_fileExists)
            {
                statusLabel.Text = "✓ Mở file";
                statusLabel.ForeColor = Color.Green;
            }
            else
            {
                statusLabel.Text = "⬇ Tải về";
                statusLabel.ForeColor = Color.Blue;
            }

            // Tích hợp rounded corners
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, 15, 15, 180, 90);
            path.AddArc(filePanel.Width - 15, 0, 15, 15, 270, 90);
            path.AddArc(filePanel.Width - 15, filePanel.Height - 15, 15, 15, 0, 90);
            path.AddArc(0, filePanel.Height - 15, 15, 15, 90, 90);
            path.CloseFigure();
            filePanel.Region = new Region(path);

            filePanel.Controls.Add(iconLabel);
            filePanel.Controls.Add(fileNameLabel);
            filePanel.Controls.Add(statusLabel);

            this.Controls.Add(filePanel);
        }

        private async void FileBox_Click(object? sender, EventArgs e)
        {
            if (_isDownloading) return;

            if (_fileExists)
            {
                // Mở file nếu đã tồn tại
                try
                {
                    if (_localFilePath != null)
                    {
                        Process.Start(new ProcessStartInfo(_localFilePath) { UseShellExecute = true });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi mở file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Tải về file
                await DownloadFileAsync();
            }
        }

        private async System.Threading.Tasks.Task DownloadFileAsync()
        {
            try
            {
                _isDownloading = true;
                UpdateUI();

                if (string.IsNullOrEmpty(_fileUrl) || string.IsNullOrEmpty(_localFilePath))
                {
                    MessageBox.Show("URL hoặc đường dẫn file không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    byte[] fileBytes = await client.GetByteArrayAsync(_fileUrl);
                    File.WriteAllBytes(_localFilePath, fileBytes);
                }

                _fileExists = true;
                _isDownloading = false;
                UpdateUI();

                MessageBox.Show("Tải file thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _isDownloading = false;
            }
        }
    }
}
