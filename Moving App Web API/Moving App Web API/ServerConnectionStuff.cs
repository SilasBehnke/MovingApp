using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moving_App_Web_API
{
    public class ServerConnection
    {
        string conn = "Data Source=behnketest.database.windows.net;Initial Catalog = MovingAppTesting; User ID = JonTheBrownDog; Password=HuracanBatman55";

        public string connString { get
            {
                return connString;
            }
            set
            {
                connString = value;
            } }
        public ServerConnection() {
            connString = conn;
                }

    }
}
