using DataAccess.Tools;
using EntityLayer.Concrete;
using EntityLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AdminDal
    {
        SqlConnection connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;initial catalog=DershaneDb;Trusted_Connection=true");
        public List<Admin> GetAll()
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("Select * from Admins", connection);
            List<Admin> admins = new List<Admin>();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Admin admin = new Admin();
                admin.UserName = Convert.ToString(reader["UserName"]);
                admin.Id = Convert.ToInt32(reader["Id"]);
                admin.Email = Convert.ToString(reader["Email"]);
                admin.Password = Convert.ToString(reader["Password"]);
                admins.Add(admin);
            }
            return admins;
        }
        public Mail CheckUserForMail(string username,string email)
        {
            List<Admin> admins=GetAll();
            foreach (Admin admin in admins)
            {
                if (admin.Email==email&&admin.UserName==username)
                {
                    return new Mail() {Success=true,Password=admin.Password };
                }
            }
            return new Mail() { Success = false };
        }
        public bool SendMail(string username,string email)
        {
            Mail bilgi = CheckUserForMail(username, email);
            if (bilgi.Success)
            {
                MailMessage message = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("dershaneotomasyonotomesaj@gmail.com","mustafaenesotomasyonodev");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                message.To.Add(email);
                message.From = new MailAddress("dershaneotomasyonotomesaj@gmail.com");
                message.Subject="Parolanız";
                message.Body = "Parolanız: "+bilgi.Password;
                client.Send(message);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Add(Admin admin)
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand($"Insert into Admins (UserName,Password) values ('{admin.UserName}','{admin.Password}')",connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Update(Admin admin)
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand($"Update Admins set UserName='{admin.UserName}',Password='{admin.Password}' where Id={admin.Id}",connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(Admin admin)
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand($"Delete from Admins where Id={admin.Id}",connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public bool CheckUser(LoginDTO loginDTO)
        {
            var data = GetAll();
            foreach (var admin in data)
            {
                if (admin.Password==loginDTO.Password&&admin.UserName==loginDTO.UserName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
