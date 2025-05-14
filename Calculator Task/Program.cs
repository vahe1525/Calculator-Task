using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Calculator_Task
{
    public class Calculator
    {
        private int num1 = 0;
        private int num2 = 0;
        private char operation = ' ';

        private void AnalyzeLine(string input)
        {
            // Pattern: number, optional space, operator, optional space, number
            Match match = Regex.Match(input, @"(-?\d+)\s*([\+\-\*/])\s*(-?\d+)");

            if (match.Success)
            {
                this.num1 = int.Parse(match.Groups[1].Value);
                this.operation = char.Parse(match.Groups[2].Value);
                this.num2 = int.Parse(match.Groups[3].Value);

            }
            else
            {
                Console.WriteLine("Invalid input format.");
            }
        }
        private int Add(int x, int y)
        {
            return x + y;
        }
        private int Subtract(int x, int y)
        {
            return x - y;
        }
        private int Divide(int x, int y)
        {
            return x / y;
        }
        private int Multiply(int x, int y)
        {
            return x * y;
        }

        public void Start()
        {
            string input = ""; // Try also "12 - 34", "12+34", etc.
            int result = 0;

            while (true)
            {
                Console.WriteLine("write the input expression : ");
                input = Console.ReadLine();
                AnalyzeLine(input);

                switch (operation)
                {
                    case '+':
                        result = Add(num1, num2);
                        Console.Write(result);
                        break;

                    case '-':
                        result = Subtract(num1, num2);
                        Console.Write(result);
                        break;

                    case '/':
                        result = Divide(num1, num2);
                        Console.Write(result);
                        break;

                    case '*':
                        result = Multiply(num1, num2);
                        Console.Write(result);
                        break;

                    default:
                        Console.WriteLine("invalid operation symbol");
                        break;
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            calc.Start();
        }
    }
}
