using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorterPlugin
{
    public class SwapCompareEventArgs : EventArgs
    {
        public double CompareCount { get; private set; }

        public double SwapCount { get; private set; }

        public SwapCompareEventArgs(double compareCount, double swapCount)
        {
            CompareCount = compareCount;
            SwapCount = swapCount;
        }
    }
}
