using DataAccess;
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
    public partial class HomePage : Form
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
        public HomePage()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            StudentDal studentDal = new StudentDal();
            TeacherDal teacherDal = new TeacherDal();
            DuesDal duesDal = new DuesDal();
            lblStudentCount.Text = studentDal.GetStudentCount().ToString();
            lblhocsys.Text = teacherDal.GetTeacherCount().ToString();
            lblglr.Text = duesDal.GetMounthlyMoney().ToString()+" TL";


        }

        

        private void HomePage_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentPage page = new StudentPage();
            this.Hide();
            page.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExpensePage page = new ExpensePage();
            this.Hide();
            page.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminListPage page = new AdminListPage();
            this.Hide();
            page.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DuesPage page = new DuesPage();
            this.Hide();
            page.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            TeacherList page = new TeacherList();
            this.Hide();
            page.ShowDialog();
        }
    }
}
