using System.Collections.Generic;
using System.Data.SqlClient;

namespace NorthwindApp
{
    class DataAccessLayer
    {
        private string _connectionString;

        public DataAccessLayer(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int GetNumberOfCustomers()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Customers", connection);
                return (int)command.ExecuteScalar();
            }
        }

        public List<string> GetCustomerLastName()
        {
            List<string> lastNames = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ContactName FROM dbo.Customers", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string fullName = reader["ContactName"].ToString();
                    string[] nameSplit = fullName.Split(' ');
                    if (nameSplit.Length > 1)
                        lastNames.Add(nameSplit[nameSplit.Length - 1]);
                    else
                        lastNames.Add(fullName);
                }
            }
            return lastNames;
        }
        public int GetNumberOfEmployees()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Employees", connection);
                return (int)command.ExecuteScalar();
            }
        }

        public List<string> GetEmployeeLastName()
        {
            List<string> lastNames = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT LastName FROM dbo.Employees", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string fullName = reader["LastName"].ToString();
                    string[] nameSplit = fullName.Split(' ');
                    if (nameSplit.Length > 1)
                        lastNames.Add(nameSplit[nameSplit.Length - 1]);
                    else
                        lastNames.Add(fullName);
                }
            }
            return lastNames;
        }
        public int GetNumberOfOrders()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Orders", connection);
                return (int)command.ExecuteScalar();
            }
        }

        public List<string> GetOrderName()
        {
            List<string> orders = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ShipName FROM dbo.Orders", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    orders.Add(reader["ShipName"].ToString());
                }
            }
            return orders;
        }
    }
}
