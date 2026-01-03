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
        
        private Panel _filePanel;
        private ProgressBar _progressBar;
        private Label _statusLabel;

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
            
            // Mặc định lưu vào Downloads folder
            string downloadsPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Downloads"
            );
            
            if (!Directory.Exists(downloadsPath))
            {
                Directory.CreateDirectory(downloadsPath);
            }
            
            _localFilePath = Path.Combine(downloadsPath, fileName);

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
            _filePanel = new Panel();
            _filePanel.BackColor = Color.FromArgb(240, 240, 240);
            _filePanel.BorderStyle = BorderStyle.FixedSingle;
            _filePanel.Size = new Size(250, 80);
            _filePanel.Dock = DockStyle.Fill;
            _filePanel.Cursor = Cursors.Hand;

            // Icon file
            Label iconLabel = new Label();
            iconLabel.Text = "📄";
            iconLabel.Font = new Font("Arial", 24);
            iconLabel.AutoSize = true;
            iconLabel.Location = new Point(10, 15);
            iconLabel.Cursor = Cursors.Hand;

            // Tên file
            Label fileNameLabel = new Label();
            fileNameLabel.Text = _fileName ?? string.Empty;
            fileNameLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            fileNameLabel.AutoSize = true;
            fileNameLabel.Location = new Point(60, 10);
            fileNameLabel.MaximumSize = new Size(180, 0);
            fileNameLabel.Cursor = Cursors.Hand;

            // Trạng thái (Tải về / Mở file / Đang tải)
            _statusLabel = new Label();
            _statusLabel.Font = new Font("Segoe UI", 9);
            _statusLabel.ForeColor = Color.Gray;
            _statusLabel.Location = new Point(60, 35);
            _statusLabel.Cursor = Cursors.Hand;
            _statusLabel.AutoSize = true;

            if (_isDownloading)
            {
                _statusLabel.Text = "⏳ Đang tải...";
                _statusLabel.ForeColor = Color.Orange;
            }
            else if (_fileExists)
            {
                _statusLabel.Text = "✓ Mở file";
                _statusLabel.ForeColor = Color.Green;
            }
            else
            {
                _statusLabel.Text = "⬇ Tải về";
                _statusLabel.ForeColor = Color.Blue;
            }

            // Progress bar (ẩn mặc định)
            _progressBar = new ProgressBar();
            _progressBar.Location = new Point(60, 55);
            _progressBar.Size = new Size(180, 15);
            _progressBar.Minimum = 0;
            _progressBar.Maximum = 100;
            _progressBar.Value = 0;
            _progressBar.Visible = _isDownloading;
            _progressBar.Style = ProgressBarStyle.Continuous;

            // Tích hợp rounded corners
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, 15, 15, 180, 90);
            path.AddArc(_filePanel.Width - 15, 0, 15, 15, 270, 90);
            path.AddArc(_filePanel.Width - 15, _filePanel.Height - 15, 15, 15, 0, 90);
            path.AddArc(0, _filePanel.Height - 15, 15, 15, 90, 90);
            path.CloseFigure();
            _filePanel.Region = new Region(path);

            _filePanel.Controls.Add(iconLabel);
            _filePanel.Controls.Add(fileNameLabel);
            _filePanel.Controls.Add(_statusLabel);
            _filePanel.Controls.Add(_progressBar);

            // Gắn sự kiện click cho tất cả các label
            iconLabel.Click += FileBox_Click;
            fileNameLabel.Click += FileBox_Click;
            _statusLabel.Click += FileBox_Click;
            _filePanel.Click += FileBox_Click;

            this.Controls.Add(_filePanel);
        }

        private async void FileBox_Click(object? sender, EventArgs e)
        {
            if (_isDownloading) return;

            if (_fileExists)
            {
                try
                {
                    if (_localFilePath != null && File.Exists(_localFilePath))
                    {
                        Process.Start(new ProcessStartInfo(_localFilePath) { UseShellExecute = true });
                    }
                    else
                    {
                        MessageBox.Show("File không tìm thấy trên máy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _fileExists = false;
                        UpdateUI();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi mở file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.FileName = _fileName;
                    saveFileDialog.Title = "Chọn nơi lưu file";
                    
                    // Mặc định mở ở Downloads
                    string initialDirectory = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                        "Downloads"
                    );
                    
                    if (Directory.Exists(initialDirectory))
                    {
                        saveFileDialog.InitialDirectory = initialDirectory;
                    }

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        _localFilePath = saveFileDialog.FileName;
                        await DownloadFileAsync();
                    }
                    // Nếu user cancel thì không làm gì
                }
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
                    _isDownloading = false;
                    UpdateUI();
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    // Thêm timeout 5 phút
                    client.Timeout = TimeSpan.FromSeconds(300);
                    
                    using (var response = await client.GetAsync(_fileUrl, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();
                        
                        var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                        var canReportProgress = totalBytes != -1;

                        // Tạo thư mục nếu chưa tồn tại
                        string? directoryPath = Path.GetDirectoryName(_localFilePath);
                        if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        using (var contentStream = await response.Content.ReadAsStreamAsync())
                        using (var fileStream = new FileStream(_localFilePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                        {
                            var totalRead = 0L;
                            var buffer = new byte[8192];
                            var isMoreToRead = true;

                            do
                            {
                                var read = await contentStream.ReadAsync(buffer, 0, buffer.Length);
                                if (read == 0)
                                {
                                    isMoreToRead = false;
                                }
                                else
                                {
                                    await fileStream.WriteAsync(buffer, 0, read);
                                    totalRead += read;

                                    // Cập nhật progress bar
                                    if (canReportProgress)
                                    {
                                        this.Invoke(new Action(() =>
                                        {
                                            if (_progressBar != null && !this.IsDisposed)
                                            {
                                                int progressPercentage = (int)((totalRead * 100) / totalBytes);
                                                _progressBar.Value = Math.Min(100, progressPercentage);
                                                if (_statusLabel != null)
                                                {
                                                    _statusLabel.Text = $"⏳ {progressPercentage}%";
                                                }
                                            }
                                        }));
                                    }
                                }
                            }
                            while (isMoreToRead);
                        }
                    }
                }

                _fileExists = true;
                _isDownloading = false;
                UpdateUI();

                MessageBox.Show($"Tải file thành công!\n\nĐường dẫn: {_localFilePath}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show($"Lỗi tải file (Network): {httpEx.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _isDownloading = false;
                UpdateUI();
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show($"Tải file bị hủy hoặc hết thời gian chờ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _isDownloading = false;
                UpdateUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _isDownloading = false;
                UpdateUI();
            }
        }
    }
}
