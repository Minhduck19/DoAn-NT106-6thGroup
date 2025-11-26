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
    public partial class CreateCourse : Form
    {

        // Sự kiện trả dữ liệu lớp về MainForm
        public event Action<string, string, int> OnCourseCreated;
        public CreateCourse()
        {
            InitializeComponent();
        }


        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();
            int siSo = int.Parse(txtSiSo.Text.Trim());

            if (string.IsNullOrEmpty(maLop) || string.IsNullOrEmpty(tenLop))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Gọi sự kiện gửi dữ liệu về Form cha
            OnCourseCreated?.Invoke(maLop, tenLop, siSo);

            MessageBox.Show("Tạo lớp thành công!");
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
