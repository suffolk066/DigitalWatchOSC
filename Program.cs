using System.Text;
using System.Text.Json;
using SharpOSC;

namespace DigitalWatchOSC
{

    #region Setting.json
    //참고 https://sourceexample.com/serialize-deserialize-app-settings-into-json-files-using-system.text.json-41f16/
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
        public static bool threadStart;
        public static bool isloop;
        public static Thread thread;
        public static UDPListener listener;
        public static UDPSender sender;
        private static FormOSC formOSC;
        private static EventHandler eventHandler;
        private static OscMessage mMinutes;
        private static OscMessage mHours;
        private static OscMessage mMonth;
        private static OscMessage mDay;
        private static OscMessage mWday;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            eventHandler = delegate {
                SetupSender();
                SetupReceiver();
                Application.Idle -= eventHandler;
            };
            Application.Idle += eventHandler;
            Application.ApplicationExit += delegate
            {
                listener.Dispose();
                thread.Join();
            };
            isloop = true;
            formOSC = new FormOSC(); //응애
            Application.Run(formOSC); //메인
        }
        private static void SetupSender()
        {
            var TimeConfig = new TimeConfig();
            {
                TimeConfig.IPAddress = formOSC.text_ip.Text;
                TimeConfig.PortSender = int.Parse(formOSC.text_sender.Text);
            }
            sender = new UDPSender(TimeConfig.IPAddress, TimeConfig.PortSender);
        }
        private static void SetupReceiver()
        {
            var TimeConfig = new TimeConfig();
            {
                TimeConfig.PortListener = 9001;
            }

            listener = new UDPListener(TimeConfig.PortListener);
        }
        public static void SendingLoop()
        {
            try
            {
                while (isloop)
                {
                    if(threadStart == true)
                    {
                        mMinutes = new OscMessage(formOSC.address.Text + formOSC.text_minutes.Text, DateTime.Now.Minute);
                        mHours = new OscMessage(formOSC.address.Text + formOSC.text_hours.Text, DateTime.Now.Hour);
                        mMonth = new OscMessage(formOSC.address.Text + formOSC.text_month.Text, DateTime.Now.Month);
                        mDay = new OscMessage(formOSC.address.Text + formOSC.text_day.Text, DateTime.Now.Day);
                        mWday = new OscMessage(formOSC.address.Text + formOSC.text_wday.Text, (int)DateTime.Now.DayOfWeek);

                        sender.Send(mMinutes);
                        sender.Send(mHours);
                        sender.Send(mMonth);
                        sender.Send(mDay);
                        sender.Send(mWday);

                        //디버그용 나중에 날릴거
                        formOSC.CurrentTime_log($"Sending: Minutes Int as {DateTime.Now.Minute} to {formOSC.address.Text + formOSC.text_minutes.Text}");
                        formOSC.CurrentTime_log($"Sending: Hours Int as {DateTime.Now.Hour} to {formOSC.address.Text + formOSC.text_hours.Text}");
                        formOSC.CurrentTime_log($"Sending: Month Int as {DateTime.Now.Month} to {formOSC.address.Text + formOSC.text_month.Text}");
                        formOSC.CurrentTime_log($"Sending: Day Int as {DateTime.Now.Day} to {formOSC.address.Text + formOSC.text_day.Text}");
                        formOSC.CurrentTime_log($"Sending: Wday Int as {(int)DateTime.Now.DayOfWeek} to {formOSC.address.Text + formOSC.text_wday.Text}");
                    }
                    Thread.Sleep(1000);
                }
            }
            finally
            {
                sender.Close();
            }
        }
    }
}