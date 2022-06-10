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
            this.SuspendLayout();
            // 
            // address
            // 
            this.address.AutoSize = true;
            this.address.Location = new System.Drawing.Point(31, 139);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(113, 15);
            this.address.TabIndex = 1;
            this.address.Text = "/avatar/parameters/";
            // 
            // text_minutes
            // 
            this.text_minutes.Location = new System.Drawing.Point(31, 165);
            this.text_minutes.Name = "text_minutes";
            this.text_minutes.Size = new System.Drawing.Size(174, 23);
            this.text_minutes.TabIndex = 2;
            this.text_minutes.Text = "WatchMinutes";
            // 
            // text_hours
            // 
            this.text_hours.Location = new System.Drawing.Point(31, 194);
            this.text_hours.Name = "text_hours";
            this.text_hours.Size = new System.Drawing.Size(174, 23);
            this.text_hours.TabIndex = 3;
            this.text_hours.Text = "WatchHours";
            // 
            // text_month
            // 
            this.text_month.Location = new System.Drawing.Point(31, 223);
            this.text_month.Name = "text_month";
            this.text_month.Size = new System.Drawing.Size(174, 23);
            this.text_month.TabIndex = 4;
            this.text_month.Text = "WatchMonth";
            // 
            // text_day
            // 
            this.text_day.Location = new System.Drawing.Point(31, 252);
            this.text_day.Name = "text_day";
            this.text_day.Size = new System.Drawing.Size(174, 23);
            this.text_day.TabIndex = 5;
            this.text_day.Text = "WatchDay";
            // 
            // text_wday
            // 
            this.text_wday.Location = new System.Drawing.Point(31, 281);
            this.text_wday.Name = "text_wday";
            this.text_wday.Size = new System.Drawing.Size(174, 23);
            this.text_wday.TabIndex = 6;
            this.text_wday.Text = "WatchWday";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(271, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(271, 239);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 36);
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
            this.CurrentTime.Size = new System.Drawing.Size(460, 108);
            this.CurrentTime.TabIndex = 0;
            // 
            // FormOSC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 327);
            this.Controls.Add(this.CurrentTime);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.text_wday);
            this.Controls.Add(this.text_day);
            this.Controls.Add(this.text_month);
            this.Controls.Add(this.text_hours);
            this.Controls.Add(this.text_minutes);
            this.Controls.Add(this.address);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormOSC";
            this.Text = "DigitalWatchOSC";
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
    }
}