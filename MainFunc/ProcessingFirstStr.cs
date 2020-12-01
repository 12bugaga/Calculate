using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace MainFunc
{
    public interface IProcessingFirstStr
    {
        //bool AvailableOperation(char operation);
        //void CheckForBracket(List<string> separateStr);
        List<string> SeparationText(string firstStr);

    }

    public class ProcessingFirstStr : IProcessingFirstStr
    {
        //Проверка на существование символа/операции, если он не число
        public bool AvailableOperation(char operation)
        {
            char[] availableOperation = {'(', ')','+', '-', '*', '/', '.'};
            bool exist = false;
            foreach (char symbol in availableOperation)
            {
                if (symbol == operation)
                    exist = true;
            }
            if (exist == false)
                throw new Exception("Нет такой операции!");
            return exist;
        }

        public void CheckForBracket(List<string> separateStr)
        {
            int openCount = 0, closeCount = 0;
            foreach (string symbol in separateStr)
            {
                if (symbol == ")")
                    openCount++;
                else if (symbol == "(")
                    closeCount++;
            }
            if (openCount != closeCount)
                throw new Exception("Неверно расставлены скобки!");
        }

        public List<string> SeparationText(string firstStr)
        {
            int previous = 0, next = 0;
            if (String.IsNullOrEmpty(firstStr))
                    throw new ArgumentNullException("firstStr");
            string value="";
            List<string> finishStr = new List<string>();
            for (int num = 0; num < firstStr.Length; num++)
            {
                previous = num - 1;
                next = num + 1;
                //Число и разделитель
                if (char.IsDigit(firstStr[num]) || firstStr[num] == '.')
                {
                    //Разделитель после цифры
                    if (firstStr[num] == '.' && value != "")
                        value += firstStr[num];
                    //Цифра
                    else if (char.IsDigit(firstStr[num]))
                        value += firstStr[num];
                    //Разделитель вначале
                    else if (firstStr[num] == '.' && value == "")
                        throw new FormatException();
                }
                else
                {
                    if (AvailableOperation(firstStr[num]))
                    {
                        //Скобка в начале примера 
                        if (firstStr[num] == '(' && num == 0)
                        {
                            finishStr.Add(firstStr[num].ToString());
                        }
                        //Скобка после знака
                        else if (firstStr[num] == '(' && !char.IsDigit(firstStr[previous]))
                        {
                            finishStr.Add(firstStr[num].ToString());
                        }
                        //Открывающаяся скобка после числа => умножение
                        else if (firstStr[num] == '(' & value != "")
                        {
                            finishStr.Add(value);
                            value = "";
                            finishStr.Add("*");
                            finishStr.Add(firstStr[num].ToString());
                        }
                        //Закрывающаяся скобка перед числом => умножение
                        else if (firstStr[num] == ')' && next != firstStr.Length && char.IsDigit(firstStr[next]))
                        {
                            finishStr.Add(value);
                            value = "";
                            finishStr.Add(firstStr[num].ToString());
                            finishStr.Add("*");
                        }
                        //Закрывающаяся скобка после числа
                        else if (firstStr[num] == ')' & value != "")
                        {
                            finishStr.Add(value);
                            value = "";
                            finishStr.Add(firstStr[num].ToString());
                        }
                        //Если отрицательный знак стоит в начале примера или после откр скобки
                        else if ((num == 0 && value == "") || (firstStr[previous] == '('))
                        {
                            finishStr.Add("0");
                            finishStr.Add(firstStr[num].ToString());
                        }
                        //Знак стоит после закр скобки
                        else if (firstStr[previous] == ')')
                            finishStr.Add(firstStr[num].ToString());
                        //Если знак стоит после числа
                        else if (value != "")
                        {
                            finishStr.Add(value);
                            finishStr.Add(firstStr[num].ToString());
                            value = "";
                        }
                        //Два знака стоят рядом без скобок
                        else if (AvailableOperation(firstStr[num]) && ((finishStr != null) || (value != "")) && !char.IsDigit(firstStr[previous]))
                            throw new Exception("Неверно расставлены знаки операций!");
                    }
                }
                //Последнее число в примере
                if ((num == firstStr.Length - 1) && value !="")
                    finishStr.Add(value);
            }
            CheckForBracket(finishStr);
            return finishStr;
        }
    }
}
