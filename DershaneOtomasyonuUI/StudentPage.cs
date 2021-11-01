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
    public partial class StudentPage : Form
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
        public StudentPage()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            DgwSet();
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            


        }
        public void DgwSet()
        {
            StudentDal studentDal = new StudentDal();
            dataGridView1.DataSource = studentDal.GetAll();
            
        }

        private void StudentPage_Load(object sender, EventArgs e)
        {
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            tbxImagePath.Text = openFileDialog1.FileName;
            pictureBox1.ImageLocation = tbxImagePath.Text;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbxTcNo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbxlastName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbxMail.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tbxPerNum.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            tbxDadNum.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            tbxImagePath.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dateTimePicker1.Text= dataGridView1.CurrentRow.Cells[8].Value.ToString();
            pictureBox1.ImageLocation = tbxImagePath.Text;
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            StudentDal studentDal = new StudentDal();
            studentDal.Update(new Student() {Id=int.Parse(tbxId.Text),IdentityNumber=tbxTcNo.Text,FirstName=tbxName.Text,Email=tbxMail.Text,ImagePath=tbxImagePath.Text,LastName=tbxlastName.Text,ParentNumber=tbxDadNum.Text,PersonalNumber=tbxPerNum.Text});
            DgwSet();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StudentDal studentDal = new StudentDal();
            studentDal.Add(new Student() { IdentityNumber = tbxTcNo.Text, FirstName = tbxName.Text, Email = tbxMail.Text, ImagePath = tbxImagePath.Text, LastName = tbxlastName.Text, ParentNumber = tbxDadNum.Text, PersonalNumber = tbxPerNum.Text,RegisterDate=DateTime.Now });
            Student student=studentDal.GetIdByMail(tbxMail.Text);
            DuesDal duesDal = new DuesDal();
            duesDal.CreateDues(student,Convert.ToDecimal(tbxPrice.Text));
            DgwSet();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            this.Hide();
            homePage.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            StudentDal studentDal = new StudentDal();
            studentDal.Delete(new Student() {Id=int.Parse(tbxId.Text) });
            DuesDal duesDal = new DuesDal();
            duesDal.Delete(int.Parse(tbxId.Text));
            DgwSet();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TeacherList page = new TeacherList();
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
