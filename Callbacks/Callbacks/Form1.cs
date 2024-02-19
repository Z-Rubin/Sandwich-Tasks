using System.Timers;

namespace Callbacks
{
    public partial class Form1 : Form
    {
        string logFile = $".\\Logs\\logs.log";

        SimpleMessageProvider SMP = new SimpleMessageProvider();
        Logger logger = Logger.Instance;


        public Form1()
        {
            InitializeComponent();
        }

        private async Task PrintEven(SimpleCustomArgs args)
        {
            rtbEven.Invoke((Action)(() => rtbEven.AppendText($"{args.CurrentDateTime}\n")));
        }
        private async Task PrintOdd(SimpleCustomArgs args)
        {
            rtbOdd.Invoke((Action)(() => rtbOdd.AppendText($"{args.CurrentDateTime}\n")));
        }

        private async void Print(object sender, ElapsedEventArgs e)
        {
            rtbNormal.Invoke(() => rtbNormal.AppendText($"{DateTime.Now}\n"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SMP.AddOnTimerEvent(Print);
            logger.LogInfo("Printing Even");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SMP.StartTimer();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SMP.AddSubscription(PrintOdd, "Odd");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SMP.AddSubscription(PrintEven, "Even");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SMP.RemoveOnTimerEvent(Print);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SMP.RemoveSubscription("Even");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SMP.RemoveSubscription("Odd");
        }
    }
}
