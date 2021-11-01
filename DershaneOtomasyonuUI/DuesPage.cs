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
    public partial class DuesPage : Form
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
        public DuesPage()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            DgwSet();
            dataGridView1.Columns[4].DefaultCellStyle.Format = "dd-MM-yyyy";
            dateTimePicker2.CustomFormat = "dd-MM-yyyy";
        }
        public void DgwSet()
        {
            DuesDal duesDal = new DuesDal();
            dataGridView1.DataSource = duesDal.GetAll();
            
        }

        private void DuesPage_Load(object sender, EventArgs e)
        {

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
           
            
                StudentDal studentDal = new StudentDal();
                int studentId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                Student rStudent = studentDal.GetById(studentId);  
                tbxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tbxStudentName.Text = rStudent.FirstName;
                tbxStudentSurname.Text = rStudent.LastName;
                tbxStudentId.Text = Convert.ToString(studentId);
                tbxPrice.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                tbxStudentPhone.Text = rStudent.PersonalNumber;
                tbxParentPhone.Text = rStudent.ParentNumber;
                checkBox1.Checked =Convert.ToBoolean(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();



            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TeacherList page = new TeacherList();
            this.Hide();
            page.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StudentPage page = new StudentPage();
            this.Hide();
            page.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminListPage page = new AdminListPage();
            this.Hide();
            page.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExpensePage page = new ExpensePage();
            this.Hide();
            page.ShowDialog();

        }

        private void btnStatusTrue_Click(object sender, EventArgs e)
        {
            DuesDal duesDal = new DuesDal();
            duesDal.UpdateDuesStatus(Convert.ToInt32(tbxId.Text));
            DgwSet();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DuesDal duesDal = new DuesDal();
            duesDal.DeleteById(Convert.ToInt32(tbxId.Text));
            DgwSet();
        }
    }
}
