using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorterView
{
    class Program
    {
        static void Main(string[] args)
        {
            IView dm = new DataModel();
            UI menu = new UI(dm);

            menu.GetPlugins();

            Console.ReadKey();
        }
    }
}
