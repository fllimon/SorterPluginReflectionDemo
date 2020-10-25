using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SorterPlugin;

namespace SorterView
{
    interface IView
    {
        void GetRandomValue(double[] source);

        Sorter GetPlugin(string pluginName);
    }
}
