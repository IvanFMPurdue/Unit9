using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace NorthwindApp
{
    class BusinessLayer
    {
        private DataAccessLayer _dal;

        public BusinessLayer(string database, string server, string username, string password)
        {
            string cs = $@"Data Source = IVANPC\{server}; Initial Catalog = {database}; User ID={username}; Password={password};";
            if(TryToConnect(cs))
                _dal = new DataAccessLayer(cs);
        }

        public bool TryToConnect(string cs)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                string error = $"SQL Exception: {ex.Message}";

                if (ex.Number == 18456)
                {
                    error += "*Login failed*";
                }
                MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            catch (Exception ex)
            {
                string error = $"Unexpected error: {ex.Message}";
                MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public int GetNumberOfCustomers()
        {
            return _dal.GetNumberOfCustomers();
        }

        public List<string> GetCustomerLastName()
        {
            return _dal.GetCustomerLastName();
        }
        public int GetNumberOfEmployees()
        {
            return _dal.GetNumberOfEmployees();
        }

        public List<string> GetEmployeeLastName()
        {
            return _dal.GetEmployeeLastName();
        }
        public int GetNumberOfOrders()
        {
            return _dal.GetNumberOfOrders();
        }

        public List<string> GetOrderName()
        {
            return _dal.GetOrderName();
        }
    }
}
