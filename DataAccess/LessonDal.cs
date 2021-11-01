using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class LessonDal
    {
        SqlConnection connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;initial catalog=DershaneDb;Trusted_Connection=true");
        public List<Lesson> GetAll()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("Select * from Lessons", connection);
            List<Lesson> lessons = new List<Lesson>();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Lesson lesson = new Lesson();
                lesson.LessonName = Convert.ToString(reader["LessonName"]);
                lesson.Id = Convert.ToInt32(reader["Id"]);
                
                lessons.Add(lesson);
            }
            return lessons;
        }


        public int GetIdByName(string name)
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand($"Select * from Lessons where LessonName='{name}'",connection);
            SqlDataReader reader = command.ExecuteReader();
            int id = 0;
            while (reader.Read())
            {
                if (reader["Id"]!=null)
                {
                    id = Convert.ToInt32(reader["id"]);
                    return id;
                }
                
            }
            return id;
            
        }
    }
}
