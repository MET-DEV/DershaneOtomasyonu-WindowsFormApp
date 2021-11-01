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
    public partial class TeacherList : Form
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
        public TeacherList()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
          
            DgwSet();
            
            
        }
        public void DgwSet()
        {
            TeacherDal teacherDal = new TeacherDal();
            dataGridView1.DataSource = teacherDal.GetAll();
        }

        private void TeacherList_Load(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            tbxImagePath.Text = openFileDialog1.FileName;
            pictureBox1.ImageLocation = tbxImagePath.Text;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbxFirstName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxLastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbxPhone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbxEmail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tbxLesson.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            tbxSalary.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            tbxImagePath.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            pictureBox1.ImageLocation = tbxImagePath.Text;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            TeacherDal teacherDal = new TeacherDal();
            teacherDal.Add(new Teacher() { FirstName=tbxFirstName.Text,LastName=tbxLastName.Text,Email=tbxEmail.Text,ImagePath=tbxImagePath.Text,LessonName=tbxLesson.Text,PhoneNumber=tbxPhone.Text,Salary=decimal.Parse(tbxSalary.Text)});
            DgwSet();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TeacherDal teacherDal = new TeacherDal();
            teacherDal.Delete(new Teacher() { Id=int.Parse(tbxId.Text)});
            DgwSet();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            TeacherDal teacherDal = new TeacherDal();
            teacherDal.Update(new Teacher (){Id=int.Parse(tbxId.Text),Email=tbxEmail.Text,FirstName=tbxFirstName.Text,ImagePath=tbxImagePath.Text,LastName=tbxLastName.Text,LessonName=tbxLesson.Text,PhoneNumber=tbxPhone.Text,Salary=decimal.Parse(tbxSalary.Text) });
            DgwSet();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StudentPage page = new StudentPage();
            this.Hide();
            page.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminListPage page = new AdminListPage();
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
    }
}
