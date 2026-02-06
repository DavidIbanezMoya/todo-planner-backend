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

            //Select all users for example, to verify that there is a decent view.
            /*connection.Open();
            string query = "select * from Users;";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("ToDoList - Users");
            while (reader.Read())
            {
                string Name = reader.GetString(1);
                string Surname = reader.GetString(2);

                Console.WriteLine("Name: "+Name+" Surname: "+Surname);
            }

            connection.Close();*/
            
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
