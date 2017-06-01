using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        public static IPAddress ipAd;
        public static string servIp = "127.0.0.1";
        public static string servPort;
        public static TcpListener server;
        public static int count = 0;
        public static Socket[] socket;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            ipAd = IPAddress.Parse(servIp);
            server = new TcpListener(ipAd, 0);
            server.Start();
            servPort = ((IPEndPoint)server.LocalEndpoint).Port.ToString();
            lbIP.Text = servIp;
            lbPORT.Text = servPort;
        }

        private void btnSendStatus_Click(object sender, EventArgs e)
        {
            TcpClient tcpclnt = new TcpClient();
            Stream stm;
            byte[] byteSend;
            byte[] byteReceive;
            tcpclnt.Connect("127.0.0.1", 12000);
            stm = tcpclnt.GetStream();
            ASCIIEncoding asen = new ASCIIEncoding();
            string status;
            if (count > 0)
            {
                status = "1";
            }
            else
            {
                status = "0";
            }
            byteSend = asen.GetBytes(servIp+":"+servPort+";"+ status);
            stm.Write(byteSend, 0, byteSend.Length);
            tcpclnt.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lbCountClient.Text = "0";
            socket = new Socket[100];
            server.Start();
            Thread t = new Thread(LoopServer);
            t.Start();
        }
        void LoopServer()
        {
            while (true)
            {
                socket[count] = server.AcceptSocket();
                count++;
                lbCountClient.Text = count.ToString();
                Thread t = new Thread(ServeClient);
                t.Start(count - 1);
            }
        }
        void ServeClient(object obj)
        {
            int index = (Int32)obj;

            byte[] b = new byte[100];
            int k = socket[index].Receive(b);
            //recv data
            string Data = System.Text.Encoding.UTF8.GetString(b);
            lbRecv.Text = Data;
            //resspond
            string str = "Hello Client";
            ASCIIEncoding asen = new ASCIIEncoding();
            socket[index].Send(asen.GetBytes(str));
          
            socket[index].Close();
        }
    }
}
