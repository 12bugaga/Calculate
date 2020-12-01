using System;
using System.Collections.Generic;

namespace Mode_1
{
    public class ExampleFromUser
    {
        private readonly WorkWithConsole.IWorkWithConsole _WConsole;
        private readonly MainFunc.IProcessingFirstStr _ProcessWithString;
        private readonly MainFunc.ICalculate _Calculator;

        public ExampleFromUser(WorkWithConsole.IWorkWithConsole WConsole, MainFunc.IProcessingFirstStr ProcessWithString, MainFunc.ICalculate Calculator)
        {
            _WConsole = WConsole;
            _ProcessWithString = ProcessWithString;
            _Calculator = Calculator;
        }

        public void StartMode_1()
        {
            string example = _WConsole.ReadExample();
            List<string> separateExample = _ProcessWithString.SeparationText(example);

            if (CheckOnBracket(separateExample))
                _WConsole.HaveBracket();
            else
            {
                double result = _Calculator.CalculateExample(separateExample);
                _WConsole.PrintAnswer(separateExample, result);
            }
        }

        private bool CheckOnBracket(List<string> separateExample)
        {
            bool flag = false;
            foreach (string symbol in separateExample)
            {
                if (symbol == "(" || symbol == ")")
                    flag = true;
                else
                    flag = false;
            }
            return flag;
        }
    }
}
