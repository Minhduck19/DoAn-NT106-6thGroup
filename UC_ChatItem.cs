using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace APP_DOAN
{
    public partial class UC_ChatItem : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public string MassageId { get; set; }
        public UC_ChatItem()
        {
            InitializeComponent();
        }

        public void SetMessage(string text, bool isMe, string status)
{
    // 1. XỬ LÝ NỘI DUNG VÀ XUỐNG DÒNG
    lblMessage.Text = text;

    // Ép Label không được rộng quá 60% khung chat
    int maxWidth = (int)(this.Width * 0.6);
    lblMessage.MaximumSize = new Size(maxWidth, 0);
    lblMessage.AutoSize = true; // Đảm bảo Label tự co giãn

    // 2. TÍNH TOÁN LẠI KÍCH THƯỚC BONG BÓNG (BUBBLE)
    int padding = 10;
    panelBubble.Width = lblMessage.Width + (padding * 2);
    panelBubble.Height = lblMessage.Height + (padding * 2);
    
    // Đặt Label nằm giữa bong bóng
    lblMessage.Location = new Point(padding, padding);

    // 3. XỬ LÝ ALIGNMENT & STATUS
    if (isMe)
    {
        // --- TIN NHẮN CỦA MÌNH (BÊN PHẢI) ---

        // Vị trí bong bóng: Căn phải
        panelBubble.Location = new Point(this.Width - panelBubble.Width - 10, 5);
        
        // Màu sắc bong bóng
        panelBubble.FillColor = Color.FromArgb(0, 118, 212); // Xanh Win 10
        lblMessage.ForeColor = Color.White;

        // --- FIX LỖI STATUS Ở ĐÂY ---
        // Nếu lblStatus chưa có (null), ta tự tạo nó bằng code luôn cho chắc
        if (lblStatus == null)
        {
            lblStatus = new Label();
            lblStatus.Name = "lblStatus";
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 8, FontStyle.Italic); // Chữ nhỏ, nghiêng
            this.Controls.Add(lblStatus); // Thêm vào UserControl
        }

        lblStatus.Visible = true;
        lblStatus.Text = (status == "read") ? "Đã xem" : "Đã gửi";
        lblStatus.ForeColor = Color.Gray; // Màu xám cho dễ nhìn trên nền trắng
        
        // Cực kỳ quan trọng: BringToFront để chắc chắn nó không bị bong bóng đè
        lblStatus.BringToFront(); 

        // Tính toán vị trí Status: Nằm dưới bong bóng, căn phải thẳng hàng với bong bóng
        // Dùng Application.DoEvents() hoặc tính toán kỹ vì AutoSize cần thời gian cập nhật Width
        lblStatus.Location = new Point(this.Width - lblStatus.Width - 10, panelBubble.Bottom + 2);
    }
    else
    {
        // --- TIN NHẮN NGƯỜI KHÁC (BÊN TRÁI) ---

        panelBubble.Location = new Point(10, 5);
        panelBubble.FillColor = Color.FromArgb(229, 229, 234); // Xám
        lblMessage.ForeColor = Color.Black;

        // Ẩn status nếu là tin nhắn người khác
        if (lblStatus != null) lblStatus.Visible = false;
    }

    // 4. TÍNH TOÁN ĐỘ CAO CHO TOÀN BỘ ITEM
    // Nếu là Me thì cộng thêm chiều cao của Status, ngược lại thì thôi
    int statusHeight = (isMe && lblStatus != null && lblStatus.Visible) ? lblStatus.Height + 5 : 0;
    
    // Cập nhật chiều cao UserControl
    this.Height = panelBubble.Bottom + statusHeight + 10; // Dùng panelBubble.Bottom cho chuẩn
}

        // Fix lỗi bong bóng không resize khi form thay đổi kích thước
        private void UC_ChatItem_Resize(object sender, EventArgs e)
        {
            // Gọi lại logic để tính toán lại vị trí nếu cần (nâng cao)
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }
    }
}