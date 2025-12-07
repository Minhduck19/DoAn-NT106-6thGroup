using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DOAN.GiaoDienChinh
{
    public partial class FixCourse : Form
    {

        // Delegate để cập nhật ListView khi sửa xong
        public Action<string, string, int> OnCourseUpdated;
        private string tenLop;
        private int siSo;

        public FixCourse(string maLop)
        {
            InitializeComponent();
            txtMaLop.Text = maLop;
            txtTenLop.Text = tenLop;
            txtSiSo.Text = siSo.ToString();

            // Gán sự kiện
            btnCapNhat.Click += btnCapNhat_Click;
            btnDong.Click += (s, e) => this.Close();
        }

        public FixCourse(string maLop, string tenLop, int siSo) : this(maLop)
        {
            this.tenLop = tenLop;
            this.siSo = siSo;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string newName = txtTenLop.Text.Trim();
            string newSiSoStr = txtSiSo.Text.Trim();

            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newSiSoStr))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(newSiSoStr, out int newSiSo))
            {
                MessageBox.Show("Sĩ số phải là số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi delegate cập nhật ListView
            OnCourseUpdated?.Invoke(txtMaLop.Text, newName, newSiSo);

            MessageBox.Show("Cập nhật lớp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
