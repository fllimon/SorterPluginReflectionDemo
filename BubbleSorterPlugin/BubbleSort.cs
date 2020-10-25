using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SorterPlugin;

namespace BubbleSorterPlugin
{
    class BubbleSort : Sorter
    {
        public override double[] Sort(double[] source)
        {
            if (_startTime != null)
            {
                _startTime(this, new StartStopSortedEventArgs(DateTime.Now));
            }

            for (int i = 0; i < source.Length; i++)
            {
                for (int j = i+1; j < source.Length; j++)
                {
                    if (IsCompare(source[i], source[j]))
                    {
                        Swap(ref source[i], ref source[j]);
                    }
                }
            }

            if (_stopTime != null)
            {
                _stopTime(this, new StartStopSortedEventArgs(DateTime.Now));
            }

            return source;
        }
    }
}
