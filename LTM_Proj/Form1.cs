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
        Root ROOT = new Root();
        private Object thislock = new Object();
        public static int flag = 1;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ROOT.Start();
            Thread t = new Thread(DisplayListView);
            t.Start();
        }

        private void DisplayListView()
        {
            Helper.log("Start thread: DisplayListView.");
            while (true)
            {         
                if (flag==1)
                {
                    UpdateListView();
                }
            }
        }
        void UpdateListView()
        {
            int j = 1;
            lvServers.Items.Clear();
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
            flag = 0;
        }

        private void btnDiscnt_Click(object sender, EventArgs e)
        {
            ROOT.Disconnect();
        }
    }
}
