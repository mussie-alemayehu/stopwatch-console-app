namespace StopwatchApp.Core;

public class StopwatchEventArgs : EventArgs
{
    public string Message { get; }
    public TimeSpan TimeElapsed { get; }

    public StopwatchEventArgs(string message, TimeSpan timeElapsed)
    {
        Message = message;
        TimeElapsed = timeElapsed;
    }
}