using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using Guna.UI2.WinForms;
using System.IO;

namespace APP_DOAN.GiaoDienChinh
{
        public partial class Post_Assignment : Form
        {
            private readonly FirebaseClient firebaseClient;
            private readonly string courseId;     // ID lớp học
            private readonly string teacherUid;   // UID giảng viên

            private const long MAX_FILE_SIZE = 50L * 1024 * 1024; // 50MB

            public Post_Assignment(
                FirebaseClient firebaseClient,
                string courseId,
                string teacherUid)
            {
                InitializeComponent();
                this.firebaseClient = firebaseClient;
                this.courseId = courseId;
                this.teacherUid = teacherUid;
            }

            // ================= CHỌN FILE =================
            private void btnBrowse_Click(object sender, EventArgs e)
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.Filter =
                        "Ảnh (*.jpg;*.png)|*.jpg;*.png|" +
                        "Video (*.mp4)|*.mp4|" +
                        "Tài liệu (*.pdf;*.docx;*.zip)|*.pdf;*.docx;*.zip|" +
                        "Tất cả tệp (*.*)|*.*";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo fileInfo = new FileInfo(dialog.FileName);

                        if (fileInfo.Length > MAX_FILE_SIZE)
                        {
                            MessageBox.Show("Tệp vượt quá 50MB");
                            return;
                        }

                        txtFilePath.Text = dialog.FileName;
                    }
                }
            }

            // ================= ĐĂNG BÀI =================
            private async void btnPost_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Vui lòng nhập tiêu đề bài tập");
                    return;
                }

                string fileUrl = null;
                string fileName = null;
                string fileType = null;

                try
                {
                    Cursor = Cursors.WaitCursor;

                    // Nếu có file đính kèm
                    if (!string.IsNullOrEmpty(txtFilePath.Text) &&
                        File.Exists(txtFilePath.Text))
                    {
                        fileUrl = await Task.Run(() =>
                            CloudinaryHelper.UploadFile(txtFilePath.Text)
                        );

                        fileName = Path.GetFileName(txtFilePath.Text);
                        fileType = GetFileType(fileName);
                    }

                    // Lưu Firebase
                    await firebaseClient
                        .Child("Assignments")
                        .Child(courseId)
                        .PostAsync(new
                        {
                            TieuDe = txtTitle.Text,
                            NoiDung = txtDescription.Text,
                            TenFile = fileName,
                            FileUrl = fileUrl,
                            LoaiFile = fileType, // image / video / raw
                            GiangVienUid = teacherUid,
                            ThoiGianDang = DateTime.Now
                        });

                    Cursor = Cursors.Default;

                    MessageBox.Show("Đăng bài tập thành công 🎉");
                    this.Close();
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Lỗi đăng bài: " + ex.Message);
                }
            }

            // ================= PHÂN LOẠI FILE =================
            private string GetFileType(string fileName)
            {
                string ext = Path.GetExtension(fileName).ToLower();

                if (ext == ".jpg" || ext == ".png")
                    return "image";
                if (ext == ".mp4")
                    return "video";

                return "raw";
            }
        }
    }
