using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            Timer timerScript = hit.gameObject.GetComponent<Timer>();
            timerScript.chrono.Stop();
            timerScript.TimerText.color = Color.green;
            timerScript.TimerText.fontSize *= 2;
        }
    }

}
