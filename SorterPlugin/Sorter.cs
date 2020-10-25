using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorterPlugin
{
    public abstract class Sorter
    {
        #region ========-------- PRIVATE DATA -------=========

        protected SwapCompare _swapCount;
        protected SwapCompare _compareCount;
        protected StartStopSorted _startTime;
        protected StartStopSorted _stopTime;

        #endregion

        #region =======------- EVENT'S -------=======

        public event StartStopSorted StartTime
        {
            add
            {
                _startTime += value;
            }
            remove
            {
                _startTime -= value;
            }
        }

        public event StartStopSorted StopTime
        {
            add
            {
                _stopTime += value;
            }
            remove
            {
                _stopTime -= value;
            }
        }

        public event SwapCompare SwapCount
        {
            add
            {
                _swapCount += value;
            }
            remove
            {
                _swapCount -= value;
            }
        }

        public event SwapCompare CompareCount
        {
            add
            {
                _compareCount += value;
            }
            remove
            {
                _compareCount -= value;
            }
        }

        #endregion

        public abstract double[] Sort(double[] source);

        protected void Swap(ref double firstValue, ref double secondValue)
        {
            if (_swapCount != null) 
            {
                _swapCount(this, new SwapCompareEventArgs(firstValue, secondValue));
            }

            double tmp = firstValue;
            firstValue = secondValue;
            secondValue = tmp;
        }

        protected bool IsCompare(double firstValue, double secondValue)
        {
            if (_compareCount != null)
            {
                _compareCount(this, new SwapCompareEventArgs(firstValue, secondValue));
            }

            return firstValue > secondValue;
        }
    }
}
