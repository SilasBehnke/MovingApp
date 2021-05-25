using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Data.SqlClient;

namespace Moving_App_Web_API.Controllers
{
    [Route("/MovingApp/Items")]
    [ApiController]
    public class MovingAppItemController
    {
        private readonly ILogger<MovingAppItemController> _logger;
        public MovingAppItemController(ILogger<MovingAppItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string GetMovingApp()
        {
            return "Items are Here";
        }

        [HttpGet("ItemExist/{id}")]
        public string ItemExist(int id)
        {
            ServerConnection server = new ServerConnection();

            SqlConnection conn = new SqlConnection(server.connString);

            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT Count(ItemID) FROM Items WHERE ItemID = @ID", conn);
            cmd.Parameters.AddWithValue("@ID", id);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            bool ItemExist;
            if (count != 0) ItemExist = true;
            else ItemExist = false;


            conn.Close();
            return ItemExist.ToString();
        }

        [HttpGet("ItemAdd/{name}/{description}")]
        public int ItemAdd(string name, string description)
        {
            ServerConnection server = new ServerConnection();
            SqlConnection conn = new SqlConnection(server.connString);

            conn.Open();

            SqlCommand cmd = new SqlCommand("Insert Items (ItemName, ItemDescription) values (@Name, @Description)", conn);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Description", description);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
            cmd.CommandText = "Select Max(ItemID) as ItemID from Items where ItemName = @name";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@name", name);

            SqlDataReader reader = cmd.ExecuteReader();
            int id = 0;
            while (reader.Read())
            {
                id = (int)reader["ItemID"];
            } 

            return id;
        }

    }
}
