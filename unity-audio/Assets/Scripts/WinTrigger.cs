using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class WinTrigger : MonoBehaviour
{
    public GameObject winCanvas;
    public GameObject timerCanvas;

    private string timerText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<StarterAssetsInputs>().OnApplicationFocus(false);
            GameObject.Find("Player").GetComponent<StarterAssetsInputs>().SetCursorState(false);
            other.gameObject.GetComponent<Timer>().enabled = false;
            timerText = other.gameObject.GetComponent<Timer>().timerText.text;

            Time.timeScale = 0;
            winCanvas.SetActive(true);
            Win();
            timerCanvas.SetActive(false);

            // other.gameObject.GetComponent<Timer>().enabled = false;
            // other.gameObject.GetComponent<Timer>().timerText.color = Color.green;
            // other.gameObject.GetComponent<Timer>().timerText.fontSize = 60;
        }
    }

    public void Win()
    {
        GameObject.Find("CheeryMonday").SetActive(false);
        GameObject.Find("VictoryPiano").GetComponent<AudioSource>().enabled = true;
        GameObject.Find("WinTimerText").GetComponent<Text>().text = timerText;
    }
}
