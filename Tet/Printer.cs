using System;

namespace RegistryExporter
{
    public static class Printer
    {
        private static void ColorChangingWithReset(ConsoleColor color, string msg)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static class Warnings
        {
            public static void KeysNotFound()
            {
                ColorChangingWithReset(ConsoleColor.Yellow, "Ключи не найдены в реестре");
            }

            public static void SerialNumbersNotFound()
            {
                ColorChangingWithReset(ConsoleColor.Yellow, "Серийный номер КриптоПро не найден");
            }
        }
        public static class Info
        {
            public static void CopyKeys(string keyName)
            {
                Console.WriteLine("Скопировали " + keyName);
            }

            public static void CopyKeysFinish()
            {
                ColorChangingWithReset(ConsoleColor.Green, "\nКлючи скопированы в файл в данной директории.");
            }
            public static void CopyProductIDFinish(string version)
            {
                ColorChangingWithReset(ConsoleColor.Green, "\nСерийный номер версии " + version + " скопирован в файл в данной директории.");
            }
            public static void ProgramFinish()
            {
                ColorChangingWithReset(ConsoleColor.Green, "\nРабота программы завершена. Нажмите Enter для закрытия окна.");
            }

            public static void Credits()
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\nЕсли у вас есть предложения по доработке или добавлению нового функционала, пожалуйста,\nнапишите письмо на");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" BikinMV@taxcom.ru, ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("я обязательно вам отвечу");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Разработано специально для компании Taxcom");
            }

            public static void Greetings()
            {
                ColorChangingWithReset(ConsoleColor.White,
                "\nRegistryExporter копирует ключи из реестра(если он там есть) в .reg файл\n" +
                "и достаёт серийный номер КриптоПро\n\n\n" +
                "Нажмите любую клавишу для старта программы\n");
            }
        }

        public static class Errors
        {
            public static void ErrorEscalating()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Возникло исключение! Пожалуйста, направьте скриншот с ошибкой и описанием действий на");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" BikinMV@taxcom.ru, ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("если хотите, чтобы это было исправлено в следующем обновлении.");
            }
        }
    }
}


