using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RegistryExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistryExplorer re = new RegistryExplorer();
            re.PrintRegistry();
        }
    }
}


