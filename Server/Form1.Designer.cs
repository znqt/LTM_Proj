namespace Server
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lbIP = new System.Windows.Forms.Label();
            this.lbPORT = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCountClient = new System.Windows.Forms.Label();
            this.lbRecv = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnDis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP:";
            // 
            // lbIP
            // 
            this.lbIP.AutoSize = true;
            this.lbIP.Location = new System.Drawing.Point(42, 12);
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(0, 13);
            this.lbIP.TabIndex = 3;
            // 
            // lbPORT
            // 
            this.lbPORT.AutoSize = true;
            this.lbPORT.Location = new System.Drawing.Point(182, 12);
            this.lbPORT.Name = "lbPORT";
            this.lbPORT.Size = new System.Drawing.Size(0, 13);
            this.lbPORT.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "PORT:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Total Client:";
            // 
            // lbCountClient
            // 
            this.lbCountClient.AutoSize = true;
            this.lbCountClient.Location = new System.Drawing.Point(350, 12);
            this.lbCountClient.Name = "lbCountClient";
            this.lbCountClient.Size = new System.Drawing.Size(0, 13);
            this.lbCountClient.TabIndex = 7;
            // 
            // lbRecv
            // 
            this.lbRecv.AutoSize = true;
            this.lbRecv.Location = new System.Drawing.Point(203, 114);
            this.lbRecv.Name = "lbRecv";
            this.lbRecv.Size = new System.Drawing.Size(66, 13);
            this.lbRecv.TabIndex = 8;
            this.lbRecv.Text = "Not connect";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(175, 9);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(94, 20);
            this.tbPort.TabIndex = 9;
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(471, 9);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(106, 68);
            this.btnStartServer.TabIndex = 10;
            this.btnStartServer.Text = "START SERVER";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // btnDis
            // 
            this.btnDis.Location = new System.Drawing.Point(471, 86);
            this.btnDis.Name = "btnDis";
            this.btnDis.Size = new System.Drawing.Size(106, 68);
            this.btnDis.TabIndex = 1;
            this.btnDis.Text = "DISCONNECT";
            this.btnDis.UseVisualStyleBackColor = true;
            this.btnDis.Click += new System.EventHandler(this.btnDis_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 169);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.lbRecv);
            this.Controls.Add(this.lbCountClient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbPORT);
            this.Controls.Add(this.lbIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDis);
            this.Name = "Form1";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbIP;
        private System.Windows.Forms.Label lbPORT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbCountClient;
        private System.Windows.Forms.Label lbRecv;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnDis;
    }
}

