using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Moving_App_Web_API.Controllers
{
    [Route("/MovingApp/Boxes")]
    [ApiController]
    public class MovingAppBoxController
    {
        private readonly ILogger<MovingAppBoxController> _logger;
        public MovingAppBoxController(ILogger<MovingAppBoxController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public string GetMovingApp()
        {
            return "Boxes are Here";
        }
        [HttpGet("BoxExist/{id}")]
        public string BoxExist(int id)
        {
            ServerConnection server = new ServerConnection();

            SqlConnection conn = new SqlConnection(server.connString);

            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT Count(BoxID) FROM Boxes WHERE BoxID = @ID", conn);
            cmd.Parameters.AddWithValue("@ID", id);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            bool BoxExist;
            if (count != 0) BoxExist = true;
            else BoxExist = false;


            conn.Close();
            return BoxExist.ToString();
        }
        [HttpGet("BoxAdd/{name}")]
        public int BoxAdd(string name)
        {
            ServerConnection server = new ServerConnection();
            SqlConnection conn = new SqlConnection(server.connString);

            conn.Open();

            SqlCommand cmd = new SqlCommand("Insert Boxes (BoxName) value (@Name)", conn);
            cmd.Parameters.AddWithValue("@Name", name);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
            cmd.CommandText = "Select Max(ItemID) as BoxID from Items where ItemName = @name";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@name", name);

            SqlDataReader reader = cmd.ExecuteReader();
            int id = 0;
            while (reader.Read())
            {
                id = (int)reader["BoxID"];
            }

            return id;
        }
    }
}
