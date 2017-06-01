namespace LTM_Proj
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
            this.lvServers = new System.Windows.Forms.ListView();
            this.colServers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnDiscnt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvServers
            // 
            this.lvServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colServers,
            this.colIP,
            this.colPort,
            this.colStatus});
            this.lvServers.Location = new System.Drawing.Point(12, 12);
            this.lvServers.Name = "lvServers";
            this.lvServers.Size = new System.Drawing.Size(490, 625);
            this.lvServers.TabIndex = 0;
            this.lvServers.UseCompatibleStateImageBehavior = false;
            this.lvServers.View = System.Windows.Forms.View.Details;
            // 
            // colServers
            // 
            this.colServers.Text = "Servers";
            this.colServers.Width = 53;
            // 
            // colIP
            // 
            this.colIP.Text = "IP address";
            this.colIP.Width = 217;
            // 
            // colPort
            // 
            this.colPort.Text = "Port";
            this.colPort.Width = 95;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 121;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(531, 28);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(122, 114);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnDiscnt
            // 
            this.btnDiscnt.Location = new System.Drawing.Point(531, 160);
            this.btnDiscnt.Name = "btnDiscnt";
            this.btnDiscnt.Size = new System.Drawing.Size(122, 115);
            this.btnDiscnt.TabIndex = 2;
            this.btnDiscnt.Text = "DISCONNECT";
            this.btnDiscnt.UseVisualStyleBackColor = true;
            this.btnDiscnt.Click += new System.EventHandler(this.btnDiscnt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 649);
            this.Controls.Add(this.btnDiscnt);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lvServers);
            this.Name = "Form1";
            this.Text = "Root";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colIP;
        private System.Windows.Forms.ColumnHeader colPort;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colServers;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnDiscnt;
        protected System.Windows.Forms.ListView lvServers;


    }
}

