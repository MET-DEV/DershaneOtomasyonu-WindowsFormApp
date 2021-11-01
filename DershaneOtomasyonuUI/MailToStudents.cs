using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DershaneOtomasyonuUI
{
    public partial class MailToStudents : Form
    {
        public MailToStudents()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StudentDal studentDal = new StudentDal();
            studentDal.SendMailAllStudents(tbxSubject.Text, tbxBody.Text);
            MessageBox.Show("Gönderildi");
            this.Hide();
        }
    }
}
