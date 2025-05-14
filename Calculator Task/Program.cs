using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Calculator_Task
{
    public class Calculator
    {
        private int num1 = 0;
        private int num2 = 0;
        private char operation = ' ';

        //Analyzing string line 
        private void AnalyzeLine(string input, ref int res)
        {
            Match chainedMatch = Regex.Match(input, @"^([\+\-\*/])\s*(-?\d+)$");
            Match match = Regex.Match(input, @"(-?\d+)\s*([\+\-\*/])\s*(-?\d+)");

            if(input == "c")
            {
                this.operation = 'c';
                this.num1 = 0;
                this.num2 = 0;
                res = 0;
            }
            else if(input == "l")
            {
                this.operation = 'l';
                this.num1 = 0;
                this.num2 = 0;
                res = 0;
            }
            else if (chainedMatch.Success)
            {
                this.num1 = res;
                this.operation = char.Parse(chainedMatch.Groups[1].Value);
                this.num2 = int.Parse(chainedMatch.Groups[2].Value);
            }
            else if (match.Success)
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

        // Functons for calculations 
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

        //Logger function for saving calculations history
        private void LogCalculation(int result)
        {
            string logEntry = $"{num1}{operation}{num2}={result}";
            File.AppendAllText("log.txt", logEntry + Environment.NewLine);
        }

        //Start Point function
        public void Start()
        {
            string input = ""; 
            int result = 0;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("write the input expression : ");
                Console.Write(result);
                input = Console.ReadLine();
                AnalyzeLine(input, ref result);

                switch (operation)
                {
                    case '+':
                        result = Add(num1, num2);
                        Console.Write(result);
                        LogCalculation(result);
                        break;

                    case '-':
                        result = Subtract(num1, num2);
                        Console.Write(result);
                        LogCalculation(result);
                        break;

                    case '/':
                        result = Divide(num1, num2);
                        Console.Write(result);
                        LogCalculation(result);
                        break;

                    case '*':
                        result = Multiply(num1, num2);
                        Console.Write(result);
                        LogCalculation(result);
                        break;

                    case 'c':
                        Console.WriteLine("Calculator cleared.");
                        continue;
                    
                    case 'l':
                        Console.WriteLine("Calculator History");
                        if (File.Exists("log.txt"))
                        {
                            string content = File.ReadAllText("log.txt");
                            Console.WriteLine(content);
                        }
                        else
                        {
                            Console.WriteLine("Log file does not exist.");
                        }
                        continue;

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
