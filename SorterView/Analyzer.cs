using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SorterPlugin;

namespace SorterView
{
    class Analyzer
    {
        private int _compareCount = 0;
        private int _swapCount = 0;
        private readonly Sorter _sort;

        public Analyzer(Sorter sort)
        {
            _sort = sort;

            _sort.StartTime += GetStartTimeAnalyzer;
            _sort.StopTime += GetStopTimeAnalyzer;
            _sort.SwapCount += GetSwapAnalyzer;
            _sort.CompareCount += GetCompareAnalyzer;
        }

        public int SwapCount
        {
            get
            {
                return _swapCount;
            }
        }

        public int CompareCount
        {
            get
            {
                return _compareCount;
            }
        }

        private void GetStartTimeAnalyzer(object sender, StartStopSortedEventArgs args)
        {
            Console.WriteLine();
            Console.WriteLine($"Start time: {DateTime.Now.ToLongTimeString()}");
        }

        private void GetStopTimeAnalyzer(object sender, StartStopSortedEventArgs args)
        {
            Console.WriteLine();
            Console.WriteLine($"Stop time: {DateTime.Now.ToLongTimeString()}");
            Console.WriteLine();
        }

        private void GetSwapAnalyzer(object sender, SwapCompareEventArgs args)
        {
            _swapCount++;
        }

        private void GetCompareAnalyzer(object sender, SwapCompareEventArgs args)
        {
            _compareCount++;
        }
    }
}
