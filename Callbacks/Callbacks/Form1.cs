using System.Timers;

namespace Callbacks
{
    public partial class Form1 : Form
    {

        private SimpleMessageProvider _simpleMessaveProvider = SimpleMessageProvider.Instance;
        public Logger Logger = Logger.Instance;
        public Form1()
        {
            InitializeComponent();
        }
        private async Task PrintEven(SimpleEventArgs args)
        {
            try
            {
                rtbEven.Invoke((Action)(() => rtbEven.AppendText($"{args.CurrentDateTime}\n")));
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex);
            }
        }
        private async Task PrintOdd(SimpleEventArgs args)
        {
            try
            {
                rtbOdd.Invoke((Action)(() => rtbOdd.AppendText($"{args.CurrentDateTime}\n")));
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex);
            }
        }
        private void Print(object sender, SimpleEventArgs e)
        {
            try
            {
                rtbNormal.Invoke(() => rtbNormal.AppendText($"{DateTime.Now}\n"));
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex);
            }
        }
        private async Task PrintWorkerName(SimpleEventArgs e)
        {
            try
            {
                rtbWorkerName.Invoke(() => rtbWorkerName.AppendText($"Worker Name: {Thread.CurrentThread.ManagedThreadId} - {DateTime.Now}\n"));
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _simpleMessaveProvider.StartTimer();
        }
        private void btnNormalSubscribe_Click(object sender, EventArgs e)
        {
            _simpleMessaveProvider.AddSimpleSubscription(Print);
        }
        private void btnNormalUnsubscribe_Click(object sender, EventArgs e)
        {
            _simpleMessaveProvider.RemoveSimpleSubscription(Print);
        }
        private void btnEvenSubscribe_Click(object sender, EventArgs e)
        {
            _simpleMessaveProvider.AddSubscription(PrintEven, "Even");
        }
        private void btnEvenUnsunscribe_Click(object sender, EventArgs e)
        {
            _simpleMessaveProvider.RemoveSubscription(PrintEven, "Even");
        }
        private void btnOddSubscribe_Click(object sender, EventArgs e)
        {
            _simpleMessaveProvider.AddSubscription(PrintOdd, "Odd");
        }
        private void btnOddUnsubscribe_Click(object sender, EventArgs e)
        {
            _simpleMessaveProvider.RemoveSubscription(PrintOdd, "Odd");
        }
        private void btnSubscribeEvenThreadName_Click(object sender, EventArgs e)
        {
            _simpleMessaveProvider.AddSubscription(PrintWorkerName, "Even");
        }
        private void btnUnsubscribeEvenThreadName_Click(object sender, EventArgs e)
        {
            _simpleMessaveProvider.RemoveSubscription(PrintWorkerName, "Even");
        }
    }
}
