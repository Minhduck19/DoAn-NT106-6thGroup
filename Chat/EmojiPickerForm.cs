using System;
using System.Drawing;
using System.Windows.Forms;

namespace APP_DOAN
{
    public partial class EmojiPickerForm : Form
    {
        private FlowLayoutPanel flowEmojis; // Keep only this field

        public string? SelectedEmoji { get; private set; }
        public event EventHandler<string>? EmojiSelected;

        public EmojiPickerForm()
        {
            InitializeComponent();
            CreateEmojiPanel();
            LoadEmojis();
        }

        private void CreateEmojiPanel()
        {
            flowEmojis = new FlowLayoutPanel();
            flowEmojis.AutoScroll = true;
            flowEmojis.Dock = DockStyle.Fill;
            flowEmojis.Padding = new Padding(5);
            flowEmojis.WrapContents = true;
            flowEmojis.BackColor = Color.White;
            flowEmojis.Name = "flowEmojis";

            this.Controls.Add(flowEmojis);
        }

        private void LoadEmojis()
        {
            // Danh sách emoji phổ biến (150+ emoji)
            string[] emojisData = new string[]
            {
                // Cảm xúc (Smileys & Emotion)
                "😀", "😁", "😂", "🤣", "😃", "😄", "😅", "😆", "😉", "😊",
                "😇", "🙂", "🙃", "😌", "😍", "🥰", "😘", "😗", "😚", "😙",
                "🥲", "😋", "😛", "😜", "🤪", "😑", "😐", "😶", "🤫",
                "🤭", "🤔", "🤐", "🤨", "😏", "😒", "🙁", "😕", "😲", "😞",
                "😖", "😢", "😭", "😤", "😠", "😡", "🤬", "😈", "👿", "💀",
                "☠️", "💩", "🤡", "👹", "👺", "👻", "👽", "👾", "🤖", "😺",
                
                // Mèo (Cat Face)
                "😸", "😹", "😻", "😼", "😽", "🙀", "😿", "😾",
                
                // Trái tim (Hearts)
                "❤️", "🧡", "💛", "💚", "💙", "💜", "🖤", "🤍", "🤎", "💔",
                "💕", "💞", "💓", "💗", "💖", "💘", "💝", "💟",
                
                // Tay (Hand Gestures)
                "👋", "🤚", "🖐️", "✋", "🖖", "👌", "🤌", "🤏", "✌️", "🤞",
                "🤟", "🤘", "🤙", "👍", "👎", "✊", "👊", "🤛", "🤜",
                "👏", "🙌", "👐", "🤲", "🤝",
                
                // Con vật (Animals)
                "🐶", "🐱", "🐭", "🐹", "🐰", "🦊", "🐻", "🐼", "🐨", "🐯",
                "🦁", "🐮", "🐷", "🐸", "🐵", "🙈", "🙉", "🙊", "🐒", "🐔",
                "🐧", "🐦", "🐤", "🦆", "🦅", "🦉", "🦇", "🐺", "🐗", "🐴",
                
                // Thức ăn (Food & Drink)
                "🍏", "🍎", "🍐", "🍊", "🍋", "🍌", "🍉", "🍇", "🍓", "🍈",
                "🍒", "🍑", "🥭", "🍍", "🥥", "🥑", "🍆", "🍅", "🌶️", "🌽",
                "🍠", "🥔", "🍞", "🥐", "🥯", "🍖", "🍗", "🥩", "🍔", "🍟",
                "🍕", "🌭", "🥪", "🌮", "🌯", "🥙", "🍳", "🥘", "🍲",
                "🥣", "🥗", "🍿", "🍱", "🍘", "🍙", "🍚",
                "🍛", "🍜", "🍝", "🍢", "🍣", "🍤", "🍥",
                "🍯", "🍦", "🍧", "🍨", "🍰", "🎂", "🍮", "🍭", "🍬", "🍫",
                "🍩", "🍪", "🌰", "🥜", "☕", "🍵", "🍶", "🍾", "🍷",
                "🍸", "🍹", "🍺", "🍻", "🥂",
                
                // Sự kiện (Celebration)
                "🎉", "🎊", "🎈", "🎁", "🎀", "🎂", "🎄", "🎆", "🎇", "🧨",
                "✨", "🎃", "🎅", "🤶", "🎤", "🎧", "🎬", "🎮", "🎯", "🎲",
                "🎰", "🎳", "⚽", "🏀", "🏈", "⚾", "🥎", "🎾", "🏐", "🏉",
                "🥏", "🎣", "🎽", "🎿", "⛷️", "🏂",
                
                // Đặc biệt
                "🔥", "⭐", "✨", "⚡", "☄️", "💥", "🌟", "🎯", "👑", "💎"
            };

            if (flowEmojis == null) return;

            foreach (string emoji in emojisData)
            {
                Label lblEmoji = new Label();
                lblEmoji.Text = emoji;
                lblEmoji.Font = new Font("Segoe UI Emoji", 22, FontStyle.Regular);
                lblEmoji.Size = new Size(48, 48);
                lblEmoji.TextAlign = ContentAlignment.MiddleCenter;
                lblEmoji.Cursor = Cursors.Hand;
                lblEmoji.BackColor = Color.White;
                lblEmoji.BorderStyle = BorderStyle.None;
                lblEmoji.Margin = new Padding(2);
                lblEmoji.Tag = emoji;
                
                // Hover effect
                lblEmoji.MouseEnter += (s, e) =>
                {
                    lblEmoji.BackColor = Color.FromArgb(240, 240, 240);
                };
                
                lblEmoji.MouseLeave += (s, e) =>
                {
                    lblEmoji.BackColor = Color.White;
                };

                // Click để chọn emoji
                lblEmoji.Click += (s, e) =>
                {
                    SelectedEmoji = emoji;
                    EmojiSelected?.Invoke(this, emoji);
                    this.Close();
                };

                flowEmojis.Controls.Add(lblEmoji);
            }
        }
    }
}
