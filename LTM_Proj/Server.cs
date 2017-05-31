using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTM_Proj
{
    public class Server
    {
        public string Ip = "";
        public string Port = "";
        public string status = "";
        public Server(string _ip, string _port)
        {
            Ip = _ip;
            Port = _port;
            status = "-1";
        }
    }
}
