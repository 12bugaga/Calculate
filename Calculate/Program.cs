using System;
using System.Collections.Generic;

namespace Calculate
{
    class Program
    {
        static string GetStr()
        {
            Console.WriteLine("Введите пример!");
            string str = Console.ReadLine();
            return (str);
        }

        static void COuttransformStrinf(List<string> separateStr)
        {
            foreach(string value in separateStr)
            {
                Console.Write(value);
            }
            Console.Write("\n");
        }

        static void Main(string[] args)
        {
            string firstStr = GetStr();
            List<string> separateStr = MainFunc.ProcessingFirstStr.SeparationText(firstStr);
            COuttransformStrinf(separateStr);
            double result = MainFunc.Calculate.CalculateExample(separateStr);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
