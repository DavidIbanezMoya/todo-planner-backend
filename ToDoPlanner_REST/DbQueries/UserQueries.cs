using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ToDoPlanner_REST.Data;
using ToDoPlanner_REST.DTO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ToDoPlanner_REST.DB_Queries
{
    public class UserQueries
    {
        private DatabaseConnection dbConnection = new DatabaseConnection();

        //List of Queries from the User class

        //Gets all the users from the table
        public JsonResult selectAllUsersQuery()
        {
            string query = "select * from users";
            dbConnection.OpenConnection();
            SqlCommand command = new SqlCommand(query, dbConnection.connection);
            SqlDataReader reader = command.ExecuteReader();
            List<UserDTO> queryResult = new List<UserDTO>();

            if (reader.HasRows)
            {
                int rowColumns = reader.FieldCount;
                while (reader.Read())
                {
                    UserDTO userDTO = new UserDTO();
                    for (int i = 0; i < rowColumns; i++)
                    {
                        //I have to previously read the name of the column to write the value
                        
                        if (reader.GetName(i)=="UserId")
                        {
                            userDTO.Id = reader.GetInt32(i);
                        } else if (reader.GetName(i) == "First_Name")
                        {
                            userDTO.FirstName = reader.GetString(i);
                        }
                        else if (reader.GetName(i) == "Last_Name")
                        {
                            userDTO.LastName = reader.GetString(i);
                        }
                        else if (reader.GetName(i) == "Email")
                        {
                            userDTO.Email = reader.GetString(i);
                        }
                        
                    }
                    queryResult.Add(userDTO);
                }
            }

            dbConnection.CloseConnection();
            return new JsonResult(queryResult);
        }

        //Gets a User by Email
        public JsonResult selectUsersByEmailQuery(string email)
        {
            string query = "select * from users where email = '" + email + "'";
            dbConnection.OpenConnection();
            SqlCommand command = new SqlCommand(query, dbConnection.connection);
            SqlDataReader reader = command.ExecuteReader();
            List<UserDTO> queryResult = new List<UserDTO>();

            if (reader.HasRows)
            {
                int rowColumns = reader.FieldCount;
                while (reader.Read())
                {
                    UserDTO userDTO = new UserDTO();
                    for (int i = 0; i < rowColumns; i++)
                    {
                        //I have to previously read the name of the column to write the value

                        if (reader.GetName(i) == "UserId")
                        {
                            userDTO.Id = reader.GetInt32(i);
                        }
                        else if (reader.GetName(i) == "First_Name")
                        {
                            userDTO.FirstName = reader.GetString(i);
                        }
                        else if (reader.GetName(i) == "Last_Name")
                        {
                            userDTO.LastName = reader.GetString(i);
                        }
                        else if (reader.GetName(i) == "Email")
                        {
                            userDTO.Email = reader.GetString(i);
                        }

                    }
                    queryResult.Add(userDTO);
                }
            }

            dbConnection.CloseConnection();
            return new JsonResult(queryResult);
        }
    }
}
