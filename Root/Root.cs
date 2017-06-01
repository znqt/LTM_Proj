using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LTM_Proj
{
    public class Root
    {
        public static int NumbersOfServers;
        public static IPAddress ipad;
        public static int portForServer, portForClient;
        public static TcpListener tcpForServer, tcpForClient;
        public static int count = 0;
        public static int count2 = 0;
        public static Server[] ListServers;

        private static Object lock1 = new Object();
        public Root(int n = 100)
        {
            NumbersOfServers = n;
        }
        public void Start()
        {
            try
            {
                //Init
                ListServers = new Server[NumbersOfServers];
                ipad = IPAddress.Parse("127.0.0.1");
                portForServer = 12000;
                portForClient = 13000;
                tcpForServer = new TcpListener(ipad, portForServer);
                tcpForClient = new TcpListener(ipad, portForClient);
                //Listen
                tcpForServer.Start();
                Helper.log("tcpForServer started at port " + portForServer.ToString() + ".");
                tcpForClient.Start();
                Helper.log("tcpForClient started at port " + portForClient.ToString() + ".");

                Thread threadServer = new Thread(HandleServer);
                Thread threadClient = new Thread(HandleClient);
                threadServer.Start();
                threadClient.Start();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.StackTrace);
            }
        }
        public void Disconnect()
        {
            try
            {
                tcpForServer.Stop();
                tcpForClient.Stop();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.StackTrace);
            }
        }

        public Server[] GetListServers()
        {
            return ListServers;
        }

        public static void checkTimeout()
        {
            lock (lock1)
            {
                for (int i = 0; i < NumbersOfServers; i++)
                {
                    Server checkServer = ListServers[i];
                    if (checkServer != null)
                    {
                        DateTime currentTime = DateTime.Now;
                        double lastUpdate = ((TimeSpan)(currentTime - checkServer.lastConnect)).TotalSeconds;
                        if (lastUpdate > 30)
                        {
                            ListServers[i].status = "-1";
                            Helper.log(string.Format("Timeout: {0}:{1} ({2}s).", checkServer.Ip, checkServer.Port, lastUpdate));
                        }
                    }
                }
            }
        }

        static void HandleServer()
        {
            Helper.log("Thread: HandleServer started.");
            while (true)
            {
                try
                {
                    Socket newServerSocket = tcpForServer.AcceptSocket();
                    Thread t = new Thread(WorkerServer);
                    t.Start(newServerSocket);
                }
                catch (Exception err)
                {
                    Helper.log(err.StackTrace);
                }
            }
        }

        static void HandleClient()
        {
            Helper.log("Thread: HandleClient started.");
            while (true)
            {
                try
                {
                    Socket newClientSocket = tcpForClient.AcceptSocket();
                    Thread t = new Thread(WorkerClient);
                    t.Start(newClientSocket);
                }
                catch (Exception err)
                {
                    Helper.log(err.StackTrace);
                }
            }
        }

        private static int IndexOfServ(Server a)
        {
            lock (lock1)
            {
                for (int i = 0; i < NumbersOfServers; i++)
                {
                    if (ListServers[i] != null)
                    {
                        if (ListServers[i].Ip == a.Ip && ListServers[i].Port == a.Port)
                        {
                            return i;
                        }
                    }
                }
            }
            return -1;
        }

        private static int FindFreePlace()
        {
            lock (lock1)
            {
                for (int i = 0; i < NumbersOfServers; i++)
                {
                    if (ListServers[i] != null)
                    {
                        if (ListServers[i].Port == "-1")
                        {
                            return i;
                        }
                    }
                    else
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        static void WorkerServer(object obj)
        {
            Socket serverSocket = (Socket) obj;
            byte[] recv = new byte[100];
            serverSocket.Receive(recv);
            string Data = System.Text.Encoding.UTF8.GetString(recv);
            //split data
            int j = Data.IndexOf(":");
            int t = Data.IndexOf(";");
            string servIp = Data.Substring(0, j);
            string servPort = Data.Substring(j + 1, t - 1 - j);
            string Status = Data.Substring(t + 1, 1);
            Helper.log("Server connect: " + servIp + ":" + servPort + ". Status: " + Status);

            Server tmp = new Server(servIp, servPort);
            int m = IndexOfServ(tmp);
            if (m == -1)
            {
                int place = FindFreePlace();
                if (place != -1)
                {
                    lock (lock1)
                    {
                        ListServers[place] = tmp;
                        ListServers[place].status = Status;
                        ListServers[place].lastConnect = DateTime.Now;
                    }
                    Helper.log("Added to slot " + place.ToString());
                }
            }
            else
            {
                lock (lock1)
                {
                    ListServers[m].status = Status;
                    ListServers[m].lastConnect = DateTime.Now;
                }
                Helper.log("Updated in slot " + m.ToString());
            }
            checkTimeout();
        }

        private static int FindServerFree()
        {
            lock (lock1)
            {
                for (int i = 0; i < NumbersOfServers; i++)
                {
                    if (ListServers[i] == null)
                    {
                        continue;
                    }
                    if (ListServers[i].status == "0")
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        static void WorkerClient(object obj)
        {
            Socket clientSocket = (Socket)obj;
            Helper.log("Client connect:" + ((IPEndPoint)clientSocket.LocalEndPoint).Address + ":" +
                ((IPEndPoint)clientSocket.LocalEndPoint).Port + ".");
            byte[] recv = new byte[1];
            byte[] send = new byte[20];
            clientSocket.Receive(recv);
            if (recv != null)
            {
                string response = "";
                lock (lock1)
                {
                    checkTimeout();
                    int freeServerIndex = FindServerFree();
                    if (freeServerIndex != -1)
                    {
                        Server freeServer = ListServers[freeServerIndex];
                        response = freeServer.Ip + ":" + freeServer.Port;
                        ListServers[freeServerIndex].status = "1";
                    }
                }
                Helper.log("Redirected client to server " + response + ".");
                Form1.flag = 1;
                clientSocket.Send(Encoding.ASCII.GetBytes(response));
            }
            clientSocket.Close();
        }
    }
}
