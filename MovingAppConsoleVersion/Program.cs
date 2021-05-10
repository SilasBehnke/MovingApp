using System;
using System.Data.SqlClient;

namespace MovingAppConsoleVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            int UserID;
            string answer;
            
            User login = new User();
            UserID = login.LoginRun();

            Console.WriteLine("Add a Box? (Y/N)");
            answer = Console.ReadLine();
            while (answer.ToUpper() != "N" && answer.ToUpper() == "Y")
            {
               Boxes TempBox = new Boxes();
               TempBox.NewBox(UserID);

                Console.WriteLine("Add another Box? (Y/N)");
                answer = Console.ReadLine();
            }





        }

    }
}
