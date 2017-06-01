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
            this.label2 = new System.Windows.Forms.Label();
            this.tbNuma = new System.Windows.Forms.TextBox();
            this.tbNumb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConnectServer
            // 
            this.btnConnectServer.Location = new System.Drawing.Point(249, 86);
            this.btnConnectServer.Name = "btnConnectServer";
            this.btnConnectServer.Size = new System.Drawing.Size(125, 54);
            this.btnConnectServer.TabIndex = 0;
            this.btnConnectServer.Text = "SEND REQUEST TO SERVER";
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
            this.label3.Location = new System.Drawing.Point(170, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "PORT SERVER:";
            // 
            // lbPORT
            // 
            this.lbPORT.AutoSize = true;
            this.lbPORT.Location = new System.Drawing.Point(263, 13);
            this.lbPORT.Name = "lbPORT";
            this.lbPORT.Size = new System.Drawing.Size(0, 13);
            this.lbPORT.TabIndex = 2;
            // 
            // btnConnectRoot
            // 
            this.btnConnectRoot.Location = new System.Drawing.Point(249, 40);
            this.btnConnectRoot.Name = "btnConnectRoot";
            this.btnConnectRoot.Size = new System.Drawing.Size(125, 40);
            this.btnConnectRoot.TabIndex = 0;
            this.btnConnectRoot.Text = "CONNECT TO ROOT";
            this.btnConnectRoot.UseVisualStyleBackColor = true;
            this.btnConnectRoot.Click += new System.EventHandler(this.btnConnectRoot_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number a:";
            // 
            // tbNuma
            // 
            this.tbNuma.Location = new System.Drawing.Point(101, 40);
            this.tbNuma.Name = "tbNuma";
            this.tbNuma.Size = new System.Drawing.Size(116, 20);
            this.tbNuma.TabIndex = 4;
            // 
            // tbNumb
            // 
            this.tbNumb.Location = new System.Drawing.Point(101, 86);
            this.tbNumb.Name = "tbNumb";
            this.tbNumb.Size = new System.Drawing.Size(116, 20);
            this.tbNumb.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "+";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Number b:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Result:";
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(101, 120);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(116, 20);
            this.tbResult.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 150);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.tbNumb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbNuma);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNuma;
        private System.Windows.Forms.TextBox tbNumb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbResult;
    }
}

