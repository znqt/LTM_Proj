using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private double TIMEOUT = 30;
        public static string servIp, servPort;
        public static string currIp, currPort;
        private Object lock1 = new Object();
        private TcpClient tcpclnt;
        private DateTime lasttime = DateTime.Now;
        Stream stm;
        private void ReqAndResp(string na,string nb)
        {
            tcpclnt = new TcpClient();

            if (currIp != "" && currPort != "")
            {
                tcpclnt.Connect(currIp, int.Parse(currPort));
            }
            else
            {
                return;
            }
            byte[] byteSend;
            byte[] byteReceive;
            tcpclnt.ReceiveTimeout = 15000;
            stm = tcpclnt.GetStream();
            ASCIIEncoding asen = new ASCIIEncoding();
            string send = na + ";" + nb;
            byteSend = asen.GetBytes(send);
            stm.Write(byteSend, 0, byteSend.Length);
            if (na == "c" & nb == "c")
            {
                return;
            }
            byteReceive = new byte[100];
            int k = stm.Read(byteReceive, 0, 100);
            string recv = System.Text.Encoding.UTF8.GetString(byteReceive);
            tbResult.Text = recv;
            
            
            tcpclnt.Close();
        }
        private void btnConnectServer_Click(object sender, EventArgs e)
        {
            try
            {
                ReqAndResp(tbNuma.Text, tbNumb.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Current Server was shutdown.\nConnecting another Server...");
                Thread b = new Thread(ConnectRoot);
                b.IsBackground = true;
                b.Start();
                b.Join();
                if (currIp != "" && currPort != "")
                {
                    ReqAndResp(tbNuma.Text, tbNumb.Text);
                }
            }
        }

        private void ConnectRoot()
        {
            TcpClient tcpclnt = new TcpClient();
            Stream stm;
            byte[] byteSend;
            byte[] byteReceive;

            tcpclnt.Connect("127.0.0.1", 13000);

            stm = tcpclnt.GetStream();
            //send I'm alive    
            ASCIIEncoding asen = new ASCIIEncoding();
            byteSend = asen.GetBytes("1");
            stm.Write(byteSend, 0, byteSend.Length);
            //receive IP PORT server for connecting
            byteReceive = new byte[100];
            int k = stm.Read(byteReceive, 0, 100);
            string Data = System.Text.Encoding.UTF8.GetString(byteReceive);
            if (Data.Substring(0, 4).Equals("FULL"))
            {
                currIp = "";
                currPort = "";
                MessageBox.Show("Server Full!");
                tcpclnt.Close();
                return;
            }
            int j = Data.IndexOf(":");
            currIp = Data.Substring(0, j);
            currPort = Data.Substring(j + 1, k - 1 - j);
            ReqAndResp("c", "c");
            lock (lock1)
            {
                lbIP.Text = currIp;
                lbPORT.Text = currPort;
            }
            if (servIp == null && servPort==null)
            {
                servIp = currIp;
                servPort = currPort;
            }
            lasttime = DateTime.Now;
            tcpclnt.Close();
            Thread t = new Thread(SetPortA);
            t.IsBackground = true;
            t.Start();
        }

        private void SetPortA()
        {
            while (true)
            {
                lock (lock1)
                {
                    DateTime currentTime = DateTime.Now;
                    double t = ((TimeSpan)(currentTime - lasttime)).TotalSeconds;
                    if (t > TIMEOUT)
                    {
                        if (currPort != servPort)
                        {
                            if (PingHost(servIp, servPort))
                            {

                                MessageBox.Show(string.Format("Reconnect to {0}:{1}", servIp, servPort));
                                currIp = servIp;
                                currPort = servPort;
                                lbIP.Text = currIp;
                                lbPORT.Text = currPort;

                            }
                        }
                        lasttime = DateTime.Now;
                    }
                }
            }
        }

        private bool PingHost(string ip, string port)
        {
            try
            {
                TcpClient tcpc = new TcpClient(ip, int.Parse(port));
                tcpc.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void btnConnectRoot_Click(object sender, EventArgs e)
        {
            Thread a = new Thread(ConnectRoot);
            a.IsBackground = true;
            a.Start();
        }
    }
}
