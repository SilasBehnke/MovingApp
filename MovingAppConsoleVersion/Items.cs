using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace MovingAppConsoleVersion
{
    class Items
    {
        public int ID;
        string name;

        public void NewItem(string N)
        {
            name = N;

            string connString = "Data Source = LAPTOP\\SQLEXPRESS; Initial Catalog = MovingAppTesting; Integrated Security = True";
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();
            }
            catch (Exception EX)
            {
                string error = $"Server Down: {EX.Message}";
            }

            SqlCommand cmd = new SqlCommand("insert Items (ItemName) values (@ItemName)", con);
            cmd.Parameters.AddWithValue("@ItemName", name);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "select * from Items where ItemID = (select max(ItemID) from Items where ItemName = @ItemName)";

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ID = Convert.ToInt32(reader["ItemID"]);
            }

        }
    }
}
