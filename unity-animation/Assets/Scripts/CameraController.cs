using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public bool isInverted = false;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("invertedY") == 1)
        {
            isInverted = true;
        }
        else
        {
            isInverted = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
