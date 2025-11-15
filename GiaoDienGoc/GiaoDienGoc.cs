using System;
using System.Windows.Forms;


namespace APP_DOAN
{
    
    public partial class GiaoDienGoc : Form
    {
        public GiaoDienGoc()
        {
            InitializeComponent();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            
            using (LoginForm loginForm = new LoginForm())
            {
               
                this.Hide();

                
                var loginResult = loginForm.ShowDialog();

                

                if (loginResult == DialogResult.OK)
                {
                   
                    string email = loginForm.UserEmail;
                    string token = loginForm.IdToken;
                    string role = loginForm.UserRole;

                    
                    if (role == "GiangVien")
                    {
                        
                        using (MainForm_GiangVien mainFormGV = new MainForm_GiangVien(email, token))
                        {
                            mainFormGV.ShowDialog();
                        }
                    }
                    else if (role == "SinhVien")
                    {
                       
                        using (MainForm mainFormSV = new MainForm(email, token))
                        {
                            mainFormSV.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vai trò không xác định. Vui lòng liên hệ quản trị viên.", "Lỗi Vai Trò", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    
                    this.Close();
                }
                else
                {
                    
                    this.Show();
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
            this.Hide();

            using (RegisterForm registerForm = new RegisterForm())
            {
               
                registerForm.ShowDialog();
            }

            
            this.Show();
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            MessageBox.Show("Chức năng đang được phát triển.");
        }

        private void GiaoDienGoc_Load(object sender, EventArgs e)
        {
            
        }

        
    }
}