using SharpOSC;

namespace DigitalWatchOSC
{
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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //create code to finish the setup when Application.Run() finishes
            _applicationIdleHandler = delegate {
                SetupSender();
                SetupReceiver();
                //detach so that this doesn't run again
                Application.Idle -= _applicationIdleHandler;
            };
            //we must finish the setup after the application was created
            Application.Idle += _applicationIdleHandler;
            //we must free ressources when the application is about to get shut down
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
            _sender = new UDPSender("127.0.0.1", 9000); // 바꿔조
        }
        private static void SetupReceiver()
        {
            _listener = new UDPListener(9001); // 나중에 바꿀것 JSON XML 메모장 등등등
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

                        //디버그용
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