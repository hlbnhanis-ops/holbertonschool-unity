using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private Stopwatch timer = new Stopwatch();

    // Start is called before the first frame update
    public void Start()
    {
        timer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = timer.Elapsed.Minutes + ":" + timer.Elapsed.Seconds.ToString("D2") + "." + timer.Elapsed.Milliseconds.ToString("D");
    }

    // reset timer
    public void ResetTimer()
    {
        timer.Reset();
    }

    public void PauseTimer()
    {
        timer.Stop();
    }
}
