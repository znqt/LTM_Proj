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
        public static int Port;
        public static string servIp = "127.0.0.1";
        public static string servPort;
        public static TcpListener server;
        public static int count = 0;
        public static Socket[] socket;
        public string status;
        public static double TIMEOUT=30;
        public static DateTime LastTime=DateTime.Now;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            
        }
        private void btnStartServer_Click(object sender, EventArgs e)
        {
            StartServer();
        }
        public void StartServer()
        {
            try
            {
                if (tbPort.Text == "")
                {
                    return;
                }
                servPort = tbPort.Text;
                ipAd = IPAddress.Parse(servIp);
                Port = int.Parse(tbPort.Text);
                server = new TcpListener(ipAd, Port);
                //server.Start();

                SendStatus();
                LastTime = DateTime.Now;
                lbIP.Text = servIp;

                lbCountClient.Text = "0";
                socket = new Socket[100];
                server.Start();
                Thread t = new Thread(LoopServer);
                t.Start();

                //lbPORT.Text = servPort;
                Thread time = new Thread(CheckTime);
                time.Start();
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.StackTrace);
            }
        }

        public static void CheckTime()
        {
            while (true)
            {
                DateTime currentTime = DateTime.Now;
                double lastUpdate = ((TimeSpan)(currentTime - LastTime)).TotalSeconds;
                if (lastUpdate > TIMEOUT)
                {
                    LastTime = DateTime.Now;
                    SendStatus();
                }
            }
        }

        private static void SendStatus()
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
            byteSend = asen.GetBytes(servIp + ":" + servPort + ";" + status);
            stm.Write(byteSend, 0, byteSend.Length);
            tcpclnt.Close();
            
        }

        private void btnDis_Click(object sender, EventArgs e)
        {
            try
            {
                server.Stop();
            }
            catch
            {
                return;
            }
        }

        void LoopServer()
        {
            while (true)
            {
                try
                {
                    socket[count] = server.AcceptSocket();
                    count++;
                    lbCountClient.Text = count.ToString();
                    Thread t = new Thread(ServeClient);
                    t.Start(count - 1);
                }
                catch
                {
                    return;
                }
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
