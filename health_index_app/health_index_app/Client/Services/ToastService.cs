using System.Timers;
using Timer = System.Timers.Timer;

namespace health_index_app.Client.Services;

public class ToastService
{
    public event Action<string, ToastLevel, int>? OnShow;
    public event Action? OnHide;
    private Timer? Countdown;

    public void ShowToast(string message, ToastLevel level, int countdown)
    {
        OnShow?.Invoke(message, level, countdown);
        StartCountdown(countdown);
    }

    private void StartCountdown(int countdown)
    {
        SetCountdown(countdown);

        if (Countdown!.Enabled)
        {
            Countdown.Stop();
            Countdown.Start();
        }
        else
        {
            Countdown!.Start();
        }
    }

    private void SetCountdown(int countdown)
    {
        if (Countdown != null) return;

        Countdown = new Timer(countdown);
        Countdown.Elapsed += HideToast;
        Countdown.AutoReset = false;
    }

    private void HideToast(object? source, ElapsedEventArgs args)
        => OnHide?.Invoke();

    public void Dispose()
        => Countdown?.Dispose();
}