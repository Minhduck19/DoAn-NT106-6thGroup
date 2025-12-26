using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;

namespace APP_DOAN
{
    public partial class ImageViewerForm : Form
    {
        private string _imageUrl;

        public ImageViewerForm(string imageUrl)
        {
            InitializeComponent();
            _imageUrl = imageUrl;
            
            // *** FIX: Cấu hình form full-screen ***
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Black;
            
            // *** FIX: Load ảnh vào PictureBox ***
            LoadImage();
        }

        // *** FIX: Hàm load ảnh ***
        private void LoadImage()
        {
            try
            {
                if (string.IsNullOrEmpty(_imageUrl))
                {
                    MessageBox.Show("URL ảnh không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Debug.WriteLine($"Loading image from: {_imageUrl}");
                picViewer.LoadAsync(_imageUrl);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading image: {ex.Message}");
                MessageBox.Show($"Lỗi tải ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_imageUrl))
                {
                    MessageBox.Show("URL ảnh không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                save.FileName = $"image_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(_imageUrl, save.FileName);
                        MessageBox.Show($"Tải về thành công!\n{save.FileName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải về: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnForward_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_imageUrl))
                {
                    MessageBox.Show("URL ảnh không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Clipboard.SetText(_imageUrl);
                MessageBox.Show("Đã copy link ảnh vào clipboard!\nBạn có thể dán vào bất kỳ đâu.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
