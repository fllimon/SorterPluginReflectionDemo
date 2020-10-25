using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorterView
{
    class NotFoundPluginExceptions : Exception
    {
        public NotFoundPluginExceptions()
        {

        }

        public NotFoundPluginExceptions(string message)
            : base(message)
        {

        }

        public NotFoundPluginExceptions(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
