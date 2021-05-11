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
    [ApiController]
    [Route("[controller]")]
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
        public bool UserCheck(string _username)
        {
            bool UsernameExist;

            ServerConnection Connection = new ServerConnection();
            SqlConnection conn = new SqlConnection(Connection.connString);

            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT Username FROM Users WHERE Username = @Username");
            cmd.Parameters.AddWithValue("@Username", _username);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows) UsernameExist = true;
            else UsernameExist = false;

            /*SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                Username.Add((string)dr["Username"]);
            }*/

            conn.Close();
            return UsernameExist;
        }

        


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

        // POST: MovingAppController/Delete/5
        
    }
}
