using System;
using System.Text;

namespace Calculate
{
    class Program
    {
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

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Program progr = new Program(new WorkWithConsole.WorkWithConsole(), new MainFunc.ProcessingFirstStr(), new MainFunc.Calculate(), new WorkWithFile.ProcessWithFile());
            StartProgram.Start start = new StartProgram.Start(progr._WConsole, progr._ProcessWithString, progr._Calculator, progr._ProcWithFile);
            start.StartCalc();
            Console.WriteLine("Для выхода нажмите любую клавишу!");
            Console.ReadKey();
        }
    }
}
