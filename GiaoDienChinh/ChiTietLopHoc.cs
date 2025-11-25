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
    public partial class ChiTietLopHoc : Form
    {
        private Course _course;
        public ChiTietLopHoc(Course course)
        {
            InitializeComponent();
            _course = course;
        }

        private void ChiTietLopHoc_Load(object sender, EventArgs e)
        {
            lblCourseName.Text = _course.Name;
            lblInstructor.Text = _course.Instructor;
            lblCourseId.Text = _course.Id;
        }
    }
}
