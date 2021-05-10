using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace MovingAppConsoleVersion
{
    class Boxes
    {
        int ID;
        string name;

        public void NewBox(int UserID)
        {
           
            string Name;
            string answer;
            Console.WriteLine("Name:");
            name = Console.ReadLine();
            string connString = "Data Source = LAPTOP\\SQLEXPRESS; Initial Catalog = MovingAppTesting; Integrated Security = True";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            // Insert the box into the table
            SqlCommand cmd = new SqlCommand("insert Box (BoxName) values (@BoxName)", con);
            cmd.Parameters.AddWithValue("@BoxName", name);
            cmd.ExecuteNonQuery();
            // Selecting the latest instance of the box with that name. Largest ID = most recent
            cmd.CommandText = "select * from Box where BoxID = (select max(BoxID) from Box where BoxName = @BoxName)";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ID = Convert.ToInt32(reader["BoxID"]);
            }
            reader.Close();
            cmd.CommandText = "insert UserBox (UserID,BoxID) values (@UserID, @BoxID)";
            cmd.Parameters.AddWithValue("@BoxID", ID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();




            Console.WriteLine("Add An Item? (Y/N)");
            answer = Console.ReadLine();
            while (answer.ToUpper() != "N" && answer.ToUpper() == "Y")
            {
                Console.WriteLine("Name:");
                Name = Console.ReadLine();
                Items NewItem = new Items();
                NewItem.NewItem(Name);

                //Link this new Item to the Box
                cmd.CommandText = "insert BoxItem (BoxID,ItemID) values (@BoxID, @ItemID)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@BoxID", ID);
                cmd.Parameters.AddWithValue("@ItemID", NewItem.ID);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Add Another Item? (Y/N)");
                answer = Console.ReadLine();
            }

            Console.WriteLine("Box Added to User Account");
            con.Close();
        }
    }
}
