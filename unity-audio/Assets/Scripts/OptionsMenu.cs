using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{

    public bool isInverted;
    public bool useTouch;

    public GameObject yToggle;
    public GameObject tToggle;

    public Slider bgmSlider;
    public Slider sfxSlider;

    public AudioMixer mixer;

    // Start is called before the first frame update
    void Awake()
    {
        mixer.FindSnapshot("Normal").TransitionTo(0.0F);
        bgmSlider.value = PlayerPrefs.GetFloat("bgmVol");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVol");
        Debug.Log(LinearToDecibel(bgmSlider.value));
        mixer.SetFloat("bgmVol", LinearToDecibel(bgmSlider.value));
        mixer.SetFloat("sfxVol", LinearToDecibel(sfxSlider.value));
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
        PlayerPrefs.SetFloat("bgmVol", bgmSlider.value);
        mixer.SetFloat("bgmVol", LinearToDecibel(bgmSlider.value));
        PlayerPrefs.SetFloat("sfxVol", sfxSlider.value);
        mixer.SetFloat("sfxVol", LinearToDecibel(sfxSlider.value));
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

    private float LinearToDecibel(float linear)
    {
        float dB;

        if (linear != 0)
            dB = 20.0f * Mathf.Log10(linear);
        else
            dB = -80.0f;

        return dB;
    }
}
