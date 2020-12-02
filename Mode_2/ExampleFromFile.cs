using System;
using System.IO;
using System.Collections.Generic;

namespace Mode_2
{
    public class ExampleFromFile
    {
        private readonly WorkWithConsole.IWorkWithConsole _WConsole;
        private readonly MainFunc.IProcessingFirstStr _ProcessWithString;
        private readonly MainFunc.ICalculate _Calculator;
        private readonly WorkWithFile.IProcessWithFile _ProcWithFile;

        public ExampleFromFile(WorkWithConsole.IWorkWithConsole WConsole, MainFunc.IProcessingFirstStr ProcessWithString, MainFunc.ICalculate Calculator, WorkWithFile.IProcessWithFile ProcWithFile)
        {
            _WConsole = WConsole;
            _ProcessWithString = ProcessWithString;
            _Calculator = Calculator;
            _ProcWithFile = ProcWithFile;
        }

        public void StartMode_2()
        {
            string pathToFile = _WConsole.ReadExample();
            if (!System.IO.File.Exists(pathToFile))
                throw new FileNotFoundException();
            if (new FileInfo(pathToFile).Length == 0)
                throw new Exception("File is empty!");

            string[] textFromFile = _ProcWithFile.ReadFromFile(pathToFile);
            List<string> allExampleForPrint = FillparamForFile(textFromFile);
            string pathToSaveFile = _ProcWithFile.SaveToFile(allExampleForPrint, pathToFile);
            _WConsole.PathToFileWitshAnswer(pathToSaveFile);
        }

        private List<string> FillparamForFile(string[] textFromFile)
        {
            string result = "";
            List<string> allExample = new List<string>(), separateExample;
            foreach (string line in textFromFile)
            {
                try
                {
                    separateExample = _ProcessWithString.SeparationText(line);
                    result = Convert.ToString(_Calculator.CalculateExample(separateExample));
                }
                catch
                {
                    result = "ошибка в выражении";
                }
                finally
                {
                    allExample.Add(line + " = " + result);
                }
            }
            return (allExample);
        }
    }
}
