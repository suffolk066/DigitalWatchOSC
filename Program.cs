using SharpOSC;

namespace DigitalWatchOSC
{
    static class Program
    {

        private static EventHandler _applicationIdleHandler;
        internal static Thread _sendingThread;
        private static FormOSC _formOSC;
        private static UDPListener _listener;
        private static UDPSender _sender;
        private static OscMessage _messageMinutes;
        private static OscMessage _messageHours;
        private static OscMessage _messageMonth;
        private static OscMessage _messageDay;
        private static OscMessage _messageWday;

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
                _listener.Close();
                _listener.Dispose();
                _sender.Close();
                _sendingThread.Join();
            };
            _formOSC = new FormOSC();
            Application.Run(_formOSC);
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
            _sender = new UDPSender("127.0.0.1", 9000);
        }
        private static void SetupReceiver()
        {
            _listener = new UDPListener(9001);
        }
        internal static void SendingLoop()
        {
            try
            {
                while (true)
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
                    _formOSC.CurrentTime_log($"Sending: Minutes Int as {Minutes()} to {_formOSC.address.Text + _formOSC.text_minutes.Text}");
                    _formOSC.CurrentTime_log($"Sending: Hours Int as {Hours()} to {_formOSC.address.Text + _formOSC.text_hours.Text}");
                    _formOSC.CurrentTime_log($"Sending: Month Int as {Month()} to {_formOSC.address.Text + _formOSC.text_month.Text}");
                    _formOSC.CurrentTime_log($"Sending: Day Int as {Day()} to {_formOSC.address.Text + _formOSC.text_day.Text}");
                    _formOSC.CurrentTime_log($"Sending: Wday Int as {Wday()} to {_formOSC.address.Text + _formOSC.text_wday.Text}");

                    Thread.Sleep(5000);
                }
            }
            finally
            {
                _sender.Close();
            }
        }
    }
}