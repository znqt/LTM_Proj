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

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string servIp, servPort;

        private void btnConnectServer_Click(object sender, EventArgs e)
        {
            TcpClient tcpclnt = new TcpClient();
            Stream stm;
            byte[] byteSend;
            byte[] byteReceive;

            tcpclnt.Connect(servIp, int.Parse(servPort));

            stm = tcpclnt.GetStream();
            ASCIIEncoding asen = new ASCIIEncoding();
            string send = "Hello Server";
            byteSend = asen.GetBytes(send);
            stm.Write(byteSend, 0, byteSend.Length);

            byteReceive = new byte[100];
            int k = stm.Read(byteReceive, 0, 100);
            string recv = System.Text.Encoding.UTF8.GetString(byteReceive);
            lbRecv.Text = recv;
            tcpclnt.Close();
        }

        private void btnConnectRoot_Click(object sender, EventArgs e)
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
            int j = Data.IndexOf(":");
            servIp = Data.Substring(0, j);
            servPort = Data.Substring(j + 1, k - 1 - j);
            lbIP.Text = servIp;
            lbPORT.Text = servPort;

            tcpclnt.Close();
        }
    }
}
