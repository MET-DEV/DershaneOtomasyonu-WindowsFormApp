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
    public partial class MailToTeachers : Form
    {
        public MailToTeachers()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TeacherDal teacherDal = new TeacherDal();
            teacherDal.SendMailAllTeachers(tbxSubject.Text,tbxBody.Text);
            MessageBox.Show("Gönderildi");
            this.Hide();
        }
    }
}
