using UnityEngine;

public class ProjectorInteraction : MonoBehaviour
{
    public ParticleSystem ParticleSystem;

    public void TurnOn()
    {
        ParticleSystem.gameObject.SetActive(true);
    }
}
