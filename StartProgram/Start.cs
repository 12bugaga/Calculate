using System;

namespace StartProgram
{
    public class Start
    {
        private readonly WorkWithConsole.IWorkWithConsole _WConsole;
        private readonly MainFunc.IProcessingFirstStr _ProcessWithString;
        private readonly MainFunc.ICalculate _Calculator;
        private readonly WorkWithFile.IProcessWithFile _ProcWithFile;

        public Start(WorkWithConsole.IWorkWithConsole WConsole, MainFunc.IProcessingFirstStr ProcessWithString, MainFunc.ICalculate Calculator, WorkWithFile.IProcessWithFile ProcWithFile)
        {
            _WConsole = WConsole;
            _ProcessWithString = ProcessWithString;
            _Calculator = Calculator;
            _ProcWithFile = ProcWithFile;
        }

        /*
        public enum Answ
        {
            1,
            2
        }
        */

        public void StartCalc()
        {
            _WConsole.FirstMessage();
            string mode;
            bool actualMode = false;
            while (!actualMode)
            {
                mode = _WConsole.ReadAnswerUser();
                if (mode == "1")
                {
                    _WConsole.HelloMessageForWriteExample();
                    Mode_1.ExampleFromUser startCalc = new Mode_1.ExampleFromUser(_WConsole, _ProcessWithString, _Calculator);
                    startCalc.StartMode_1();
                    actualMode = true;
                }
                else if (mode == "2")
                {
                    _WConsole.HelloMessageForWritePathToFile();
                    Mode_2.ExampleFromFile startCalc = new Mode_2.ExampleFromFile(_WConsole, _ProcessWithString, _Calculator, _ProcWithFile);
                    startCalc.StartMode_2();
                    actualMode = true;
                }
                else
                    _WConsole.NotFoundMode();
            }
        }
    }
}
