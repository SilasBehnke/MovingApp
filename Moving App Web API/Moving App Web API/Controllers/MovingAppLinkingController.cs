using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Moving_App_Web_API.Controllers
{
    [Route("MovingApp/Link/")]
    [ApiController]
    public class MovingAppLinkingController
    {
        private readonly ILogger<MovingAppLinkingController> _logger;
        public MovingAppLinkingController(ILogger<MovingAppLinkingController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public string GetMovingApp()
        {
            return "This is where the links between items/boxes/users are created";
        }

        [HttpGet("BoxItem/{boxid}/{itemid}")]
        public string BoxItem(int boxid, int itemid)
        {
            ServerConnection server = new ServerConnection();

            SqlConnection conn = new SqlConnection(server.connString);

            conn.Open();

            SqlCommand cmd = new SqlCommand("insert BoxItem (BoxID, ItemID) values (@boxid,@itemid)");
            cmd.Parameters.AddWithValue("@boxid",boxid);
            cmd.Parameters.AddWithValue("@itemid", itemid);

        }
    }
}
