using System;
using System.Collections.Generic;

namespace WorkWithConsole
{
    public interface IWorkWithConsole
    {
        void FirstMessage();
        string ReadAnswerUser();
        void HelloMessageForWriteExample();
        string ReadExample();
        void PrintAnswer(List<String> example, double answer);
        void NotFoundMode();
        void HaveBracket();
        void HelloMessageForWritePathToFile();
        void PathToFileWitshAnswer(string pathOutFile);
    }

    public class WorkWithConsole : IWorkWithConsole
    {
        public void FirstMessage()
        {
            Console.WriteLine("Необходимо выбрать режим калькулятора. 1 -- ввод примера вручную. 2 -- ввод месторасположения файла, содержащего примеры.");
        }

        public string ReadAnswerUser()
        {
            return(Console.ReadLine());
        }

        public void NotFoundMode()
        {
            Console.WriteLine("Неверно введён режим работы калькулятора!\nПовторите выбор режима калькулятора!");
        }

        public void HelloMessageForWriteExample()
        {
            Console.WriteLine("Введите пример. Разделителем целого числа является точка -- '.' ");
        }

        public void HaveBracket()
        {
            Console.WriteLine("Пример введён неверно, в нём есть скобки!");
        }

        public string ReadExample()
        {
            return (Console.ReadLine());
        }

        public void HelloMessageForWritePathToFile()
        {
            Console.WriteLine("Введите путь к файлу с примерами.");
        }

        public void PathToFileWitshAnswer(string pathOutFile)
        {
            Console.WriteLine("Путь к файлу с ответами:\n" + pathOutFile);
        }

        public void PrintAnswer(List<String> example, double answer)
        {
            foreach (string symbol in example)
                Console.Write(symbol);
            Console.Write(" = " + answer+"\n");
        }
    }
}
