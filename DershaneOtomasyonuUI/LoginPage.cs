using DataAccess;
using EntityLayer.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DershaneOtomasyonuUI
{
    public partial class LoginPage : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,    
           int nTopRect,      
           int nRightRect,    
           int nBottomRect,   
           int nWidthEllipse, 
           int nHeightEllipse 
       );
        public LoginPage()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginDTO loginDTO = new LoginDTO();
            loginDTO.UserName = tbxUserName.Text;
            loginDTO.Password = tbxPassword.Text;
            AdminDal adminDal = new AdminDal();
            bool result=adminDal.CheckUser(loginDTO);
            if (result)
            {
                MessageBox.Show("Giriş Başarılı");
                HomePage homePage = new HomePage();
                this.Hide();
                homePage.ShowDialog();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da parola hatalı.");
            }
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasswordPage page = new ForgotPasswordPage();
            page.ShowDialog();
        }
    }
}
