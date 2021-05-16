using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Moving_App_Web_API.Controllers
{
    [Route("/MovingApp/Users")]
    [ApiController]

    public class MovingAppController : ControllerBase
    {
       

        private readonly ILogger<MovingAppController> _logger;
        public MovingAppController(ILogger<MovingAppController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string GetMovingApp()
        {
           return "Users are Here";
        }
        
        [HttpGet("UserExist/{username}")]
        public string UserCheck(string username)
        {
            bool UsernameExist;

            ServerConnection Connection = new ServerConnection();
            SqlConnection conn = new SqlConnection(Connection.connString);

            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT Count(UserID) FROM Users WHERE Username = @Username", conn);
            cmd.Parameters.AddWithValue("@Username", username);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count != 0) UsernameExist = true;
            else UsernameExist = false;

            
            conn.Close();
            return UsernameExist.ToString();
        }
        [HttpGet("UserExist/{username}/{password}")]
        public string UsernamePassword(string username, string password)
        {
            bool UserExist = false;
            ServerConnection Connection = new ServerConnection();
            SqlConnection conn = new SqlConnection(Connection.connString);

            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT Count(UserID) FROM Users WHERE Username = @Username and Password = @Password", conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();

            if (count != 0) UserExist = true;
            else UserExist = false;

            return UserExist.ToString();
        }
        [HttpGet("UserAdd/{username}/{password}")]
        public string UserAdd(string username, string password)
        {
            string successMessage = "Success";
            ServerConnection Connection = new ServerConnection();
            SqlConnection conn = new SqlConnection(Connection.connString);

            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT Count(UserID) FROM Users WHERE Username = @Username", conn);
            cmd.Parameters.AddWithValue("@Username", username);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count == 0)
            {
                cmd.CommandText = "Insert Users (Username, Password) values (@Username, @Password)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            else successMessage = "User Add Failed";



            return successMessage;
        }
        [HttpGet("UserID/{username}/{password}")]
        public string UsernameID(string username, string password)
        {
            int UserID = 0;
            ServerConnection Connection = new ServerConnection();
            SqlConnection conn = new SqlConnection(Connection.connString);

            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT UserID FROM Users WHERE Username = @Username and Password = @Password", conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                UserID = (int) reader["UserID"];
            }
            reader.Close();
            conn.Close();

            if (UserID == 0) return "No User Found";

            return UserID.ToString();
        }


        [HttpDelete]
        // GET: MovingAppController/Delete/5
        public void Delete(int id)
        {
            ServerConnection Connection = new ServerConnection();
            SqlConnection conn = new SqlConnection(Connection.connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM ITEMS WHERE ItemID = @ID");
            cmd.Parameters.AddWithValue("@ID", id);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch { throw new Exception("Error Executing Delete: MovingAppController.cs/84"); }
            conn.Close();
        }        
    }
}
