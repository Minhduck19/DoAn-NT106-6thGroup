using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APP_DOAN.Services
{
    public static class FirebaseApi
    {
        public static string CurrentUid { get; set; }
        // 1. Cấu hình cơ bản
        // Thay địa chỉ Database của bạn vào đây (đảm bảo kết thúc bằng dấu /)
        public static string BaseUrl = "https://nt106-minhduc-default-rtdb.firebaseio.com/";

        // Token này sẽ được gán giá trị sau khi người dùng đăng nhập thành công
        public static string IdToken { get; set; } = string.Empty;

        // HttpClient nên dùng static để tối ưu hiệu suất kết nối
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Hàm bổ trợ để xây dựng URL đúng cấu trúc REST API của Firebase
        /// </summary>
        private static string BuildUrl(string path)
        {
            // Loại bỏ dấu "/" ở đầu path nếu có để tránh double slash //
            if (path.StartsWith("/")) path = path.Substring(1);

            // Cấu trúc: BaseUrl + path + .json?auth=Token
            return $"{BaseUrl}{path}.json?auth={IdToken}";
        }

        /// <summary>
        /// Lấy dữ liệu và chuyển đổi sang Object (GET)
        /// </summary>
        public static async Task<T?> Get<T>(string path)
        {
            try
            {
                string url = BuildUrl(path);
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode) return default;

                string json = await response.Content.ReadAsStringAsync();

                // Firebase trả về chuỗi "null" nếu không tìm thấy dữ liệu
                if (string.IsNullOrEmpty(json) || json == "null") return default;

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception)
            {
                return default;
            }
        }

        /// <summary>
        /// Lấy dữ liệu dạng chuỗi thô (JSON String)
        /// </summary>
        public static async Task<string> GetRaw(string path)
        {
            string url = BuildUrl(path);
            return await client.GetStringAsync(url);
        }

        /// <summary>
        /// Ghi đè toàn bộ dữ liệu tại đường dẫn chỉ định (PUT)
        /// </summary>
        public static async Task<bool> Put<T>(string path, T data)
        {
            string url = BuildUrl(path);
            string json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(url, content);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Thêm dữ liệu vào một danh sách, Firebase tự sinh ID (POST)
        /// </summary>
        public static async Task<bool> Post<T>(string path, T data)
        {
            string url = BuildUrl(path);
            string json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Cập nhật một vài trường dữ liệu mà không làm mất dữ liệu cũ (PATCH)
        /// </summary>
        public static async Task<bool> Patch<T>(string path, T data)
        {
            string url = BuildUrl(path);
            string json = JsonConvert.SerializeObject(data);

            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, url)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(request);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Xóa dữ liệu tại đường dẫn (DELETE)
        /// </summary>
        public static async Task<bool> Delete(string path)
        {
            string url = BuildUrl(path);
            var response = await client.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
    }
}