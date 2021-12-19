using System;
using System.Text;

namespace RegistryExporter
{
    public class KeyFormatter
    {
        private Key _key;
        public string FormatResult { get; private set; }
        public KeyFormatter(Key key)
        {
            _key = key;
        }

        public void FormatKey()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("[" + _key.GetKeyFullPath() + "]");
            FormatResult = builder.AppendLine(FormatHex().ToString()).ToString();           
        }

        private StringBuilder FormatHex()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in _key.GetValueNameAndHex())
            {
                int firstStringBorder = 20;
                builder.Append("\"" + item.Key + "\"" + "=hex:");
                if (item.Key == "name.key" || item.Key == "masks.key")
                {
                    firstStringBorder = 21;
                }
                if (item.Value.Length < firstStringBorder)
                {
                    firstStringBorder = item.Value.Length;
                }
                builder.Append(BuildFirstString(firstStringBorder,item));
                int hexCounter = firstStringBorder;
                int regularStringsAmount = (item.Value.Length - hexCounter) / 25;
                for (int i = 0; i < regularStringsAmount; i++)
                {
                    for (int j = hexCounter; j < hexCounter + 25; j++)
                    {
                        builder.Append(item.Value[j] + ",");
                    }
                    hexCounter += 25;
                    builder.Append("\\" + "\n  ");
                }
                builder.Append(BuildLastString(hexCounter, item));               
            }
            return builder;
        }

        private StringBuilder BuildFirstString(int firstStringBorder, System.Collections.Generic.KeyValuePair<string, string[]> item)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < firstStringBorder; i++)
            {
                builder.Append(item.Value[i] + ",");
            }
            if (item.Value.Length == firstStringBorder)
            {
                builder.Remove(builder.Length - 1, 1);
                builder.Append("\n");
            }
            else
            {
                builder.Append("\\" + "\n" + "  ");
            }
            return builder;
        }

        private StringBuilder BuildLastString(int hexCounter, System.Collections.Generic.KeyValuePair<string, string[]> item)
        {
            StringBuilder builder = new StringBuilder();  
            for (int i = hexCounter; i < item.Value.Length; i++)
            {
                if (i == item.Value.Length - 1)
                {
                    builder.AppendLine(item.Value[i]);
                    break;
                }
                builder.Append(item.Value[i] + ",");
            }
            return builder;
        }
    }
}


