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

        private void GetPluginName()
        {
            _pluginsNames = Directory.GetFiles(DefaultSettings.DEFAULT_DIRECTORY);

            FileInfo namePlugin = null;

            int numberPlugins = 1;

            for (int i = 0; i < _pluginsNames.Length; i++)
            {
                numberPlugins += i;
                namePlugin = new FileInfo(_pluginsNames[i]);

                Console.WriteLine();
                Console.WriteLine($"{numberPlugins} " + namePlugin.Name);
            }
        }

        public void GetPlugins()
        {
            Console.WriteLine("Выберите плагин: ");
            Console.WriteLine();
            GetPluginName();

            char choice = Console.ReadKey().KeyChar;

            try
            {
                int index = int.Parse(choice.ToString()) - 1;

                Sorter plugin = _viewPlugins.GetPlugin(_pluginsNames[index]);
                Analyzer objAnalyzer = new Analyzer(plugin);
                plugin.Sort(_array);

                Console.WriteLine();
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
