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
                panelBubble.FillColor = Color.FromArgb(0, 118, 221);
                lblMessage.ForeColor = Color.White;
                panelBubble.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                int xPosition = this.Width - panelBubble.Width - 10;
                panelBubble.Location = new Point(xPosition, 5);
            }
            else
            {
                panelBubble.FillColor = Color.FromArgb(230, 230, 230);
                lblMessage.ForeColor = Color.Black;
                panelBubble.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                panelBubble.Location = new Point(10, 5);
            }

        }

        private void panelBubble_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}