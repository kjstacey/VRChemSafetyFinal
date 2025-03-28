using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnableIntroText : MonoBehaviour
{
    [SerializeField] GameObject introText;

    private void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            Debug.Log("Level 1 loaded");
            Invoke("setFalse", 10.0f);
        }
    }

    private void setFalse()
    {
        introText.SetActive(false);
    }
}
