namespace Core;

public class LogResourceManager : IDisposable
{
    private StreamWriter _writer;
    private bool _disposed = false;

    public LogResourceManager(string logPath)
    {
        _writer = new StreamWriter(logPath, append: true);
        _writer.WriteLine($"[{DateTime.Now:HH:mm:ss}] Session started");
        Console.WriteLine($"  [Log] File opened: {logPath}");
    }

    public void Log(string message)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(LogResourceManager));
        _writer.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
        Console.WriteLine($"  [Log] {message}");
    }

    public void Dispose()
    {
        if (_disposed) return;
        _writer.WriteLine($"[{DateTime.Now:HH:mm:ss}] Session ended");
        _writer.Dispose();
        _disposed = true;
        Console.WriteLine("  [Log] File closed (Dispose called)");
    }
}