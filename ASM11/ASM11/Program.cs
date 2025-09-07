using System;

namespace FactorialCalculator
{
    public class Calculator
    {
        public int CalculateFactorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("can't be nagative number");
            }

            int result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Console.Write("Enter a positive number: ");
            int number = int.Parse(Console.ReadLine());

            try
            {
                int factorial = calculator.CalculateFactorial(number);
                Console.WriteLine($"Factorial of {number} is: {factorial}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
