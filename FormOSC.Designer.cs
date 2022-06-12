namespace DigitalWatchOSC
{
    partial class FormOSC
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
        public void InitializeComponent()
        {
            this.address = new System.Windows.Forms.Label();
            this.text_minutes = new System.Windows.Forms.TextBox();
            this.text_hours = new System.Windows.Forms.TextBox();
            this.text_month = new System.Windows.Forms.TextBox();
            this.text_day = new System.Windows.Forms.TextBox();
            this.text_wday = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.CurrentTime = new System.Windows.Forms.TextBox();
            this.IP = new System.Windows.Forms.Label();
            this.Sender = new System.Windows.Forms.Label();
            this.Listener = new System.Windows.Forms.Label();
            this.text_ip = new System.Windows.Forms.TextBox();
            this.text_sender = new System.Windows.Forms.TextBox();
            this.text_listener = new System.Windows.Forms.TextBox();
            this.Settings = new System.Windows.Forms.GroupBox();
            this.Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // address
            // 
            this.address.AutoSize = true;
            this.address.Location = new System.Drawing.Point(4, 30);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(113, 15);
            this.address.TabIndex = 1;
            this.address.Text = "/avatar/parameters/";
            // 
            // text_minutes
            // 
            this.text_minutes.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.text_minutes.Location = new System.Drawing.Point(4, 58);
            this.text_minutes.Name = "text_minutes";
            this.text_minutes.Size = new System.Drawing.Size(174, 23);
            this.text_minutes.TabIndex = 2;
            this.text_minutes.Text = "WatchMinutes";
            // 
            // text_hours
            // 
            this.text_hours.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.text_hours.Location = new System.Drawing.Point(4, 87);
            this.text_hours.Name = "text_hours";
            this.text_hours.Size = new System.Drawing.Size(174, 23);
            this.text_hours.TabIndex = 3;
            this.text_hours.Text = "WatchHours";
            // 
            // text_month
            // 
            this.text_month.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.text_month.Location = new System.Drawing.Point(4, 116);
            this.text_month.Name = "text_month";
            this.text_month.Size = new System.Drawing.Size(174, 23);
            this.text_month.TabIndex = 4;
            this.text_month.Text = "WatchMonth";
            // 
            // text_day
            // 
            this.text_day.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.text_day.Location = new System.Drawing.Point(4, 145);
            this.text_day.Name = "text_day";
            this.text_day.Size = new System.Drawing.Size(174, 23);
            this.text_day.TabIndex = 5;
            this.text_day.Text = "WatchDay";
            // 
            // text_wday
            // 
            this.text_wday.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.text_wday.Location = new System.Drawing.Point(4, 174);
            this.text_wday.Name = "text_wday";
            this.text_wday.Size = new System.Drawing.Size(174, 23);
            this.text_wday.TabIndex = 6;
            this.text_wday.Text = "WatchWday";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(190, 374);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 36);
            this.button2.TabIndex = 8;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CurrentTime
            // 
            this.CurrentTime.BackColor = System.Drawing.Color.PaleGreen;
            this.CurrentTime.Location = new System.Drawing.Point(15, 12);
            this.CurrentTime.Multiline = true;
            this.CurrentTime.Name = "CurrentTime";
            this.CurrentTime.ReadOnly = true;
            this.CurrentTime.ShortcutsEnabled = false;
            this.CurrentTime.Size = new System.Drawing.Size(344, 108);
            this.CurrentTime.TabIndex = 0;
            // 
            // IP
            // 
            this.IP.AutoSize = true;
            this.IP.Location = new System.Drawing.Point(210, 31);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(63, 15);
            this.IP.TabIndex = 9;
            this.IP.Text = "IP Address";
            // 
            // Sender
            // 
            this.Sender.AutoSize = true;
            this.Sender.Location = new System.Drawing.Point(210, 91);
            this.Sender.Name = "Sender";
            this.Sender.Size = new System.Drawing.Size(36, 15);
            this.Sender.TabIndex = 10;
            this.Sender.Text = "Port1";
            // 
            // Listener
            // 
            this.Listener.AutoSize = true;
            this.Listener.Location = new System.Drawing.Point(210, 154);
            this.Listener.Name = "Listener";
            this.Listener.Size = new System.Drawing.Size(36, 15);
            this.Listener.TabIndex = 11;
            this.Listener.Text = "Port2";
            // 
            // text_ip
            // 
            this.text_ip.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.text_ip.Location = new System.Drawing.Point(210, 58);
            this.text_ip.Name = "text_ip";
            this.text_ip.Size = new System.Drawing.Size(113, 23);
            this.text_ip.TabIndex = 12;
            this.text_ip.Text = "127.0.0.1";
            // 
            // text_sender
            // 
            this.text_sender.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.text_sender.Location = new System.Drawing.Point(210, 118);
            this.text_sender.Name = "text_sender";
            this.text_sender.Size = new System.Drawing.Size(113, 23);
            this.text_sender.TabIndex = 13;
            this.text_sender.Text = "9000";
            this.text_sender.TextChanged += new System.EventHandler(this.text_sender_TextChanged);
            // 
            // text_listener
            // 
            this.text_listener.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.text_listener.Location = new System.Drawing.Point(210, 181);
            this.text_listener.Name = "text_listener";
            this.text_listener.Size = new System.Drawing.Size(113, 23);
            this.text_listener.TabIndex = 14;
            this.text_listener.Text = "9001";
            this.text_listener.TextChanged += new System.EventHandler(this.text_listener_TextChanged);
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.text_listener);
            this.Settings.Controls.Add(this.text_sender);
            this.Settings.Controls.Add(this.text_ip);
            this.Settings.Controls.Add(this.text_wday);
            this.Settings.Controls.Add(this.Listener);
            this.Settings.Controls.Add(this.text_day);
            this.Settings.Controls.Add(this.Sender);
            this.Settings.Controls.Add(this.text_month);
            this.Settings.Controls.Add(this.IP);
            this.Settings.Controls.Add(this.text_hours);
            this.Settings.Controls.Add(this.text_minutes);
            this.Settings.Controls.Add(this.address);
            this.Settings.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Settings.Location = new System.Drawing.Point(15, 135);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(344, 220);
            this.Settings.TabIndex = 15;
            this.Settings.TabStop = false;
            this.Settings.Text = "Settings";
            // 
            // FormOSC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 428);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.CurrentTime);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormOSC";
            this.Text = "DigitalWatchOSC";
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Label address;
        public TextBox text_minutes;
        public TextBox text_hours;
        public TextBox text_month;
        public TextBox text_day;
        public TextBox text_wday;
        public TextBox CurrentTime;
        private Button button1;
        private Button button2;
        public Label IP;
        public Label Sender;
        public Label Listener;
        public TextBox text_ip;
        public TextBox text_sender;
        public TextBox text_listener;
        private GroupBox Settings;
    }
}