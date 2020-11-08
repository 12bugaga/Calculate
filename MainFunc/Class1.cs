using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace MainFunc
{
    public class Calculator
    {
        //Проверка на существование символа, если он не число
        public static bool AvailableOperation(char operation)
        {
            char[] availableOperation = {'(', ')','+', '-', '*', '/'};
            bool exist = false;
            foreach (char symbol in availableOperation)
            {
                if (symbol == operation)
                    exist = true;
            }
            if (exist == false)
                throw new ArgumentNullException("operation");
            return exist;
        }

        public static List<string>SeparationText(string firstStr)
        //public static string SeparationText(string firstStr)

        {
            string value="";
            List<string> finishStr = new List<string>();
            for (int num = 0; num < firstStr.Length; num++)
            {
                if (char.IsDigit(firstStr[num]))
                    value += firstStr[num];
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
                        else if (firstStr[num] == '(' && !char.IsDigit(firstStr[num - 1]))
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
                        else if (firstStr[num] == ')' && num + 1 != firstStr.Length && char.IsDigit(firstStr[num + 1]))
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
                        else if ((num == 0 && value == "") || (firstStr[num - 1] == '('))
                        {
                            finishStr.Add("0");
                            finishStr.Add(firstStr[num].ToString());
                        }
                        //Знак стоит после закр скобки
                        else if (firstStr[num - 1] == ')')
                            finishStr.Add(firstStr[num].ToString());
                        //Если знак стоит после числа
                        else if (value != "")
                        {
                            finishStr.Add(value);
                            finishStr.Add(firstStr[num].ToString());
                            value = "";
                        }


                        //Два знака стоят рядом без скобок
                        else if (AvailableOperation(firstStr[num]) && ((finishStr != null) || (value != "")) && !char.IsDigit(firstStr[num - 1]))
                            throw new ArgumentNullException("operation");
                    }
                }
                //Последнее число в примере
                if ((num == firstStr.Length - 1) && value !="")
                    finishStr.Add(value);
            }
            string str = finishStr.ToString();
            return finishStr;
        }
    }
}
