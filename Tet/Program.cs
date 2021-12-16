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
                Key[] keys = explorer.GetKeys();
                List<Template> templates = new List<Template>();
                foreach (Key key in keys)
                {
                    Template template = new Template(key);
                    template.FormatKey();
                    templates.Add(template);
                }
                FileCreator creator = new FileCreator(templates);
                System.Console.ReadLine();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            System.Console.ReadLine();
        }
    }
}


