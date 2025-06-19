public class FinancialForecaster
{
    // Recursive method
    public static double PredictFutureValue(double initialAmount, double growthRate, int years)
    {
        if (years == 0)
            return initialAmount;

        return PredictFutureValue(initialAmount, growthRate, years - 1) * (1 + growthRate);
    }

    // Iterative optimization
    public static double PredictFutureValueIterative(double initialAmount, double growthRate, int years)
    {
        double futureValue = initialAmount;
        for (int i = 1; i <= years; i++)
        {
            futureValue *= (1 + growthRate);
        }
        return futureValue;
    }
}
