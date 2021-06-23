using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace CDV.Project
{
    public class DatabaseContext
    {
        private readonly string connectionString;
        private const string Query = "Select * from Users";

        public DatabaseContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Users> GetUsers()
        {
            var user = new List<Users>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(Query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user.Add(new Users
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        email = reader["Email"].ToString(),
                        password = reader["Password"].ToString()
                    });
                }
                reader.Close();
            }
            return user;
        }
    }
}
