using StopwatchApp.Core;

namespace StopwatchApp.UI;

public class ConsoleDisplay
{
    private readonly Stopwatch _stopwatch;
    private bool _isRunning = true;

    public ConsoleDisplay(Stopwatch stopwatch)
    {
        _stopwatch = stopwatch;
        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        _stopwatch.StartedEvent += OnStopwatchEvent;
        _stopwatch.StoppedEvent += OnStopwatchEvent;
        _stopwatch.ResetEvent += OnStopwatchEvent;
        _stopwatch.TickEvent += OnUpdateTimeStopwatchEvent;
    }

    public void Run()
    {
        DisplayInstructions();

        while (_isRunning)
        {
            if (Console.KeyAvailable)
            {
                HandleKeyPress(Console.ReadKey(true).Key);
            }

            _stopwatch.UpdateTime();
            Thread.Sleep(1000);
        }
    }

    private void DisplayInstructions()
    {
        Console.WriteLine("Stopwatch Controls:");
        Console.WriteLine("S - Start");
        Console.WriteLine("T - Stop");
        Console.WriteLine("R - Reset");
        Console.WriteLine("Q - Quit");
        Console.WriteLine();
    }

    private void HandleKeyPress(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.S:
                _stopwatch.Start();
                break;
            case ConsoleKey.T:
                _stopwatch.Stop();
                break;
            case ConsoleKey.R:
                _stopwatch.Reset();
                break;
            case ConsoleKey.Q:
                _isRunning = false;
                break;
        }
    }

    private void OnStopwatchEvent(object? sender, StopwatchEventArgs e)
    {
        Console.WriteLine(e.Message);
    }

    private void OnUpdateTimeStopwatchEvent(object? sender, StopwatchEventArgs e)
    {
        Console.Clear();
        Console.WriteLine(e.Message);
    }
}