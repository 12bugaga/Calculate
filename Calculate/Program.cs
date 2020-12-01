using System;
using System.Text;
using System.Collections.Generic;



namespace Calculate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            StartProgram.Start start = new StartProgram.Start(new WorkWithConsole.WorkWithConsole(), new MainFunc.ProcessingFirstStr(), new MainFunc.Calculate(), new WorkWithFile.ProcessWithFile());
            start.StartCalc();
            Console.WriteLine("Для выхода нажмите любую клавишу!");
            Console.ReadKey();
        }
    }
}
