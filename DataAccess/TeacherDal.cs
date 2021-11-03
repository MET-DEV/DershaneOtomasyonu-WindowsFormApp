using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TeacherDal
    {
        SqlConnection connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;initial catalog=DershaneDb;Trusted_Connection=true");
        public List<Teacher> GetAll()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("Select * from Teachers", connection);
            List<Teacher> teachers = new List<Teacher>();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Teacher teacher = new Teacher();
                teacher.Id = Convert.ToInt32(reader["Id"]);
                teacher.FirstName = Convert.ToString(reader["FirstName"]);
                teacher.LastName = Convert.ToString(reader["LastName"]);
                teacher.LessonName = Convert.ToString(reader["LessonName"]);
                teacher.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                teacher.Salary = Convert.ToDecimal(reader["Salary"]);
                teacher.Email = Convert.ToString(reader["Email"]);
                teacher.ImagePath = Convert.ToString(reader["ImagePath"]);

                teachers.Add(teacher);
            }
            return teachers;
        }
        public void SendMailAllTeachers(string mailHeader, string mailBody)
        {
            var data = GetAll();
            foreach (var teacher in data)
            {
                MailMessage message = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("test@gmail.com", "test@gmail.com");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                message.To.Add(teacher.Email);
                message.From = new MailAddress("test@gmail.com");
                message.Subject = mailHeader;
                message.Body = mailHeader;
                client.Send(message);
            }
        }
        public int GetTeacherCount()
        {
            return GetAll().Count;
        }
        public void Add(Teacher teacher)
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand($"Insert into Teachers (FirstName,LastName,PhoneNumber,Email,LessonName,ImagePath,Salary) values " +
                $"('{teacher.FirstName}','{teacher.LastName}','{teacher.PhoneNumber}','{teacher.Email}','{teacher.LessonName}','{teacher.ImagePath}','{teacher.Salary}')",connection);
            command.ExecuteNonQuery();
            connection.Close();

        }
        public void Delete(Teacher teacher)
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand($"Delete from Teachers where Id={teacher.Id}",connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Update(Teacher teacher)
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand($"Update Teachers set FirstName='{teacher.FirstName}',LastName='{teacher.LastName}',PhoneNumber='{teacher.PhoneNumber}',Email='{teacher.Email}',LessonName='{teacher.LessonName}',ImagePath='{teacher.ImagePath}',Salary={teacher.Salary} where Id={teacher.Id}",connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
