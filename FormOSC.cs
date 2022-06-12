using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalWatchOSC
{
    
    public partial class FormOSC : Form
    {
        
        public FormOSC() //생성자
        {
            InitializeComponent();
            TimeConfig.Load(); //프로그램 켤때 Settings.json 설정값 불러오기
            Program.ThreadStart = false;
            Program._sendingThread = new Thread(new ThreadStart(Program.SendingLoop));
            Program._sendingThread.Start();
        }

        #region (디버그용)나중에 시계로 교체할것
        internal void CurrentTime_log(string infoMessage)
        {
            if (InvokeRequired) 
            {
                this.CurrentTime.Invoke(new Action<string>(CurrentTime_log), new object[] { infoMessage });
                return;
            }
            AppendLineToTextbox(ref this.CurrentTime, infoMessage);

        }
        private void AppendLineToTextbox(ref TextBox textBox, string message)
        {
            textBox.AppendText(Environment.NewLine + message);
            //make sure we only show the last MAX_LINES lines of text
            if (textBox.Lines.Length > 50)
            {
                //only keep the last MAX_LINES of lines
                string[] newLines = new string[50];
                Array.Copy(textBox.Lines, 1, newLines, 0, 50);
                textBox.Lines = newLines;
                //scroll to the bottom
                textBox.SelectionStart = textBox.Text.Length;
                textBox.ScrollToCaret();
            }
        }
        #endregion

        #region 포트 숫자만 입력하게 하기
        private void text_sender_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (int.TryParse(text_sender.Text.Replace(",",""), out i))
            {
                text_sender.Text = i.ToString();
            }
            else
            {
                text_sender.Text = null;
            }

        }
        private void text_listener_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (int.TryParse(text_listener.Text.Replace(",", ""), out i))
            {
                text_listener.Text = i.ToString();
            }
            else
            {
                text_listener.Text = null;
            }
        }
        #endregion

        internal void button1_Click(object sender, EventArgs e)
        {
            if(Program.ThreadStart == false)
            {
                Program.ThreadStart = true;
            }
            groupBox1.Enabled = false;

            //전송 시작할 때 설정값 저장하기
            TimeConfig.Values.Minutes = text_minutes.Text;
            TimeConfig.Values.Hours = text_hours.Text;
            TimeConfig.Values.Month = text_month.Text;
            TimeConfig.Values.Days = text_day.Text;
            TimeConfig.Values.Wdays = text_wday.Text;
            TimeConfig.Values.PortSender = int.Parse(text_sender.Text);
            TimeConfig.Values.PortListener = int.Parse(text_listener.Text);
            TimeConfig.Values.IPAddress = text_ip.Text;
            TimeConfig.Save();

        }

        internal void button2_Click(object sender, EventArgs e)
        {
            if(Program.ThreadStart == true)
            {
                Program.ThreadStart = false;
            }
            groupBox1.Enabled = true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Program.ThreadStart = false;
            Program.Isloop = false;
            Program._sendingThread.Join();
            base.OnClosing(e);
        }
    }
}
