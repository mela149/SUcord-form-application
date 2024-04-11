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
            this.portnum = new System.Windows.Forms.TextBox();
            this.ipnum = new System.Windows.Forms.TextBox();
            this.usernametextbox = new System.Windows.Forms.TextBox();
            this.if100 = new System.Windows.Forms.RichTextBox();
            this.sps101 = new System.Windows.Forms.RichTextBox();
            this.textBox_if = new System.Windows.Forms.TextBox();
            this.textBox_sps = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_connect = new System.Windows.Forms.Button();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.button_unsubscribe_if = new System.Windows.Forms.Button();
            this.button_subscribe_if = new System.Windows.Forms.Button();
            this.button_unsubscribe_sps = new System.Windows.Forms.Button();
            this.button_subscribe_sps = new System.Windows.Forms.Button();
            this.button_send_if = new System.Windows.Forms.Button();
            this.button_send_sps = new System.Windows.Forms.Button();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // portnum
            // 
            this.portnum.Location = new System.Drawing.Point(291, 39);
            this.portnum.Name = "portnum";
            this.portnum.Size = new System.Drawing.Size(100, 26);
            this.portnum.TabIndex = 0;
            this.portnum.TextChanged += new System.EventHandler(this.portnum_TextChanged);
            // 
            // ipnum
            // 
            this.ipnum.Location = new System.Drawing.Point(449, 39);
            this.ipnum.Name = "ipnum";
            this.ipnum.Size = new System.Drawing.Size(100, 26);
            this.ipnum.TabIndex = 1;
            this.ipnum.TextChanged += new System.EventHandler(this.ipnum_TextChanged);
            // 
            // usernametextbox
            // 
            this.usernametextbox.Location = new System.Drawing.Point(95, 39);
            this.usernametextbox.Name = "usernametextbox";
            this.usernametextbox.Size = new System.Drawing.Size(100, 26);
            this.usernametextbox.TabIndex = 2;
            this.usernametextbox.TextChanged += new System.EventHandler(this.usernametextbox_TextChanged);
            // 
            // if100
            // 
            this.if100.Location = new System.Drawing.Point(299, 119);
            this.if100.Name = "if100";
            this.if100.Size = new System.Drawing.Size(207, 243);
            this.if100.TabIndex = 4;
            this.if100.Text = "";
            this.if100.TextChanged += new System.EventHandler(this.if100_TextChanged);
            // 
            // sps101
            // 
            this.sps101.Location = new System.Drawing.Point(573, 119);
            this.sps101.Name = "sps101";
            this.sps101.Size = new System.Drawing.Size(210, 243);
            this.sps101.TabIndex = 5;
            this.sps101.Text = "";
            this.sps101.TextChanged += new System.EventHandler(this.sps101_TextChanged);
            // 
            // textBox_if
            // 
            this.textBox_if.Location = new System.Drawing.Point(379, 410);
            this.textBox_if.Multiline = true;
            this.textBox_if.Name = "textBox_if";
            this.textBox_if.Size = new System.Drawing.Size(100, 95);
            this.textBox_if.TabIndex = 6;
            this.textBox_if.TextChanged += new System.EventHandler(this.textBox_if_TextChanged);
            // 
            // textBox_sps
            // 
            this.textBox_sps.Location = new System.Drawing.Point(657, 410);
            this.textBox_sps.Multiline = true;
            this.textBox_sps.Name = "textBox_sps";
            this.textBox_sps.Size = new System.Drawing.Size(100, 95);
            this.textBox_sps.TabIndex = 7;
            this.textBox_sps.TextChanged += new System.EventHandler(this.textBox_sps_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "IF 100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(415, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "IP:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(239, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Port: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(569, 413);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Message: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(295, 413);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Message:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(569, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "SPS 101";
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(562, 33);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(104, 38);
            this.button_connect.TabIndex = 16;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // button_disconnect
            // 
            this.button_disconnect.Location = new System.Drawing.Point(672, 33);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(111, 38);
            this.button_disconnect.TabIndex = 17;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // button_unsubscribe_if
            // 
            this.button_unsubscribe_if.Location = new System.Drawing.Point(397, 368);
            this.button_unsubscribe_if.Name = "button_unsubscribe_if";
            this.button_unsubscribe_if.Size = new System.Drawing.Size(113, 31);
            this.button_unsubscribe_if.TabIndex = 18;
            this.button_unsubscribe_if.Text = "Unsubscribe";
            this.button_unsubscribe_if.UseVisualStyleBackColor = true;
            this.button_unsubscribe_if.Click += new System.EventHandler(this.button_unsubscribe_if_Click);
            // 
            // button_subscribe_if
            // 
            this.button_subscribe_if.Location = new System.Drawing.Point(299, 368);
            this.button_subscribe_if.Name = "button_subscribe_if";
            this.button_subscribe_if.Size = new System.Drawing.Size(92, 31);
            this.button_subscribe_if.TabIndex = 19;
            this.button_subscribe_if.Text = "Subscribe";
            this.button_subscribe_if.UseVisualStyleBackColor = true;
            this.button_subscribe_if.Click += new System.EventHandler(this.button_subscribe_if_Click);
            // 
            // button_unsubscribe_sps
            // 
            this.button_unsubscribe_sps.Location = new System.Drawing.Point(672, 368);
            this.button_unsubscribe_sps.Name = "button_unsubscribe_sps";
            this.button_unsubscribe_sps.Size = new System.Drawing.Size(111, 31);
            this.button_unsubscribe_sps.TabIndex = 20;
            this.button_unsubscribe_sps.Text = "Unsubscribe";
            this.button_unsubscribe_sps.UseVisualStyleBackColor = true;
            this.button_unsubscribe_sps.Click += new System.EventHandler(this.button_unsubscribe_sps_Click);
            // 
            // button_subscribe_sps
            // 
            this.button_subscribe_sps.Location = new System.Drawing.Point(573, 368);
            this.button_subscribe_sps.Name = "button_subscribe_sps";
            this.button_subscribe_sps.Size = new System.Drawing.Size(93, 31);
            this.button_subscribe_sps.TabIndex = 21;
            this.button_subscribe_sps.Text = "Subscribe";
            this.button_subscribe_sps.UseVisualStyleBackColor = true;
            this.button_subscribe_sps.Click += new System.EventHandler(this.button_subscribe_sps_Click);
            // 
            // button_send_if
            // 
            this.button_send_if.Location = new System.Drawing.Point(379, 517);
            this.button_send_if.Name = "button_send_if";
            this.button_send_if.Size = new System.Drawing.Size(75, 33);
            this.button_send_if.TabIndex = 22;
            this.button_send_if.Text = "Send";
            this.button_send_if.UseVisualStyleBackColor = true;
            this.button_send_if.Click += new System.EventHandler(this.button_send_if_Click);
            // 
            // button_send_sps
            // 
            this.button_send_sps.Location = new System.Drawing.Point(657, 517);
            this.button_send_sps.Name = "button_send_sps";
            this.button_send_sps.Size = new System.Drawing.Size(75, 33);
            this.button_send_sps.TabIndex = 23;
            this.button_send_sps.Text = "Send";
            this.button_send_sps.UseVisualStyleBackColor = true;
            this.button_send_sps.Click += new System.EventHandler(this.button_send_sps_Click);
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(16, 190);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(226, 243);
            this.logs.TabIndex = 24;
            this.logs.Text = "";
            this.logs.TextChanged += new System.EventHandler(this.logs_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Logs";
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(95, 71);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(75, 45);
            this.button_login.TabIndex = 26;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 580);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.button_send_sps);
            this.Controls.Add(this.button_send_if);
            this.Controls.Add(this.button_subscribe_sps);
            this.Controls.Add(this.button_unsubscribe_sps);
            this.Controls.Add(this.button_subscribe_if);
            this.Controls.Add(this.button_unsubscribe_if);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_sps);
            this.Controls.Add(this.textBox_if);
            this.Controls.Add(this.sps101);
            this.Controls.Add(this.if100);
            this.Controls.Add(this.usernametextbox);
            this.Controls.Add(this.ipnum);
            this.Controls.Add(this.portnum);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox portnum;
        private System.Windows.Forms.TextBox ipnum;
        private System.Windows.Forms.TextBox usernametextbox;
        private System.Windows.Forms.RichTextBox if100;
        private System.Windows.Forms.RichTextBox sps101;
        private System.Windows.Forms.TextBox textBox_if;
        private System.Windows.Forms.TextBox textBox_sps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.Button button_unsubscribe_if;
        private System.Windows.Forms.Button button_subscribe_if;
        private System.Windows.Forms.Button button_unsubscribe_sps;
        private System.Windows.Forms.Button button_subscribe_sps;
        private System.Windows.Forms.Button button_send_if;
        private System.Windows.Forms.Button button_send_sps;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_login;
    }
}

