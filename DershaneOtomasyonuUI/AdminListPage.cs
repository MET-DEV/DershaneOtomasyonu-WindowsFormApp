using DataAccess;
using EntityLayer.Concrete;
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
    public partial class AdminListPage : Form
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
        public AdminListPage()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0,0,Width,Height,30,30));
            
        

            DgwSet();
            
        }
        public void DgwSet()
        {
            AdminDal adminDal = new AdminDal();
            dataGridView1.DataSource = adminDal.GetAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage page = new HomePage();
            this.Hide();
            page.ShowDialog();
        }

        private void AdminListPage_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbxUserName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxEmail.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbxPassword.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdminDal adminDal = new AdminDal();

            adminDal.Add(new Admin() {UserName=tbxUserName.Text,Password=tbxPassword.Text });
            DgwSet();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AdminDal adminDal = new AdminDal();
            adminDal.Update(new Admin() { Id=Convert.ToInt32(tbxId.Text),Password=tbxPassword.Text,UserName=tbxUserName.Text});
            DgwSet();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AdminDal adminDal = new AdminDal();
            adminDal.Delete(new Admin() { Id=Convert.ToInt32(tbxId.Text)});
            DgwSet();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TeacherList teacher = new TeacherList();
            this.Hide();
            teacher.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            StudentPage page = new StudentPage();
            this.Hide();
            page.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExpensePage page = new ExpensePage();
            this.Hide();
            page.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DuesPage page = new DuesPage();
            this.Hide();
            page.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MailToStudents studentMail = new MailToStudents();
            studentMail.ShowDialog();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            MailToTeachers teacherMail = new MailToTeachers();
            teacherMail.ShowDialog();

        }
    }
}
