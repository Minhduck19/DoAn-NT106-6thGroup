using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.IO;
using System.Windows.Forms;

public class CloudinaryHelper
{
    private static Cloudinary _cloudinary;
    private const string CLOUD_NAME = "dipotmwno";
    private const string API_KEY = "987494952471117";
    private const string API_SECRET = "XKOm0cOiEQhIfB3sQvR2Mcel2No";

    // Constructor tĩnh để khởi tạo kết nối 1 lần duy nhất
    static CloudinaryHelper()
    {
        Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
        _cloudinary = new Cloudinary(account);
        _cloudinary.Api.Secure = true; // Luôn dùng HTTPS cho an toàn
    }

    /// <summary>
    /// Upload ảnh từ đường dẫn file trên máy tính
    /// </summary>
    /// <param name="filePath">Đường dẫn file ảnh (C:\Users\Img.jpg)</param>
    /// <returns>Trả về URL ảnh online. Trả về null nếu lỗi.</returns>
    public static string UploadImage(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(filePath),
                Folder = "WinForms_App_Uploads", // Tên thư mục trên Cloudinary
                PublicId = $"img_{DateTime.Now.Ticks}", // Đặt tên file unique để không bị đè
                Overwrite = true
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadResult.SecureUrl.ToString();
            }
            else
            {
                MessageBox.Show($"Lỗi từ Server: {uploadResult.Error.Message}", "Lỗi Upload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Có lỗi ngoại lệ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }

    /// <summary>
    /// Upload file từ đường dẫn file trên máy tính (hỗ trợ PDF, Word, Excel, etc.)
    /// </summary>
    /// <param name="filePath">Đường dẫn file (C:\Users\Document.pdf)</param>
    /// <returns>Trả về URL file online. Trả về null nếu lỗi.</returns>
    public static string UploadFile(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var uploadParams = new RawUploadParams()
            {
                File = new FileDescription(filePath),
                Folder = "WinForms_App_Uploads",
                PublicId = $"file_{DateTime.Now.Ticks}",
                Overwrite = true
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadResult.SecureUrl.ToString();
            }
            else
            {
                MessageBox.Show($"Lỗi từ Server: {uploadResult.Error.Message}", "Lỗi Upload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Có lỗi ngoại lệ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }
}