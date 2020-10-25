using System;
using System.IO;
using System.Reflection;


using SorterPlugin;
using SorterView.Exceptions;

namespace SorterView
{
    class DataModel : IView
    {
        private Random _rand;
        
        public DataModel()
        {
            _rand = new Random();
        }

        public void GetRandomValue(double[] source)
        {
            for (int i = 0; i < source.Length - 1; i++) 
            {
                source[i] = _rand.Next(-1500, 1500);
            }
        }

        public Sorter GetPlugin(string pluginName)
        {
            Sorter plugin = null;

            FileInfo somePlugin = new FileInfo(pluginName);

            Assembly asm = Assembly.LoadFile(somePlugin.FullName);

            foreach (Type pluginType in asm.GetTypes())
            {
                Type sorter = asm.GetType(pluginType.FullName);   //ToDo: Вопрос!!! Почему с Type не работает?

                if (sorter != null)
                {
                    if (pluginType.IsClass && !pluginType.IsInterface)
                    {
                        object objPlugin = Activator.CreateInstance(pluginType);

                        plugin = (Sorter)objPlugin;
                    }
                }
            }

            return plugin;
        }
    }
}
