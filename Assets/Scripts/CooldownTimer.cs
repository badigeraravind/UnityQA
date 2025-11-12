// Simple deterministic cooldown timer used by gameplay systems.
// No UnityEngine dependency so it's safe to test in Edit Mode.
public class CooldownTimer
{
    private readonly float duration;
    private float elapsed;

    // Constructor: set cooldown duration in seconds.
    public CooldownTimer(float durationSeconds)
    {
        if (durationSeconds < 0f) throw new System.ArgumentException("durationSeconds must be >= 0");
        duration = durationSeconds;
        elapsed = durationSeconds; // start as ready by default
    }

    // Start or restart the cooldown (sets elapsed = 0).
    public void Start()
    {
        elapsed = 0f;
    }

    // Advance the timer by deltaSeconds (returns new elapsed).
    public float Tick(float deltaSeconds)
    {
        if (deltaSeconds < 0f) throw new System.ArgumentException("deltaSeconds must be >= 0");
        elapsed += deltaSeconds;
        if (elapsed > duration) elapsed = duration;
        return elapsed;
    }

    // Returns true when cooldown has completed (elapsed >= duration).
    public bool IsReady()
    {
        return elapsed >= duration;
    }

    // Reset the timer to be not ready (elapsed = 0).
    public void Reset()
    {
        elapsed = 0f;
    }

    // Remaining time until ready (0 when ready).
    public float Remaining()
    {
        return System.Math.Max(0f, duration - elapsed);
    }

    // For tests or debugging: get elapsed time (internal state).
    public float Elapsed => elapsed;
}
