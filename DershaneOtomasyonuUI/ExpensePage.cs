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
    public partial class ExpensePage : Form
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
        public ExpensePage()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            SetDgw();
            dataGridView1.Columns[3].DefaultCellStyle.Format = "dd-MM-yyyy";
            dateTimePicker2.CustomFormat = "dd-MM-yyyy";

        }
        public void SetDgw()
        {
            ExpenseDal expense = new ExpenseDal();
            dataGridView1.DataSource = expense.GetAll();
        }

        private void ExpensePage_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage page = new HomePage();
            this.Hide();
            page.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbxEpensePlace.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxPrice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            
        }
    }
}
