using System;
using System.Linq;

namespace Calculator
{
    class Program
    {
        static readonly string[] operatorsList = { "+", "-", "*", "/" };

        static double firstOperang;
        static double secondOperand;
        static string mathOperator;

        static void Main(string[] args)
        {
            while (true)
            {
                getFirstOperand();
                getMathOperator();
                getSecondOperand();
                Console.WriteLine("Result: " + getResult());
                Console.WriteLine();
            }
        }
  
        static void getFirstOperand() {
            while (true)
            {
                Console.WriteLine("Please enter first operand:");
                try
                {
                    firstOperang = double.Parse(Console.ReadLine().Trim());
                }
                catch (FormatException) {
                    Console.WriteLine("Illegal value for first operand.");
                    continue;
                }
                return;
            }
        }

        static void getMathOperator() {
            string op = string.Empty;
            while (true)
            {
                Console.WriteLine("Please enter an operator ('+', '-', '*' or '/'):");
                mathOperator = Console.ReadLine().Trim();
                if (isValidOperator(mathOperator))
                    break;
                Console.WriteLine("Illegal math operator.");
            };
        }

        static void getSecondOperand()
        {
            while (true)
            {
                Console.WriteLine("Please enter second operand:");
                try
                {
                    secondOperand = double.Parse(Console.ReadLine().Trim());
                    if (secondOperand == 0 && mathOperator.Equals("/")) {
                        Console.WriteLine("You can't divide on zero!");
                        continue;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Illegal value for second operand.");
                    continue;
                }
                return;
            }
        }

        static string getResult()
        {
            switch (mathOperator)
            {
                case "+":
                    return firstOperang + " + " + secondOperand + " = " + (firstOperang + secondOperand).ToString();
                case "-":
                    return firstOperang + " - " + secondOperand + " = " + (firstOperang - secondOperand).ToString();
                case "*":
                    return firstOperang + " * " + secondOperand + " = " + (firstOperang * secondOperand).ToString();
                case "/":
                    return firstOperang + " / " + secondOperand + " = " + (firstOperang / secondOperand).ToString();
                default:
                    return "Something goes wrong. Please try again.";
            }
        }

        static bool isValidOperator(string symbol)
        {
            return operatorsList.Contains(symbol.Trim());
        }
    }
}
