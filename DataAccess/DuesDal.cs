using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DuesDal
    {
        SqlConnection connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;initial catalog=DershaneDb;Trusted_Connection=true");
        public List<Dues> GetAll()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("Select * from Dues order by DuesTime ASC", connection);
            List<Dues> dueses = new List<Dues>();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Dues dues = new Dues();
                dues.Id = Convert.ToInt32(reader["Id"]);
                dues.StudentId = Convert.ToInt32(reader["StudentId"]);
                dues.GivenDate = Convert.ToDateTime(reader["GivenDate"]);
                dues.DuesTime = Convert.ToDateTime(reader["DuesTime"]);
                dues.Status = Convert.ToBoolean(reader["Status"]);
                dues.Price = Convert.ToDecimal(reader["Price"]);
                dueses.Add(dues);
                
                
            }
            return dueses;
        }
        public void UpdateDuesStatus(int id)
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand($"Update Dues set Status='{true}' where Id={id}",connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void CreateDues(Student student,decimal price)
        {
            if (DateTime.Now.Month==6|| DateTime.Now.Month == 7 || DateTime.Now.Month == 8 || DateTime.Now.Month == 9)
            {
                
                DateTime date = new DateTime(DateTime.Now.Year,9,15);
                for (int i = 0; i <10 ; i++)
                {
                    
                    Dues dues = new Dues();
                    dues.Price = price;
                    dues.Status = false;
                    dues.StudentId = student.Id;
                    dues.DuesTime = date;
                    date=date.AddMonths(1);
                    Add(dues);

                }
            }
            else
            {
                DateTime date=DateTime.Now;
                while (7!=date.Month)
                {
                    Dues dues = new Dues();
                    dues.Price = price;
                    dues.Status = false;
                    dues.StudentId = student.Id;
                    dues.DuesTime = date;
                    date = date.AddMonths(1);
                    Add(dues);
                }
            }
          
        }
        public void DeleteById(int id)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();

            }
            SqlCommand command = new SqlCommand($"Delete from Dues where Id={id}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(int studentId)
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();

            }
            SqlCommand command = new SqlCommand($"Delete from Dues where StudentId={studentId}",connection);
            command.ExecuteNonQuery();
            connection.Close();

        }
        public decimal GetMounthlyMoney()
        {
            var data=GetAll();
            decimal toplam = 0;
            DateTime date1 = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
            DateTime date2=DateTime.Now;
            if (DateTime.Now.Month!=2)
            {
                 date2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 30);
            }
            else
            {
                 date2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28);
            }
            
            foreach (var dues in data)
            {
                if (dues.DuesTime<date2&& dues.DuesTime > date1)
                {
                    toplam = toplam + dues.Price;
                }
            }
            return toplam;
        }
        public void Add(Dues dues)
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand($"Insert into Dues (StudentId,Status,Price,DuesTime,GivenDate) values ('{dues.StudentId}','{dues.Status}','{dues.Price}','{dues.DuesTime}','{dues.GivenDate}')",connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
