namespace SingletonExample;

// Singleton Logger
public sealed class Logger
{
    private static readonly Lazy<Logger> instance = new Lazy<Logger>(() => new Logger());

    // Private constructor prevents external instantiation
    private Logger() { }

    public static Logger Instance => instance.Value;

    public void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now}] {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Access the same Logger instance everywhere
        Logger.Instance.Log("Application started.");
        
        // Simulate different parts of the app using the same logger
        DoWork();
        Logger.Instance.Log("Application finished.");
    }

    static void DoWork()
    {
        Message ms = new Message();
        Logger.Instance.Log("Doing some work...");

        ms.Rec();
        ms.Send();

        Logger.Instance.Log("Work is done.");
    }
}

class Message
{
    public void Send()
    {
        Logger.Instance.Log("Message was sent.");
    }

    public void Rec()
    {
        Logger.Instance.Log("Message was received.");
    }
}
