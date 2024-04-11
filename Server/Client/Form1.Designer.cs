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
            this.actions = new System.Windows.Forms.RichTextBox();
            this.if100 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.portnum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.clients = new System.Windows.Forms.RichTextBox();
            this.sps101 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // actions
            // 
            this.actions.Location = new System.Drawing.Point(12, 91);
            this.actions.Name = "actions";
            this.actions.Size = new System.Drawing.Size(192, 334);
            this.actions.TabIndex = 1;
            this.actions.Text = "";
            this.actions.TextChanged += new System.EventHandler(this.actions_TextChanged);
            // 
            // if100
            // 
            this.if100.Location = new System.Drawing.Point(532, 91);
            this.if100.Name = "if100";
            this.if100.Size = new System.Drawing.Size(202, 334);
            this.if100.TabIndex = 3;
            this.if100.Text = "";
            this.if100.TextChanged += new System.EventHandler(this.if100_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "All actions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(528, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "IF 100 connections";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(781, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "SPS 101 connections";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Connected clients";
            // 
            // portnum
            // 
            this.portnum.Location = new System.Drawing.Point(133, 523);
            this.portnum.Name = "portnum";
            this.portnum.Size = new System.Drawing.Size(100, 26);
            this.portnum.TabIndex = 8;
            this.portnum.TextChanged += new System.EventHandler(this.portnum_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 523);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Port number:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(258, 518);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 37);
            this.button1.TabIndex = 10;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // clients
            // 
            this.clients.Location = new System.Drawing.Point(258, 91);
            this.clients.Name = "clients";
            this.clients.Size = new System.Drawing.Size(199, 334);
            this.clients.TabIndex = 11;
            this.clients.Text = "";
            this.clients.TextChanged += new System.EventHandler(this.clients_TextChanged);
            // 
            // sps101
            // 
            this.sps101.Location = new System.Drawing.Point(785, 91);
            this.sps101.Name = "sps101";
            this.sps101.Size = new System.Drawing.Size(189, 334);
            this.sps101.TabIndex = 12;
            this.sps101.Text = "";
            this.sps101.TextChanged += new System.EventHandler(this.sps101_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(399, 518);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 37);
            this.button2.TabIndex = 13;
            this.button2.Text = "Disconnect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 736);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.sps101);
            this.Controls.Add(this.clients);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.portnum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.if100);
            this.Controls.Add(this.actions);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox actions;
        private System.Windows.Forms.RichTextBox if100;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox portnum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox clients;
        private System.Windows.Forms.RichTextBox sps101;
        private System.Windows.Forms.Button button2;
    }
}

