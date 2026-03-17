using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;

    public Stopwatch chrono;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chrono = Stopwatch.StartNew();
    }

    // Update is called once per frame
    void Update()
    {
        int minutes     = (int)chrono.Elapsed.TotalMinutes;
        int secondes    = chrono.Elapsed.Seconds;
        int millis      = chrono.Elapsed.Milliseconds / 10; // 0-99
        TimerText.text = $"{minutes:00}:{secondes:00}:{millis:00}";
    }
}
