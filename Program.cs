using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using SharpOSC;

namespace DigitalWatchOSC
{

    #region Setting.json
    public class TimeConfig
    {
        public static TimeConfig Values { get; private set; }
        public string Minutes { get; set; }
        public string Hours { get; set; }
        public string Month { get; set; } 
        public string Days { get; set; }
        public string Wdays { get; set; }
        public int PortSender { get; set; }
        public int PortListener { get; set; }
        public string IPAddress { get; set; }


        public TimeConfig() { } //이게모임??

        public static void Save()
        {
            if (Values == null)
                Values = new TimeConfig();
            File.WriteAllText ("Settings.json", JsonSerializer.Serialize(Values, new JsonSerializerOptions() { WriteIndented = true }), Encoding.UTF8);
        }
        public static void Load()
        {
            if (!File.Exists("Settings.json"))
                Save();
            Values = JsonSerializer.Deserialize<TimeConfig>(File.ReadAllText("Settings.json", Encoding.UTF8));
        }
    }

    #endregion
    static class Program
    {

        private static EventHandler _applicationIdleHandler;
        public static Thread _sendingThread;
        private static FormOSC _formOSC;
        public static UDPListener _listener;
        public static UDPSender _sender;
        private static OscMessage _messageMinutes;
        private static OscMessage _messageHours;
        private static OscMessage _messageMonth;
        private static OscMessage _messageDay;
        private static OscMessage _messageWday;
        public static bool ThreadStart;
        public static bool Isloop;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _applicationIdleHandler = delegate {
                SetupSender();
                SetupReceiver();
                Application.Idle -= _applicationIdleHandler;
            };
            Application.Idle += _applicationIdleHandler;
            Application.ApplicationExit += delegate
            {
                //_listener.Close();
                _listener.Dispose();
                //_sender.Close();
                _sendingThread.Join();
            };
            Isloop = true;
            _formOSC = new FormOSC(); //응애
            Application.Run(_formOSC); //메인
        }
        private static int Minutes()
        {
            int minuteint = DateTime.Now.Minute;
            return minuteint;
        }
        private static int Hours()
        {
            int hourint = DateTime.Now.Hour;
            return hourint;
        }
        private static int Month()
        {
            int monthint = DateTime.Now.Month;
            return monthint;
        }
        private static int Day()
        {
            int dayint = DateTime.Now.Day;
            return dayint;
        }
        private static int Wday()
        {
            int wdayint = (int)DateTime.Now.DayOfWeek;
            return wdayint;
        }
        private static void SetupSender()
        {
            var TimeConfig = new TimeConfig();
            {
                TimeConfig.IPAddress = _formOSC.text_ip.Text;
                TimeConfig.PortSender = int.Parse(_formOSC.text_sender.Text);
            }
            _sender = new UDPSender(TimeConfig.IPAddress, TimeConfig.PortSender);
        }
        private static void SetupReceiver()
        {
            var TimeConfig = new TimeConfig();
            {
                TimeConfig.PortListener = 9001;
            }

            _listener = new UDPListener(TimeConfig.PortListener);
        }
        public static void SendingLoop()
        {
            try
            {
                while (Isloop)
                {
                    if(ThreadStart == true)
                    {
                        _messageMinutes = new OscMessage(_formOSC.address.Text + _formOSC.text_minutes.Text, Minutes());
                        _messageHours = new OscMessage(_formOSC.address.Text + _formOSC.text_hours.Text, Hours());
                        _messageMonth = new OscMessage(_formOSC.address.Text + _formOSC.text_month.Text, Month());
                        _messageDay = new OscMessage(_formOSC.address.Text + _formOSC.text_day.Text, Day());
                        _messageWday = new OscMessage(_formOSC.address.Text + _formOSC.text_wday.Text, Wday());

                        _sender.Send(_messageMinutes);
                        _sender.Send(_messageHours);
                        _sender.Send(_messageMonth);
                        _sender.Send(_messageDay);
                        _sender.Send(_messageWday);

                        //디버그용 나중에 날릴거
                        _formOSC.CurrentTime_log($"=============={ Minutes()}");
                        _formOSC.CurrentTime_log($"Sending: Minutes Int as {Minutes()} to {_formOSC.address.Text + _formOSC.text_minutes.Text}");
                        _formOSC.CurrentTime_log($"Sending: Hours Int as {Hours()} to {_formOSC.address.Text + _formOSC.text_hours.Text}");
                        _formOSC.CurrentTime_log($"Sending: Month Int as {Month()} to {_formOSC.address.Text + _formOSC.text_month.Text}");
                        _formOSC.CurrentTime_log($"Sending: Day Int as {Day()} to {_formOSC.address.Text + _formOSC.text_day.Text}");
                        _formOSC.CurrentTime_log($"Sending: Wday Int as {Wday()} to {_formOSC.address.Text + _formOSC.text_wday.Text}");
                    }
                    Thread.Sleep(1000);
                }
            }
            finally
            {
                _sender.Close();
            }
        }
    }
}