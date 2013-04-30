using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebTester
{
    public class Client
    {
        public Client(string clientID, string clientLogin, string clientPassword)
        {
            ClientID = clientID;
            ClientLogin = clientLogin;
            ClientPassword = clientPassword;
        }

        public Client(string clientID)
        {
            ClientID = clientID;
            ClientLogin = "admin" + clientID;
            ClientPassword = "hedge1!";
        }

        public string ClientID { get; set; }
        public string ClientLogin { get; set; }
        public string ClientPassword { get; set; }
    }

}
