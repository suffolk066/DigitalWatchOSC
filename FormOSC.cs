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
            Program.ThreadStart = false;
            Program._sendingThread = new Thread(new ThreadStart(Program.SendingLoop));
            Program._sendingThread.Start();
        }
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
        internal void button1_Click(object sender, EventArgs e)
        {
            if(Program.ThreadStart == false)
            {
                Program.ThreadStart = true;
            }

        }

        internal void button2_Click(object sender, EventArgs e)
        {
            if(Program.ThreadStart == true)
            {
                Program.ThreadStart = false;
            }
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
