
public class StopwatchTimer : Timer
{
    public StopwatchTimer() : base(0)
    {
        
    }

    public override void Tick(float deltaTime)
    {
        if(IsRunning)
        {
            time += deltaTime;
        }
    }

    public void ResetStopwatch() => time = 0;

    public float GetTime() => time;
}
