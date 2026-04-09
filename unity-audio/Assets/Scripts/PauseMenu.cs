using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using StarterAssets;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{

    public bool pauseState = false;
    private Timer timer;
    public GameObject pauseMenu;

    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetString("lastSceneName", SceneManager.GetActiveScene().name);
        timer = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        pauseState = true;
        GameObject.Find("Player").GetComponent<StarterAssetsInputs>().SetCursorState(false);
		GameObject.Find("Player").GetComponent<StarterAssetsInputs>().cursorLocked = false;
        mixer.FindSnapshot("Muffled").TransitionTo(0.0F);
        pauseMenu.SetActive(true);
        timer.PauseTimer();
        Time.timeScale = 0;
        // SceneManager.LoadSceneAsync("Paused", LoadSceneMode.Additive);
    }

    public void Resume()
    {
        mixer.FindSnapshot("Normal").TransitionTo(0.0F);
        pauseState = false;
        if (PlayerPrefs.GetInt("useTouch") == 0)
        {
			GameObject.Find("Player").GetComponent<StarterAssetsInputs>().SetCursorState(true);
			GameObject.Find("Player").GetComponent<StarterAssetsInputs>().cursorLocked = true;
        }
        // SceneManager.UnloadSceneAsync("Paused");
        pauseMenu.SetActive(false);
        timer.Start();
        Time.timeScale = 1;
    }

    // get unity input pause


    public void OnRestart(InputValue value)
    {
        if (value.isPressed)
        {
            Restart();
        }
    }

    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(PlayerPrefs.GetString("lastSceneName"));
    }

    public void MainMenu()
    {
		Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    // private void OnApplicationFocus(bool hasFocus)
    // {
    //     SetCursorState(cursorLocked);
    // }

    // private void SetCursorState(bool newState)
    // {
    //     Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    // }
}
