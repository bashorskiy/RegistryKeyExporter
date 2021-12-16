using System;
using System.Text;

namespace RegistryExporter
{
    public class Template
    {
        private Key _key;
        public string FormatResult { get; private set; }
        public Template(Key key)
        {
            _key = key;
        }

        public void FormatKey()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("[" + _key.GetKeyFullPath() + "]");
            FormatResult = builder.AppendLine(FormatHex().ToString()).ToString();
            Console.WriteLine(FormatResult);
        }

        private StringBuilder FormatHex()
        {
            int firstStringBorder;
            StringBuilder builder = new StringBuilder();
            foreach (var item in _key.GetValueNameAndHex())
            {
                int valueLength = item.Value.Length;
                builder.Append("\"" + item.Key + "\"" + "=hex:");
                if (item.Key == "name.key" || item.Key == "masks.key")
                    firstStringBorder = 21;

                else
                    firstStringBorder = 20;

                if (item.Value.Length < firstStringBorder)
                    firstStringBorder = item.Value.Length;

                for (int i = 0; i < firstStringBorder; i++)
                {
                    builder.Append(item.Value[i] + ",");
                }
                if (item.Value.Length != firstStringBorder)
                    builder.Append("\\" + "\n" + "  ");
                else
                    builder.Append("\n");

                int hexCounter = firstStringBorder;
                int regularStringsAmount = valueLength / 25;
                for (int i = 1; i < regularStringsAmount; i++)
                {
                    for (int j = hexCounter; j < hexCounter + 25; j++)
                    {
                        builder.Append(item.Value[j] + ",");
                    }
                    hexCounter += 25;
                    builder.Append("\\" + "\n  ");
                }
                for (int i = hexCounter; i < valueLength; i++)
                {
                    if (i == valueLength - 1)
                    {
                        builder.AppendLine(item.Value[i]);
                        break;
                    }
                    builder.Append(item.Value[i] + ",");
                }
            }
            return builder;
        }
    }
}


