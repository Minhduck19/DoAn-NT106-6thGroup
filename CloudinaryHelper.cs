using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class CloudinaryHelper
{
    private static Cloudinary _cloudinary;
    private const string CLOUD_NAME = "dipotmwno";
    private const string API_KEY = "987494952471117";
    private const string API_SECRET = "XKOm0cOiEQhIfB3sQvR2Mcel2No";

    static CloudinaryHelper()
    {
        Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
        _cloudinary = new Cloudinary(account);
        _cloudinary.Api.Secure = true;
    }

    // ================= UPLOAD IMAGE =================
    public static string UploadImage(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File không tồn tại!");
                return null;
            }

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(filePath),
                Folder = "WinForms_App_Uploads",
                PublicId = $"img_{DateTime.Now.Ticks}",
                Overwrite = true
            };

            var result = _cloudinary.Upload(uploadParams);
            return result.SecureUrl?.ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Upload image lỗi:\n" + ex.Message);
            return null;
        }
    }

    // ================= UPLOAD FILE =================
    public static string UploadFile(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File không tồn tại!");
                return null;
            }

            var uploadParams = new RawUploadParams
            {
                File = new FileDescription(filePath),
                Folder = "WinForms_App_Uploads",
                PublicId = $"file_{DateTime.Now.Ticks}",
                Overwrite = true
            };

            var result = _cloudinary.Upload(uploadParams);
            return result.SecureUrl?.ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Upload file lỗi:\n" + ex.Message);
            return null;
        }
    }

    // ================= DOWNLOAD FILE =================
    public static async Task DownloadFileAsync(string url, string savePath)
    {
        try
        {
            // ✅ BẮT BUỘC thêm fl_attachment
            if (!url.Contains("/fl_attachment/"))
            {
                url = url.Replace("/upload/", "/upload/fl_attachment/");
            }

            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(5);

                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        $"Download thất bại\nHTTP {(int)response.StatusCode}",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                byte[] data = await response.Content.ReadAsByteArrayAsync();
                await File.WriteAllBytesAsync(savePath, data);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tải file:\n" + ex.Message);
        }
    }
}
