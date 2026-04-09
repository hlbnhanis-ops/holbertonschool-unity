using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    public AudioMixer mixer;


    // Start is called before the first frame update
    void Start()
    {
        mixer.SetFloat("bgmVol", LinearToDecibel(PlayerPrefs.GetFloat("bgmVol")));
        mixer.SetFloat("sfxVol", LinearToDecibel(PlayerPrefs.GetFloat("sfxVol")));
        mixer.FindSnapshot("Normal").TransitionTo(0.0F);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelSelect(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Options()
    {
        PlayerPrefs.SetString("lastSceneName", "MainMenu");
        SceneManager.LoadScene("Options");
    }

    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }

    private float LinearToDecibel(float linear)
    {
        float dB;

        if (linear != 0)
            dB = 20.0f * Mathf.Log10(linear);
        else
            dB = -144.0f;

        return dB;
    }
}
