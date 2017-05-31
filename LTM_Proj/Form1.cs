using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace LTM_Proj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        Root ROOT = new Root();
        private Object thislock = new Object();
        delegate void UpdateLV();
        private void btnStart_Click(object sender, EventArgs e)
        {
            ROOT.Start();
          //  Thread t = new Thread(DisplayListView);
            //t.Start();
            DisplayListView();
        }

        private void DisplayListView()
        {
            while (true)
            {
                if (this.lvServers.InvokeRequired)
                {
                    UpdateLV d = new UpdateLV(DisplayListView);
                    this.Invoke(d);
                }
                else
                {
                     int j = 1;
                    foreach (Server i in ROOT.GetListServers())
                    {
                        if (i != null)
                        {
                            string[] str = { j.ToString(), i.Ip, i.Port, i.status };
                            ListViewItem item = new ListViewItem(str);
                            lvServers.Items.Add(item);
                            j++;
                        }
                    }
                }
            }
        }
       
    }
    public class Server
    {
        public string Ip{get;set;}
        public string Port { get; set; }
        public string status{get;set;}
        public Server(string _ip,string _port)
        {
            Ip = _ip;
            Port = _port;
            status = "-1";
        }
    }
    public class Root
    {
        public static int NumbersOfServers;
        public static IPAddress ipad;
        public static int port,portClient;
        public static TcpListener tcpRoot,tcpForClient;
        public static int count = 0;
        public static int count2 = 0;
        public static Socket[] socket;
        public static Socket[] clientSock;
        public static Server[] ListServers;
        
        private static Object lock1 = new Object();
        private static Object lock2 = new Object();
        public Root(int n=100)
        {
            NumbersOfServers = n;
            ListServers = new Server[NumbersOfServers];
       
        }
        public void Start()
        {
            try
            {
                //Init
                socket = new Socket[NumbersOfServers];
                clientSock = new Socket[100];
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
            tcpRoot.Stop();
            tcpForClient.Stop();
        }
        public Server[] GetListServers()
        {
            return ListServers;
        }
        static void HandleServer()
        {
            
            while (true)
            {
               
                socket[count] = tcpRoot.AcceptSocket();
                //lock
                if (count > NumbersOfServers)
                {
                    count = 0;
                }
                else
                {
                    count++;
                }
                Thread t = new Thread(WorkerServer);
                t.Start(count - 1);
            }
        }
        static void HandleClient()
        {
            while (true)
            {
                clientSock[count2] = tcpForClient.AcceptSocket();
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

        private static int IndexOfServ(Server a)
        {
            lock (lock1)
            {
                for (int i = 0; i < NumbersOfServers; i++)
                {
                    if (ListServers[i] == a)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        static void WorkerServer(object obj)
        {
            int index = (Int32)obj;
            byte[] recv = new byte[100];
            lock (lock1)
            {
                try
                {
                    int k = socket[index].Receive(recv);
                    string Data = "";
                    for (int i = 0; i < k; i++)
                    {
                        Data += Convert.ToChar(recv[i]);
                    }
                    int j = Data.IndexOf(":");
                    int t = Data.IndexOf(";");
                    string servIp = Data.Substring(0, j);
                    string servPort = Data.Substring(j + 1, t - 1 - j);
                    string Status = Data.Substring(t + 1, Data.Length - t - 1);
                    Server tmp = new Server(servIp, servPort);
                    j = IndexOfServ(tmp);
                    ListServers[index] = tmp;
                    ListServers[index].status = Status;
                }
                catch (Exception err)
                {
                    socket[index].Close();
                    //ListServers[index].status = "-1";
                }
                socket[index].Close();
                
            }

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
                    string str="";
                    lock (lock1)
                    {
                        lock (lock1)
                        {
                            f = FindServerFree();
                        }
                        if (f != -1)
                        {
                            free = ListServers[f];
                            str = free.Ip+":"+free.Port;
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
