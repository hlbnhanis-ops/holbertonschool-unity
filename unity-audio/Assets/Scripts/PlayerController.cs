using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public GameObject TouchCanvas;
    public AudioSource grass;
    public AudioSource stone;

    private PlayerSFX player;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("useTouch") == 0)
        {
            GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
            GetComponent<StarterAssetsInputs>().OnApplicationFocus(true);
            GetComponent<StarterAssetsInputs>().SetCursorState(true);
            GetComponent<StarterAssetsInputs>().cursorLocked = false;
        }
        else
        {
            GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
            GetComponent<StarterAssetsInputs>().OnApplicationFocus(false);
            GetComponent<StarterAssetsInputs>().SetCursorState(false);
            GetComponent<StarterAssetsInputs>().cursorLocked = false;
        }

        if (PlayerPrefs.GetInt("useTouch") == 1)
        {
            TouchCanvas.SetActive(true);
        }

        player = GameObject.Find("ty").GetComponent<PlayerSFX>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            if (GetComponent<Timer>().timerText.color == Color.green)
            {
                GetComponent<Timer>().timerText.color = Color.white;
                GetComponent<Timer>().timerText.fontSize = 48;
                GetComponent<Timer>().enabled = true;
                GetComponent<Timer>().ResetTimer();
                GetComponent<Timer>().enabled = false;
            }
            GetComponent<CharacterController>().enabled = false;
            transform.position = new Vector3(0, 10.0f, 0);
            GetComponent<CharacterController>().enabled = true;
            StartCoroutine(WaitForRespawn());
        }
        if (other.gameObject.CompareTag("Grass"))
        {
            player.step = grass;
        }
        else if (other.gameObject.CompareTag("Stone"))
        {
            player.step = stone;
        }
    }


    // private void OnTriggerStay(Collider other)
    // {
    //     player = GetComponent<ThirdPersonController>();
    //     if (player)
    //     {
    //         if (player.Moving && player.Grounded && !player.running.isPlaying)
    //         {
    //             player.running.Play();
    //         }
    //         else if (!player.Moving && player.running.isPlaying)
    //         {
    //             player.running.Stop();
    //         }
    //     }
    // }
    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Grass"))
    //     {
    //         grass.Stop();
    //     }
    //     else if (other.gameObject.CompareTag("Stone"))
    //     {
    //         stone.Stop();
    //     }
    // }


    IEnumerator WaitForRespawn()
    {
        GetComponent<PlayerInput>().enabled = false;
        yield return new WaitForSeconds(10);
        GetComponent<PlayerInput>().enabled = true;
    }
}
