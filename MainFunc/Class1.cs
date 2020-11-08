using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace MainFunc
{
    public class ProcessingFirstStr
    {
        //Проверка на существование символа/операции, если он не число
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

        static void CheckForBracket(List<string> separateStr)
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
                throw new ArgumentNullException("operation");
        }

        public static List<string>SeparationText(string firstStr)
        {
            if (String.IsNullOrEmpty(firstStr))
                    throw new ArgumentNullException("firstStr");
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
            CheckForBracket(finishStr);
            return finishStr;
        }
    }

    public class Calculate
    {
        static int DefPriopity(char operation)
        {
            if (operation == '+' || operation == '-') return 1;
            else if (operation == '*' || operation == '/') return 2;
            else return 0;
        }

        static double Subtraction(double a, double b)
        {
            return (a - b);
        }
        static double Addition(double a, double b)
        {
            return (a + b);
        }
        static double Division(double a, double b)
        {
            return (a / b);
        }
        static double Multiplication(double a, double b)
        {
            return (a * b);
        }
        static void CalculateLastOperation(ref Stack<double> arguments, char operations)
        {
            double result = 0, b = arguments.Pop(), a=arguments.Pop();
            switch  (operations)
            {
                case '-':
                    result = Subtraction(a, b);
                    break;
                case '+':
                    result = Addition(a, b);
                    break;
                case '*':
                    result = Multiplication(a, b);
                    break;
                case '/':
                    result = Division(a, b);
                    break;
            }
            arguments.Push(Math.Round(result, 2));
        }

        public static double CalculateExample(List<string> separateString)
        {
            double num;
            Stack<double> parametrs = new Stack<double>();
            Stack<char> actions = new Stack<char>();
            foreach(string val in separateString)
            {
                //Добавляем число в стек
                if (double.TryParse(val, out num))
                    parametrs.Push(num);
                //Добавляем откр скобку в стек
                else if (val == "(")
                    actions.Push(val.ToCharArray()[0]);
                //Вычисляем до момента пока не наткнёмся на откр скобку
                else if (val == ")")
                {
                    while (actions.Peek() != '(' && parametrs.Count != 1)
                    {
                        CalculateLastOperation(ref parametrs, actions.Pop());
                    }
                    actions.Pop();
                }
                //Действия при получения операнда
                else
                {
                    //Первый знак
                    if (actions.Count == 0)
                        actions.Push(val.ToCharArray()[0]);
                    //Знак меньший в приоритете
                    else if (DefPriopity(val.ToCharArray()[0]) <= (DefPriopity(actions.Peek())))
                    {
                        while ((actions.Count != 0 && (DefPriopity(val.ToCharArray()[0]) <= DefPriopity(actions.Peek()))))
                            CalculateLastOperation(ref parametrs, actions.Pop());
                        actions.Push(val.ToCharArray()[0]);
                    }
                    //Знак больший в приоритете
                    else
                        actions.Push(val.ToCharArray()[0]);
                }
            }
            //Вычисления, когда стек заполнен
            while (actions.Count != 0)
                CalculateLastOperation(ref parametrs, actions.Pop());
            return parametrs.Pop();
        }
    }
}
