using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CDV.Project
{
    public static class AddPersonFunc
    {
        [FunctionName("CreateUser")]
        public static async Task<IActionResult> CreateUser(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "user")] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<Users>(requestBody);
            try
            {
                string connectionString = Environment.GetEnvironmentVariable("ProjectDb");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    String query = "INSERT INTO dbo.Users (Email, Password) VALUES(@Email, @Password)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", input.email);
                        command.Parameters.AddWithValue("@Password", input.password);
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error: Insert to database");
                    }
                }
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
                return new BadRequestResult();
            }
            return new OkResult();
        }
    }
}