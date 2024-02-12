using log4net.Core;

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
                    timer1.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (timer1.Enabled)
                {
                    timer1.Enabled = false;
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
    }
}
