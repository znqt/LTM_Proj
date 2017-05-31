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
        public static int port, portClient;
        public static TcpListener tcpRoot, tcpForClient;
        public static int count = 0;
        public static int count2 = 0;
        public static Socket[] socket;
        public static Socket[] clientSock;
        public static Server[] ListServers;

        private static Object lock1 = new Object();
        private static Object lock2 = new Object();
        public Root(int n = 100)
        {
            NumbersOfServers = n;
        }
        public void Start()
        {
            try
            {
                //Init
                socket = new Socket[NumbersOfServers];
                clientSock = new Socket[100];
                ListServers = new Server[NumbersOfServers];
                ipad = IPAddress.Parse("127.0.0.1");
                port = 12000;
                portClient = 13000;
                tcpRoot = new TcpListener(ipad, port);
                tcpForClient = new TcpListener(ipad, portClient);
                //Listen
                tcpRoot.Start();
                tcpForClient.Start();
                //
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
                tcpRoot.Stop();
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
        static void HandleServer()
        {

            while (true)
            {
                try
                {
                    Socket newServerSocket = tcpRoot.AcceptSocket();
                    Thread t = new Thread(WorkerServer);
                    t.Start(newServerSocket);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.StackTrace);
                }
            }
        }
        static void HandleClient()
        {
            try
            {
                while (true)
                {
                    clientSock[count2] = tcpForClient.AcceptSocket();
                    Form1.flag = 1;
                    //lock
                    if (count2 > 100)
                    {
                        count2 = 0;
                    }
                    else
                    {
                        count2++;
                    }
                    Thread t = new Thread(WorkerClient);
                    t.Start(count2 - 1);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.StackTrace);
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
            int k = serverSocket.Receive(recv);
            string Data = System.Text.Encoding.UTF8.GetString(recv);
            //split data
            int j = Data.IndexOf(":");
            int t = Data.IndexOf(";");
            string servIp = Data.Substring(0, j);
            string servPort = Data.Substring(j + 1, t - 1 - j);
            string Status = Data.Substring(t + 1, 1);
            Helper.log("Connect: " + servIp + ":" + servPort + ". Status: " + Status);

            Server tmp = new Server(servIp, servPort);
            int m = IndexOfServ(tmp);
            if (m == -1)
            {
                int place = FindFreePlace();
                if (place != -1)
                {
                    ListServers[place] = tmp;
                    ListServers[place].status = Status;
                    Helper.log("Added to slot " + place.ToString());
                }
            }
            else
            {
                ListServers[m].status = Status;
                Helper.log("Updated in slot " + m.ToString());
            }
            Form1.flag = 1;
        }

        private static int FindServerFree()
        {
            for (int i = 0; i < NumbersOfServers; i++)
            {
                if (ListServers[i].status == "0")
                {
                    return i;
                }
            }
            return -1;
        }
        static void WorkerClient(object obj)
        {
            int inx = (Int32)obj;
            byte[] recv = new byte[1];
            byte[] send = new byte[20];
            lock (lock2)
            {
                clientSock[inx].Receive(recv);
                if (recv != null)
                {
                    int f;
                    Server free;
                    string str = "";
                    lock (lock1)
                    {
                        lock (lock1)
                        {
                            f = FindServerFree();
                        }
                        if (f != -1)
                        {
                            free = ListServers[f];
                            str = free.Ip + ":" + free.Port;
                            ListServers[f].status = "1";
                        }
                    }
                    ASCIIEncoding asen = new ASCIIEncoding();
                    clientSock[inx].Send(asen.GetBytes(str));
                }
                clientSock[inx].Close();
            }
        }
    }
}
