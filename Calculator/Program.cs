using System;
using ClassLibrary;
using ClassLibrary.Operations;
using ClassLibrary.Parser;
using ClassLibrary.Validator;

namespace CalculatorApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator(new Validator(), new PostfixNotationParser());
            CalculatorConfiguration(calculator);
            var example = Console.ReadLine();
            calculator.SetExample(example);
            Console.WriteLine(calculator.Calculate());
            Console.ReadLine();
        }

        private static void CalculatorConfiguration(Calculator calculator)
        {
            calculator
                .AddOperation(new DivisionOperation())
                .AddOperation(new MinusOperation())
                .AddOperation(new MultiplyOperation())
                .AddOperation(new PlusOperation())
                .AddOperation(new LeftBracket())
                .AddOperation(new RightBracket())
                .AddOperation(new ExtentOperation());
        }
    }
}
