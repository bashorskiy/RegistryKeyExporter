using System.Collections.Generic;


namespace RegistryExporter
{
    class Program
    {
        static void Main()
        {
            try
            {
                Printer.Info.Greetings();
                System.Console.ReadKey();
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
                System.Console.WriteLine(e.StackTrace);
                Printer.Errors.ErrorEscalating();
            }
            Printer.Info.Credits();
            Printer.Info.ProgramFinish();
            System.Console.ReadLine();
        }
    }
}


