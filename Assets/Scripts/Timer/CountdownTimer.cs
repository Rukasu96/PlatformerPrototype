public class CountdownTimer : Timer
{
    public bool IsFinished => time <= 0;

    public CountdownTimer(float value) : base(value)
    {
        
    }

    public override void Tick(float deltaTime)
    {
        if(IsRunning && time > 0)
        {
            time -= deltaTime;
        }

        if(IsRunning && time <= 0)
        {
            StopTimer();
        }
    }

    public void ResetCountdown() => time = initialTime;

    public void ResetCountdown(float newTime)
    {
        initialTime = newTime;
        ResetCountdown();
    }
}
