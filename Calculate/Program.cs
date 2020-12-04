using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;


namespace Calculate
{
    class Program
    {
        
        static void Main(string[] args)
        {

            var serviceProvider = new ServiceCollection()
                .AddSingleton<WorkWithConsole.IWorkWithConsole, WorkWithConsole.WorkWithConsole>()
                .AddSingleton<MainFunc.IProcessingFirstStr, MainFunc.ProcessingFirstStr>()
                .AddSingleton<MainFunc.ICalculate, MainFunc.Calculate>()
                .AddSingleton<WorkWithFile.IProcessWithFile, WorkWithFile.ProcessWithFile>()
                .AddSingleton<StartProgram.IStart, StartProgram.Start>()
            .BuildServiceProvider();

            Console.OutputEncoding = Encoding.UTF8;
            var start = serviceProvider.GetService<StartProgram.IStart>();
            start.StartCalc();
            Console.WriteLine("Для выхода нажмите любую клавишу!");
            Console.ReadKey();
        }
    }
}
