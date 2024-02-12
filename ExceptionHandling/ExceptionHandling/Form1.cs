using log4net.Core;
using System.Threading;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]


namespace ExceptionHandling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static System.Timers.Timer systemTimer;
        public static System.Threading.Timer threadTimer;


        private void button1_Click(object sender, EventArgs e)
        {
            Logger.Info("Logger logging");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            throw new Exception("No Catch");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                throw new Exception("No Catch");
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (timer1.Enabled)
                {
                    throw new Exception("Form Timer is already enabled");
                }
                else
                {
                    timer1.Tick += asyncOnFormTimer;
                    //timer1.Tick += asyncTaskOnFormTimer;
                    timer1.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private async void asyncOnFormTimer(object sender, EventArgs e)
        {
            try
            {
                Logger.Info("asyncFormTimer tick");
                forX(100000000);

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        private async Task asyncTaskOnFormTimer(object sender, EventArgs e)
        {
            try
            {
                forX(100000000);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Logger.Info("FormTimer tick");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (timer1.Enabled)
                {
                    timer1.Enabled = false;
                    timer1.Tick -= asyncOnFormTimer;
                }
                else
                {
                    throw new Exception("Form Timer is already disabled");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (systemTimer.Enabled)
                {
                    throw new Exception("System Timer is already enabled");
                }
                else
                {
                    systemTimer.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            systemTimer = new System.Timers.Timer(5000);
            systemTimer.Elapsed += OnSystemTimer;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            systemTimer.Dispose();
        }

        private void OnSystemTimer(object sender, EventArgs e)
        {
            Logger.Info("SystemTimer tick");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (systemTimer.Enabled)
                {
                    systemTimer.Enabled = false;
                }
                else
                {
                    throw new Exception("System Timer is already disabled");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void OnThreadTimer(object sender)
        {
            Logger.Info("ThreadTimer tick");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (threadTimer == null)
                {
                    throw new Exception("Cannot stop as threadTimer is null");
                }
                threadTimer.Dispose();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var autoEvent = new AutoResetEvent(false);

            threadTimer = new System.Threading.Timer(OnThreadTimer, autoEvent, 5000, 5000);
        }



        private double div(double x, double y)
        {
            if (y == 0)
            {
                throw new Exception("Divide by zero error");
            }
            else
            {
                return x / y;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                double div_result = div(10, 0);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private async Task forX(long x)
        {
            for (int i = 0; i < x; i++)
            {

            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            for (int i = 0; i < 5; i++)
            {
                forX(1000000000);
            }

            watch.Stop();
            Logger.Info(watch.Elapsed.ToString());
        }

        private async void button14_Click(object sender, EventArgs e)
        {
            // Splits the five forXs onto 5 different threads for concurrent computing
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            for (int i = 0; i < 5; i++)
            {
                Task.Run(async () => { forX(1000000000); });
            }



            watch.Stop();
            Logger.Info(watch.Elapsed.ToString());
        }


        private void MethodA()
        {
            MethodB();
        }

        private void MethodB()
        {
            MethodC();
        }

        private void MethodC()
        {
            throw new Exception("Method C throwing");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                MethodA();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // does not catch the error
            try
            {
                Task.Run(() =>
                {
                    MethodC();
                });
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    MethodC();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }
            });
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    button20.Text = toggleOnOff(button20.Text);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }
            });
        }
        private string toggleOnOff(string s)
        {
            if (s == "On")
            {
                return "Off";
            }
            else
            {
                return "On";
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        button20.Text = toggleOnOff(button20.Text);

                    });
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }
            });
        }
    }
}
