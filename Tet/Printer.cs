using System;

namespace RegistryExporter
{
    public static class Printer
    {
        public static class Info
        {
            public static void CopyKeys(string keyName)
            {
                Console.WriteLine("Скопировали " + keyName);
            }

            public static void CopyFinish()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nКлючи и серийный номер КриптоПро скопированы в файлы в данной директории.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            public static void ProgramFinish()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nРабота программы завершена. Нажмите Enter для закрытия окна.");
                Console.ForegroundColor = ConsoleColor.Gray;
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
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t RegistryExporter копирует ключи из реестра в .reg файл и достаёт серийный номер КриптоПро\n\n\n" +
                    "Нажмите любую клавишу для старта программы\n");
                Console.ForegroundColor = ConsoleColor.Gray;
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


