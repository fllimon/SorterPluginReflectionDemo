using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SorterPlugin;

namespace SorterView
{
    class UI
    {
        private IView _viewPlugins;
        private string[] _pluginsNames;
        private double[] _array;

        public UI(IView view)
        {
            _viewPlugins = view;
            _array = new double[DefaultSettings.DEFAULT_ARRAY_SIZE];

            _viewPlugins.GetRandomValue(_array);
        }

        public string GetPluginName
        {
            get
            {
                _pluginsNames = Directory.GetFiles(DefaultSettings.DEFAULT_DIRECTORY);

                return _viewPlugins.GetPluginDirectory(_pluginsNames);
            }
        }

        public void GetPlugins()
        {
            Console.WriteLine("Выберите плагин: ");
            Console.WriteLine();
            Console.WriteLine(GetPluginName);

            char choice = Console.ReadKey().KeyChar;

            try
            {
                int index = int.Parse(choice.ToString()) - 1;

                Sorter plugin = _viewPlugins.GetPlugin(_pluginsNames[index]);

                Analyzer objAnalyzer = new Analyzer(plugin);

                plugin.Sort(_array);

                Console.WriteLine($"SwapCount: {objAnalyzer.SwapCount} - Compare: {objAnalyzer.CompareCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex);
            }
        }
    }
}
