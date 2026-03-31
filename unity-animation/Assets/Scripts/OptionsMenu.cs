using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public bool isInverted;
    public bool useTouch;

    public GameObject yToggle;
    public GameObject tToggle;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("invertedY") == 1)
        {
            yToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = true;
            isInverted = true;
        }
        else
        {
            yToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = false;
            isInverted = false;
        }
        if (PlayerPrefs.GetInt("useTouch") == 1)
        {
            tToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = true;
            useTouch = true;
        }
        else
        {
            tToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = false;
            useTouch = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(isInverted);
        // Debug.Log(PlayerPrefs.GetInt("invertedY"));
    }

    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("lastSceneName"));
        // SceneManager.UnloadSceneAsync("Options");
    }

    public void Apply()
    {
        if (isInverted)
        {
            PlayerPrefs.SetInt("invertedY", 1);
        }
        else
        {
            PlayerPrefs.SetInt("invertedY", 0);
        }
        if (useTouch)
        {
            PlayerPrefs.SetInt("useTouch", 1);
        }
        else
        {
            PlayerPrefs.SetInt("useTouch", 0);
        }
        SceneManager.LoadScene(PlayerPrefs.GetString("lastSceneName"));
    }

    public void ToggleInvert()
    {
        Debug.Log("Toggle Invert");
        isInverted = !isInverted;
    }

    public void ToggleTouch()
    {
        Debug.Log("Toggle Touch");
        useTouch = !useTouch;
    }
}
