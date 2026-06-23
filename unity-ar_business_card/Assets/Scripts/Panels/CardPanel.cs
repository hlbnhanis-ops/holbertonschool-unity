using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPanel : MonoBehaviour
{
    public void OnMailClicked()
    {
        Application.OpenURL("mailto:hlbn.hanis@gmail.com");
    }

    public void OnGithubClicked()
    {
        Application.OpenURL("https://github.com/hlbnhanis-ops");
    }
}
