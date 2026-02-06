using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ToDoPlanner_REST.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ToDoPlanner_REST.DB_Queries
{
    public class UserQueries
    {
        private DatabaseConnection dbConnection = new DatabaseConnection();


        public JsonResult selectQuery(string query)
        {
            dbConnection.OpenConnection();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Object> queryResult = new List<Object>();

            if (reader.HasRows)
            {
                int rowColumns = reader.FieldCount;
                while (reader.Read())
                {
                    for (int i = 0; i < rowColumns; i++)
                    {
                        //I have to previously read the name of the column and write column + value
                        Console.Write(" " + reader.GetName(i) + ": " + reader.GetValue(i));
                        queryResult.Add(reader.GetName(i));
                    }
                    Console.WriteLine();
                }

            }

            dbConnection.CloseConnection();
            return new JsonResult(queryResult);
        }
    }
}
