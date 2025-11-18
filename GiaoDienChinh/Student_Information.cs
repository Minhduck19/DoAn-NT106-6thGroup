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
    public partial class Student_Information : Form
    {
        public Student_Information(string loggedInEmail)
        {
            InitializeComponent();
        }

        public Student_Information(string loggedInEmail, string userRole) : this(loggedInEmail)
        {
        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void grpAcademicInfo_Enter(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
