using System;
using System.Drawing;
using System.Windows.Forms;

namespace APP_DOAN
{
    public partial class UC_ChatItem : UserControl
    {
        public UC_ChatItem()
        {
            InitializeComponent();
        }

        public void SetMessage(string message, bool isSender)
        {
            // 1. Gán nội dung tin nhắn
            lblMessage.Text = message;

            // 2. Set độ rộng TỐI ĐA cho Label (để nó tự xuống dòng)
            //    (Chúng ta sẽ set nó bằng 70% chiều rộng của control cha)
            lblMessage.MaximumSize = new Size((int)(this.Width * 0.7), 0);

            // 3. Yêu cầu Label tự tính toán lại kích thước
            //    (Nó sẽ dựa vào MaxSize ở trên để xuống dòng nếu cần)
            lblMessage.Size = lblMessage.GetPreferredSize(lblMessage.MaximumSize);

            // 4. Set kích thước cho bong bóng (panelBubble)
            panelBubble.Size = new Size(lblMessage.Width + 20, lblMessage.Height + 15);

            // 5. Set chiều cao TỔNG THỂ của cả cái UserControl
            this.Height = panelBubble.Height + 10;

            if (isSender)
            {
                // --- NẾU LÀ BẠN (Người gửi) ---
                // Màu sắc
                panelBubble.FillColor = Color.FromArgb(0, 118, 221); // Màu xanh
                lblMessage.ForeColor = Color.White;
                // Neo bong bóng sang PHẢI
                panelBubble.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            }
            else
            {
                // --- NẾU LÀ HỌ (Người nhận) ---
                // Màu sắc
                panelBubble.FillColor = Color.FromArgb(230, 230, 230); // Màu xám
                lblMessage.ForeColor = Color.Black;
                // Neo bong bóng sang TRÁI
                panelBubble.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            }
        }
    }
}