using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerController : MonoBehaviour
{

    public GameObject TouchCanvas;

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
            transform.position = new Vector3(0, 1.25f, 0);
            GetComponent<CharacterController>().enabled = true;
            // GetComponent<ThirdPersonController>().enabled = false;
            // StartCoroutine(WaitForRespawn());
        }
    }

    IEnumerator WaitForRespawn()
    {
        yield return new WaitForSeconds(5);
        GetComponent<ThirdPersonController>().enabled = true;
    }
}
