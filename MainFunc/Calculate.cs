using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace MainFunc
{
    public class Calculate
    {
        public const int SYMBOL = 0;
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
                    if (b == 0)
                        throw new DivideByZeroException();
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
                    actions.Push(val.ToCharArray()[SYMBOL]);
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
                        actions.Push(val.ToCharArray()[SYMBOL]);
                    //Знак меньший в приоритете
                    else if (DefPriopity(val.ToCharArray()[SYMBOL]) <= (DefPriopity(actions.Peek())))
                    {
                        while ((actions.Count != 0 && (DefPriopity(val.ToCharArray()[SYMBOL]) <= DefPriopity(actions.Peek()))))
                            CalculateLastOperation(ref parametrs, actions.Pop());
                        actions.Push(val.ToCharArray()[SYMBOL]);
                    }
                    //Знак больший в приоритете
                    else
                        actions.Push(val.ToCharArray()[SYMBOL]);
                }
            }
            //Вычисления, когда стек заполнен
            while (actions.Count != 0)
                CalculateLastOperation(ref parametrs, actions.Pop());
            return parametrs.Pop();
        }
    }
}
