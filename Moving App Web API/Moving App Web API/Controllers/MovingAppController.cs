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
        List<string> Username;

        private readonly ILogger<MovingAppController> _logger;
        public MovingAppController(ILogger<MovingAppController> logger)
        {
            _logger = logger;
            Username = new List<string>();
        }

        [HttpGet]
        public string GetMovingApp()
        {
           return "Users are Here";
        }
        
        [HttpGet("{username}")]
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

            /*SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                Username.Add((string)dr["Username"]);
            }*/
            conn.Close();
            return UsernameExist.ToString();
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
