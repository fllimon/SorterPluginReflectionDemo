using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorterPlugin
{
    public class StartStopSortedEventArgs : EventArgs
    {
        public DateTime Time { get; private set; }

        public StartStopSortedEventArgs(DateTime time)
        {
            Time = time;
        }
    }
}
