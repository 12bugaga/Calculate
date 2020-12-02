using System;
using System.IO;
using System.Collections.Generic;
namespace WorkWithFile
{
    public interface IProcessWithFile
    {
        string[] ReadFromFile(string pathToFile);
        string SaveToFile(List<string> allAnswer, string pathToFile);
    }

    public class ProcessWithFile : IProcessWithFile
    {
        public string[] ReadFromFile(string pathToFile)
        {
            return File.ReadAllLines(pathToFile);
        }

        public string SaveToFile(List<string> allAnswer, string pathToFile)
        {
            /* //Для проверки
            foreach (string line in allAnswer)
                Console.WriteLine(line);
            */

            string[] param;
            string pathOutFile="";
            param = pathToFile.Split(new string[] { @"\" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < param.Length-1; i++)
               pathOutFile += param[i] + @"\";
            pathOutFile += "ResultFile.txt";
            File.WriteAllLines(pathOutFile, allAnswer);
            return pathOutFile;
        }
    }
}
