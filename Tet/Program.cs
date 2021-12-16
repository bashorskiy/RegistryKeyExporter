using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RegistryExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RegistryExplorer re = new RegistryExplorer();
                re.GetKeys();
                System.Console.ReadLine();
            }
            catch (System.Exception)
            {
                 
                throw;
            }
            System.Console.ReadLine();
        }
    }
}


