using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SorterPlugin;

namespace ShakerSorterPlugin
{
    class ShakerSorter : Sorter
    {
        public override double[] Sort(double[] source)
        {
            if (_startTime != null)
            {
                _startTime(this, new StartStopSortedEventArgs(DateTime.Now));
            }

            for (int i = 0; i < source.Length / 2; i++)
            {
                bool swapFlag = false;

                for (int j = i; j < source.Length - i - 1; j++)
                {
                    if (IsCompare(source[j], source[j + 1]))
                    {
                        Swap(ref source[j], ref source[j + 1]);

                        swapFlag = true;
                    }
                }

                for (int j = source.Length - 2 - i; j > i; j--)
                {
                    if (IsCompare(source[j - 1], source[j]))
                    {
                        Swap(ref source[j - 1], ref source[j]);

                        swapFlag = true;
                    }
                }

                if (!swapFlag)
                {
                    break;
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
