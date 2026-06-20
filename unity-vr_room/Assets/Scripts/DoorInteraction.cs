using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public Animator DoorAnimator;

    public void Open()
    {
        DoorAnimator.SetBool("character_nearby", true);
    }
}
