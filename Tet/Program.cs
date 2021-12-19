using System.Collections.Generic;


namespace RegistryExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RegistryExplorer explorer = new RegistryExplorer();
                RegistryExporter exporter = new RegistryExporter(explorer.RegistryPathToKeys, explorer.LocalKey);
                Key[] keys = exporter.GetKeys();
                List<KeyFormatter> formattedHexes = new List<KeyFormatter>();
                foreach (Key key in keys)
                {
                    KeyFormatter formattedHex = new KeyFormatter(key);
                    formattedHex.FormatKey();
                    formattedHexes.Add(formattedHex);
                }
                FileCreator creator = new FileCreator(explorer.RegistryPathToKeys, formattedHexes);
                creator.CreateKeysRegFile();
                CryptoProProductID productID = new CryptoProProductID();
                creator.CreateProductIDTextFile(productID);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            System.Console.ReadLine();
        }
    }
}


