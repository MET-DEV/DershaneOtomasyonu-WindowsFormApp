using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ExpenseDal
    {
        SqlConnection connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;initial catalog=DershaneDb;Trusted_Connection=true");
        public List<Expense> GetAll()
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();

            }
            SqlCommand command = new SqlCommand("Select * from Expenses order by ExpenseTime DESC", connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Expense> expenses = new List<Expense>();
            while (reader.Read())
            {
                Expense expense = new Expense();
                expense.ExpensePlace = Convert.ToString(reader["ExpensePlace"]);
                expense.ExpenseTime = Convert.ToDateTime(reader["ExpenseTime"]);
                expense.Id = Convert.ToInt32(reader["Id"]);
                expense.Price = Convert.ToDecimal(reader["Price"]);
                expenses.Add(expense);
            }
            connection.Close();
            return expenses;
        }
        public void Add(Expense expense)
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand($"Insert into Expenses (ExpensePlace,Price,ExpenseTime) values('{expense.ExpensePlace}','{expense.Price}','{DateTime.Now}')",connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(Expense expense)
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand($"Delete from Expenses where Id={expense.Id}");
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Update(Expense expense)
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand($"Update Expenses set ExpensePlace='{expense.ExpensePlace}',Price='{expense.Price}' where Id={expense.Id}",connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
