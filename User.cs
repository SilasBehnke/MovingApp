using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;


namespace MovingAppConsoleVersion
{
    class User
    {
       public int LoginRun()
        {
            int userID = 0;
            string connString = "Data Source = LAPTOP\\SQLEXPRESS; Initial Catalog = MovingAppTesting; Integrated Security = True";
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from Users", con);
            while (userID == 0)
            {
                Console.WriteLine("Type Username:");
                string Username = Console.ReadLine();
                Console.WriteLine("Type Password:");
                string Password = Console.ReadLine();

                cmd.CommandText = $"select Username from Users where Username = @Username";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Username", Username);

                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.WriteLine("Username Doesn't Exist");
                    reader.Close();
                }
                else
                {
                    reader.Close();

                    cmd.CommandText = "select UserID from Users where Username = @Username and Password = @Password";
                    cmd.Parameters.AddWithValue("@Password", Password);
                    reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        Console.WriteLine("Password is Incorrect");
                        reader.Close();
                    }
                    else
                    {
                        Console.WriteLine("Login Successful!");
                        while (reader.Read())
                        {
                            userID = Convert.ToInt32(reader["UserID"]);
                        }
                    }
                }
            }
            Console.WriteLine(userID);
            return userID;
        }
    }


}
