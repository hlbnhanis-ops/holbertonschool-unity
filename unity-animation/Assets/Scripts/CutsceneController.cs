using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{

    public GameObject mainCamera;
    public GameObject cutsceneCamera;
    public GameObject player;
    public GameObject timer;
    public GameObject touchMenu;

    private bool _hasAnimator;
    private Animator _animator;
    private int _animationState;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start()");
        _animator = GetComponent<Animator>();
        _animationState = Animator.StringToHash("Level");
        _animator.SetInteger(_animationState, SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        _animator = GetComponent<Animator>();

        _animator.SetInteger(_animationState, SceneManager.GetActiveScene().buildIndex);
        if (_animator.GetBool("running") == false)
        {
            mainCamera.GetComponent<Camera>().enabled = true;
            mainCamera.GetComponent<AudioListener>().enabled = true;
            timer.SetActive(true);
            touchMenu.SetActive(true);
            player.GetComponent<PlayerController>().enabled = true;
            player.GetComponent<StarterAssets.ThirdPersonController>().enabled = true;
            // player.GetComponent<StarterAssets.ThirdPersonController>().enabled = true;

            cutsceneCamera.SetActive(false);
        }
    }
}
