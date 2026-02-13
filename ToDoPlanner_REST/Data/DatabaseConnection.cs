using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ToDoPlanner_REST.Data
{
    public class DatabaseConnection
    {
        public string connectionString { get; set; }
        public SqlConnection connection { get; set; }

        public DatabaseConnection() {

            //Create the connection
            string connectionString = "Server=localhost;Database=ToDoList;Trusted_Connection=True;TrustServerCertificate=True;";

            connection = new SqlConnection(connectionString);
                      
        }

        public void OpenConnection()
        {
            connection.Open();
        }
        public void CloseConnection()
        {
            connection.Close();
        }
    }
}
