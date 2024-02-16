using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callbacks
{
    internal class SimpleMessageProvider
    {
        public SimpleMessageProvider() { }
        public System.Timers.Timer MessageTimer;

        private ConcurrentDictionary<string, Func<SimpleCustomArgs, Task>> _subscriptions;
    }



    class SimpleCustomArgs : EventArgs
    {
        public string OddOrEven {  get; set; }
        public SimpleCustomArgs() { }
    }
}
