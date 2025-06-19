using System;

class Program
{
    static void Main()
    {
        double initialAmount = 10000;       
        double annualGrowthRate = 0.07;     
        int years = 5;

        Console.WriteLine("Financial Forecasting using Recursion");
        double futureValueRecursive = FinancialForecaster.PredictFutureValue(initialAmount, annualGrowthRate, years);
        Console.WriteLine($"Recursive: Future value after {years} years = ${futureValueRecursive:F2}");

        Console.WriteLine("\nFinancial Forecasting using Iteration");
        double futureValueIterative = FinancialForecaster.PredictFutureValueIterative(initialAmount, annualGrowthRate, years);
        Console.WriteLine($"Iterative: Future value after {years} years = ${futureValueIterative:F2}");

        Console.ReadLine(); 
    }
}
