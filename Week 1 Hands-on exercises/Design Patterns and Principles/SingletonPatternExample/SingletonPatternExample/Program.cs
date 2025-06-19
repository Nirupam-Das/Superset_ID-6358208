using System;

public class Logger
{
    private static Logger _instance;

    private Logger()
    {
        Console.WriteLine("Logger instance created.");
    }

    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Logger();
        }
        return _instance;
    }

    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();
        logger1.Log("This is the first log message.");

        Logger logger2 = Logger.GetInstance();
        logger2.Log("This is the second log message.");

        if (object.ReferenceEquals(logger1, logger2))
        {
            Console.WriteLine("Only one Logger instance exists.");
        }
        else
        {
            Console.WriteLine("Different instances exist. Singleton failed.");
        }

        Console.ReadLine(); 
    }
}
