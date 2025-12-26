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
    public partial class Assignment : Form
    {
        public Assignment()
        {
            InitializeComponent();
        }
        private void Assignment_Load(object sender, EventArgs e)
        {
            lvCourses.View = View.Details;
            lvCourses.FullRowSelect = true;
            lvCourses.GridLines = true;

            lvCourses.Columns.Clear();
            lvCourses.Columns.Add("Lớp học", 150);
            lvCourses.Columns.Add("Tên file", 200);
            lvCourses.Columns.Add("Link bài nộp", 300);
            lvCourses.Columns.Add("Thời gian nộp", 150);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
