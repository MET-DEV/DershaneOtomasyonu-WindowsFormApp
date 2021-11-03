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
    public class StudentDal
    {
        SqlConnection connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;initial catalog=DershaneDb;Trusted_Connection=true");
        public List<Student> GetAll()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("Select * from Students", connection);
            List<Student> students = new List<Student>();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Student student = new Student();
                student.RegisterDate = Convert.ToDateTime(reader["RegisterDate"]);
                student.Id = Convert.ToInt32(reader["Id"]);
                student.IdentityNumber = Convert.ToString(reader["IdentityNumber"]);
                student.FirstName = Convert.ToString(reader["FirstName"]);
                student.LastName = Convert.ToString(reader["LastName"]);
                student.ParentNumber = Convert.ToString(reader["ParentNumber"]);
                student.PersonalNumber = Convert.ToString(reader["PersonalNumber"]);
                student.Email = Convert.ToString(reader["Email"]);
                student.ImagePath = Convert.ToString(reader["ImagePath"]);
                students.Add(student);

                
            }
            return students;
        }
        public int GetStudentCount()
        {
            return GetAll().Count;
        }
        public Student GetById(int id)
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand($"Select * from Students where Id={id}",connection);
            SqlDataReader reader = command.ExecuteReader();
            Student student = new Student();
            while (reader.Read())
            {
                student.Id = Convert.ToInt32(reader["Id"]);
                student.FirstName = Convert.ToString(reader["FirstName"]);
                student.LastName = Convert.ToString(reader["LastName"]);
                student.Email = Convert.ToString(reader["Email"]);
                student.ParentNumber = Convert.ToString(reader["ParentNumber"]);
                student.PersonalNumber = Convert.ToString(reader["PersonalNumber"]);

            }
            connection.Close();
            return student;
        }
        public void SendMailAllStudents(string mailHeader,string mailBody)
        {
            var data = GetAll();
            foreach (var student in data)
            {
                MailMessage message = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("test@gmail.com", "test@gmail.com");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                message.To.Add(student.Email);
                message.From = new MailAddress("test@gmail.com");
                message.Subject =mailHeader;
                message.Body = mailHeader;
                client.Send(message);
            }
        }
        public Student GetIdByMail(string mail)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand($"Select * from Students where Email='{mail}'", connection);
            SqlDataReader reader = command.ExecuteReader();
            Student student = new Student();
            while (reader.Read())
            {
                student.Id = Convert.ToInt32(reader["Id"]);
                student.FirstName = Convert.ToString(reader["FirstName"]);
                student.LastName = Convert.ToString(reader["LastName"]);
                student.Email = Convert.ToString(reader["Email"]);
                student.ParentNumber = Convert.ToString(reader["ParentNumber"]);
                student.PersonalNumber = Convert.ToString(reader["PersonalNumber"]);

            }
            connection.Close();
            return student;
        }
        public void Add(Student student)
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand($"Insert into Students(IdentityNumber,FirstName,LastName,Email,PersonalNumber,ParentNumber,ImagePath,RegisterDate) values('{student.IdentityNumber}','{student.FirstName}','{student.LastName}','{student.Email}','{student.PersonalNumber}','{student.ParentNumber}','{student.ImagePath}','{student.RegisterDate}')",connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Update(Student student)
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand($"Update Students set IdentityNumber='{student.IdentityNumber}',FirstName='{student.FirstName}',LastName='{student.LastName}',Email='{student.Email}',PersonalNumber='{student.PersonalNumber}',ParentNumber='{student.ParentNumber}',ImagePath='{student.ImagePath}' where id={student.Id}",connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(Student student)
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand($"Delete from Students where Id={student.Id}",connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
