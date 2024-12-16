namespace StopwatchApp.Core;

public class Stopwatch
{
    private TimeSpan _timeElapsed;
    private bool _isRunning;
    private DateTime? _startTime;

    public event EventHandler<StopwatchEventArgs>? StartedEvent;
    public event EventHandler<StopwatchEventArgs>? StoppedEvent;
    public event EventHandler<StopwatchEventArgs>? ResetEvent;
    public event EventHandler<StopwatchEventArgs>? TickEvent;

    public TimeSpan TimeElapsed => _timeElapsed;
    public bool IsRunning => _isRunning;

    public void Start()
    {
        if (_isRunning)
            return;

        _isRunning = true;
        _startTime = DateTime.Now;
        OnStarted("Stopwatch Started!");
    }

    public void Stop()
    {
        if (!_isRunning)
            return;

        _isRunning = false;
        UpdateElapsedTime();
        _startTime = null;
        OnStopped("Stopwatch Stopped!");
    }

    public void Reset()
    {
        _isRunning = false;
        _timeElapsed = TimeSpan.Zero;
        _startTime = null;
        OnReset("Stopwatch Reset!");
    }

    public void UpdateTime()
    {
        if (!_isRunning)
            return;

        UpdateElapsedTime();
        OnTick($"Time: {_timeElapsed:hh\\:mm\\:ss}");
    }

    private void UpdateElapsedTime()
    {
        if (_startTime != null)
        {
            _timeElapsed += DateTime.Now - _startTime.Value;
            _startTime = DateTime.Now;
        }
    }

    protected virtual void OnStarted(string message)
    {
        StartedEvent?.Invoke(this, new StopwatchEventArgs(message, _timeElapsed));
    }

    protected virtual void OnStopped(string message)
    {
        StoppedEvent?.Invoke(this, new StopwatchEventArgs(message, _timeElapsed));
    }

    protected virtual void OnReset(string message)
    {
        ResetEvent?.Invoke(this, new StopwatchEventArgs(message, _timeElapsed));
    }

    protected virtual void OnTick(string message)
    {
        TickEvent?.Invoke(this, new StopwatchEventArgs(message, _timeElapsed));
    }
}