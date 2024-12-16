using StopwatchApp.Core;
using StopwatchApp.UI;

class Program
{
    static void Main(string[] args)
    {
        var stopwatch = new Stopwatch();
        var display = new ConsoleDisplay(stopwatch);
        
        display.Run();
    }
}