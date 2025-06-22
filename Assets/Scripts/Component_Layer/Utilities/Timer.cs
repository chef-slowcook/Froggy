using UnityEngine;

// A code component to measure time in seconds.
public class Timer : MonoBehaviour
{
    [Header("Timer Settings")]
    private float maxTime = 10f; // Maximum time for the timer (in seconds)

    // Static variables to track the current time and whether the timer is running
    [Header("Timer State")]
    private float currentTime = 0f;
    private bool isRunning = false;

    void Start()
    {
        currentTime = 0f;
    }
    void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= maxTime)
            {
                StopTimer();
            }
        }
    }

    /////////////////////////////
    ///// TIMER FUNCTIONS
    //Returns elapsed time in seconds
    public float GetTime()
    {
        return currentTime;
    }

    //Stops and returns elapsed time in seconds
    public float StopTimer()
    {
        isRunning = false;
        return currentTime;
    }

    // Voids
    public void SetMaxTime(float time)
    {
        maxTime = time;
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void RestartTimer()
    {
        currentTime = 0f;
        isRunning = true;
    }

    public void ResetTimer()
    {
        currentTime = 0;
    }
}
