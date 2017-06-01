namespace Client
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
            this.btnConnectServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbIP = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbPORT = new System.Windows.Forms.Label();
            this.btnConnectRoot = new System.Windows.Forms.Button();
            this.lbRecv = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConnectServer
            // 
            this.btnConnectServer.Location = new System.Drawing.Point(384, 80);
            this.btnConnectServer.Name = "btnConnectServer";
            this.btnConnectServer.Size = new System.Drawing.Size(160, 62);
            this.btnConnectServer.TabIndex = 0;
            this.btnConnectServer.Text = "CONNECT TO SERVER";
            this.btnConnectServer.UseVisualStyleBackColor = true;
            this.btnConnectServer.Click += new System.EventHandler(this.btnConnectServer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP SERVER:";
            // 
            // lbIP
            // 
            this.lbIP.AutoSize = true;
            this.lbIP.Location = new System.Drawing.Point(86, 13);
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(0, 13);
            this.lbIP.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "PORT SERVER:";
            // 
            // lbPORT
            // 
            this.lbPORT.AutoSize = true;
            this.lbPORT.Location = new System.Drawing.Point(282, 13);
            this.lbPORT.Name = "lbPORT";
            this.lbPORT.Size = new System.Drawing.Size(0, 13);
            this.lbPORT.TabIndex = 2;
            // 
            // btnConnectRoot
            // 
            this.btnConnectRoot.Location = new System.Drawing.Point(384, 12);
            this.btnConnectRoot.Name = "btnConnectRoot";
            this.btnConnectRoot.Size = new System.Drawing.Size(160, 62);
            this.btnConnectRoot.TabIndex = 0;
            this.btnConnectRoot.Text = "CONNECT TO ROOT";
            this.btnConnectRoot.UseVisualStyleBackColor = true;
            this.btnConnectRoot.Click += new System.EventHandler(this.btnConnectRoot_Click);
            // 
            // lbRecv
            // 
            this.lbRecv.AutoSize = true;
            this.lbRecv.Location = new System.Drawing.Point(156, 92);
            this.lbRecv.Name = "lbRecv";
            this.lbRecv.Size = new System.Drawing.Size(66, 13);
            this.lbRecv.TabIndex = 3;
            this.lbRecv.Text = "Not connect";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 160);
            this.Controls.Add(this.lbRecv);
            this.Controls.Add(this.lbPORT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConnectRoot);
            this.Controls.Add(this.btnConnectServer);
            this.Name = "Form1";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnConnectServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbPORT;
        private System.Windows.Forms.Button btnConnectRoot;
        private System.Windows.Forms.Label lbRecv;
    }
}

