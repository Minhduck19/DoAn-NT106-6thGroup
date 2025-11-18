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
    
    public partial class Teacher_Information : Form
    {
        private GiangVienData _data;
        public Teacher_Information(GiangVienData data)
        {
            InitializeComponent();
            _data = data;

            // Hiển thị dữ liệu lên các textbox
            txtFullName.Text = _data.HoTen;
            txtStudentID.Text = _data.MaGiangVien;
            txtBirthday.Text = _data.NgaySinh;
            txtFaculty.Text = _data.Khoa;
            txtClass.Text = _data.MonHoc;
            txtBang.Text = _data.Bang;
            txtEmail.Text = _data.Email;
        }

        public Teacher_Information(string loggedInEmail, string idToken)
        {
            InitializeComponent();
        }


        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSex_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBirthday_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFaculty_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBang_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
