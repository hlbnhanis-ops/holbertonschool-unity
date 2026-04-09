using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    public AudioSource step;
    public AudioSource splat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Step()
    {
        step.Play();
    }

    private void Splat()
    {
        splat.Play();
    }
}
