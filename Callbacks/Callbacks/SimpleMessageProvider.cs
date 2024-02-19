using ConcurrentCollections;
using log4net;
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
        Logger Logger = Logger.Instance;

        #region Singleton Instantiation https://csharpindepth.com/articles/singleton version 4

        private static readonly SimpleMessageProvider instance = new SimpleMessageProvider();

        

        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static SimpleMessageProvider() { }

        public static SimpleMessageProvider Instance
        {
            get { return instance; }
        }
        #endregion

        public SimpleMessageProvider() { }
        private System.Threading.Timer? _secondTimer = null;
        private ConcurrentDictionary<string, ConcurrentHashSet<Func<SimpleEventArgs, Task>>> _subscriptions = new();
        public event EventHandler<SimpleEventArgs> SimpleMessageEvent;
        public void AddSubscription(Func<SimpleEventArgs, Task> callBackFunction, string oddOrEven)
        {
            try
            {
                if (_subscriptions.ContainsKey(oddOrEven))
                {
                    _subscriptions[oddOrEven].Add(callBackFunction);
                }
                else
                {
                    var newSet = new ConcurrentHashSet<Func<SimpleEventArgs, Task>>
                    {
                        callBackFunction
                    };
                    _subscriptions.TryAdd(oddOrEven, newSet);
                }
            } 
            catch (Exception ex)
            {
                Logger.Instance?.LogError(ex);
            }
        }
        public void RemoveSubscription(Func<SimpleEventArgs, Task> callBackFunction, string oddOrEven)
        {
            try
            {
                _subscriptions[oddOrEven].TryRemove(callBackFunction);
            } 
            catch (Exception ex)
            {
                Logger?.LogError(ex);
            }
        }
        public void AddSimpleSubscription(EventHandler<SimpleEventArgs> handler)
        {
            SimpleMessageEvent += handler;
        }      
        public void RemoveSimpleSubscription(EventHandler<SimpleEventArgs> handler)
        {
            SimpleMessageEvent -= handler;
        }
        public void StartTimer()
        {
            if (_secondTimer == null)
            {
                this._secondTimer = new System.Threading.Timer(OnSecondTimer, null, 0, 1000);
            }
        }
        public async Task NotifySubscribers(ConcurrentHashSet<Func<SimpleEventArgs, Task>> subscribers, SimpleEventArgs args)
        {
            try
            {
                foreach (var subscriber in subscribers)
                {
                    await subscriber.Invoke(args);
                }
            } catch (Exception ex)
            {
                Logger.Instance?.LogError(ex);
            }
        }
        public async void OnSecondTimer(object Sender)
        {
            try
            {
                SimpleEventArgs args = new()
                {
                    CurrentDateTime = DateTime.Now.ToString()
                };

                Boolean Even = DateTime.Now.Second % 2 == 0;
                
                if (Even)
                {
                    if (_subscriptions.TryGetValue("Even", out var callBackFunctions))
                    {
                        args.OddOrEven = "Even";
                        await NotifySubscribers(callBackFunctions, args);
                    }
                }
                else
                {
                    if (_subscriptions.TryGetValue("Odd", out var callBackFunctions))
                    {
                        args.OddOrEven = "Odd";
                        await NotifySubscribers(callBackFunctions, args);
                    }
                }
                SimpleMessageEvent?.Invoke(this, new SimpleEventArgs(args.CurrentDateTime));
            } catch (Exception ex)
            {
                Logger.Instance?.LogError(ex);
            }

        }
    }
    class SimpleEventArgs : EventArgs
    {
        public string OddOrEven {  get; set; }
        public string CurrentDateTime { get; set; }
        public SimpleEventArgs() { }
        public SimpleEventArgs(string currentDateTime) 
        { 
            this.CurrentDateTime = currentDateTime;
        }
    }
}
