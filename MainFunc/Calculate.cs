using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Globalization;

namespace MainFunc
{

    public interface ICalculate
    {
        double CalculateExample(List<string> separateString);
    }

    public class Calculate : ICalculate
    {
        
        private const int SYMBOL = 0;
        private int DefPriopity(char operation)
        {
            int deffinite = 0;
            switch (operation)
            {
                case '+':
                    deffinite = 1;
                    break;
                case '-':
                    deffinite = 1;
                    break;
                case '*':
                    deffinite = 2;
                    break;
                case '/':
                    deffinite = 2;
                    break;
            }
            return deffinite;
        }

        private double Subtraction(double a, double b)
        {
            return (a - b);
        }
        private double Addition(double a, double b)
        {
            return (a + b);
        }
        private double Division(double a, double b)
        {
            return (a / b);
        }
        private double Multiplication(double a, double b)
        {
            return (a * b);
        }
        private void CalculateLastOperation(ref Stack<double> arguments, char operations)
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

        public double CalculateExample(List<string> separateString)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
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
