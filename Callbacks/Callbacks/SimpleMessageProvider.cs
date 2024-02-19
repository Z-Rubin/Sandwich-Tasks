using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Callbacks
{
    internal class SimpleMessageProvider
    {
        public SimpleMessageProvider() { }
        private System.Timers.Timer? _secondTimer = null;
        private ConcurrentDictionary<string, Func<SimpleCustomArgs, Task>> _subscriptions = new ConcurrentDictionary<string, Func<SimpleCustomArgs, Task>>();
        private Boolean _evenTick;

        public void AddSubscription(Func<SimpleCustomArgs, Task> callBackFunction, string oddOrEven)
        {
                _subscriptions.AddOrUpdate(oddOrEven, callBackFunction, (key, oldValue) => callBackFunction);
        }
        public void RemoveSubscription(string oddOrEven)
        {
            _subscriptions.TryRemove(oddOrEven, out var removedValue);
        }
        public void StartTimer()
        {
            if (_secondTimer == null)
            {
                this._secondTimer = new System.Timers.Timer(1000);
            }
                this._secondTimer.Start();
            _secondTimer.Elapsed += OnSecondTimer;
            if (DateTime.Now.Second%2 == 0)
            {
                _evenTick = false;
            } else
            {
                _evenTick = true;
            }

        }
        public void StopTimer()
        {
            this._secondTimer?.Stop();
        }
        public async void OnSecondTimer(object Sender, ElapsedEventArgs e)
        {
            SimpleCustomArgs args = new();
            args.CurrentDateTime = DateTime.Now.ToString();
            if (_evenTick)
            {
                if (_subscriptions.TryGetValue("Even", out var callBackFunction))
                {
                    args.OddOrEven = "Even";
                    await callBackFunction(args);
                }
                _evenTick = false;
            } else
            {
                if (_subscriptions.TryGetValue("Odd", out var callBackFunction))
                {
                    args.OddOrEven = "Odd";
                    await callBackFunction(args);
                }
                _evenTick = true;
            }

        }
        public void AddOnTimerEvent(ElapsedEventHandler handler)
        {
            _secondTimer.Elapsed += handler;
        }
        public void RemoveOnTimerEvent(ElapsedEventHandler handler)
        {
            _secondTimer.Elapsed -= handler;
        }
    }




    class SimpleCustomArgs : EventArgs
    {
        public string OddOrEven {  get; set; }
        public string CurrentDateTime { get; set; }
        public SimpleCustomArgs() { }
    }
}
