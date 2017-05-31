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
        public static string servPort = "14000";
        public static TcpListener server;
        public static int count = 0;
        public static Socket[] socket;
        public Form1()
        {
            InitializeComponent();
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
            byteSend = asen.GetBytes(servIp+":"+servPort+";"+ count.ToString());
            stm.Write(byteSend, 0, byteSend.Length);
            tcpclnt.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            socket = new Socket[100];
            ipAd = IPAddress.Parse(servIp);
            server = new TcpListener(ipAd, int.Parse(servPort));
            server.Start();      
            while (true)
            {
                socket[count] = server.AcceptSocket();

                count++;
                Thread t = new Thread(ServeClient);
                t.Start(count - 1);
            }
            server.Stop();
        }
        static void ServeClient(object obj)
        {
            int index = (Int32)obj;

            byte[] b = new byte[100];
            int k = socket[index].Receive(b);
            //recv data
                
            //resspond
            String str = "";
            ASCIIEncoding asen = new ASCIIEncoding();
            socket[index].Send(asen.GetBytes(str));
          
            socket[index].Close();
        }
    }
}
