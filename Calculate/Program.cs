using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;


namespace Calculate
{
    class Program
    {
        /*
        private readonly WorkWithConsole.IWorkWithConsole _WConsole;
        private readonly MainFunc.IProcessingFirstStr _ProcessWithString;
        private readonly MainFunc.ICalculate _Calculator;
        private readonly WorkWithFile.IProcessWithFile _ProcWithFile;

        public Program(WorkWithConsole.IWorkWithConsole WConsole, MainFunc.IProcessingFirstStr ProcessWithString, MainFunc.ICalculate Calculator, WorkWithFile.IProcessWithFile ProcWithFile)
        {
            _WConsole = WConsole;
            _ProcessWithString = ProcessWithString;
            _Calculator = Calculator;
            _ProcWithFile = ProcWithFile;
        }
        */

        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<StartProgram.IStart>(new StartProgram.Start(new WorkWithConsole.WorkWithConsole(), new MainFunc.ProcessingFirstStr(), new MainFunc.Calculate(), new WorkWithFile.ProcessWithFile()))
            .BuildServiceProvider();

            Console.OutputEncoding = Encoding.UTF8;
            var start = serviceProvider.GetService<StartProgram.IStart>();
            start.StartCalc();
            Console.WriteLine("Для выхода нажмите любую клавишу!");
            Console.ReadKey();
        }
    }
}
