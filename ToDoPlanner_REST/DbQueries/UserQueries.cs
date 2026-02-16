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
            //It is using SqlDataReader so no injections might be done
            string query = "select * from users where email = @Email";
            dbConnection.OpenConnection();
            SqlCommand command = new SqlCommand(query, dbConnection.connection);
            command.Parameters.Add("@Email",System.Data.SqlDbType.Char).Value = email;
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

        public bool insertUserQuery (string first_Name, string last_Name, string email, string password_Hash, string password_Salt)
        {
            string query = "insert into ToDoList.dbo.Users (First_Name,Last_Name,Email,Password_Hash,Password_Salt)";
            //Avoid query injection
            query += "values(@First_Name,@Last_Name,@Email,@Password_Hash,@Password_Salt)";
            dbConnection.OpenConnection();
            SqlCommand command = new SqlCommand(query,dbConnection.connection);
            command.Parameters.Add("@First_Name", System.Data.SqlDbType.Text).Value = first_Name;
            command.Parameters.Add("@Last_Name", System.Data.SqlDbType.Text).Value = last_Name;
            command.Parameters.Add("@Email", System.Data.SqlDbType.Text).Value = email;
            command.Parameters.Add("@Password_Hash", System.Data.SqlDbType.VarBinary).Value = password_Hash;
            command.Parameters.Add("@Password_Salt", System.Data.SqlDbType.VarBinary).Value = password_Salt;

            command.ExecuteNonQuery();

            dbConnection.CloseConnection();
            return true;
        }
    }
}
