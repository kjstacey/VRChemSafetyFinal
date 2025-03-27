using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnableIntroText : MonoBehaviour
{
    [SerializeField] GameObject introText;
    bool started = false;

    // Start is called before the first frame update
    private void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            Debug.Log("Level 1 loaded");
            //introText.SetActive(true);
            StartCoroutine(Wait());
            introText.SetActive(false);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
        Debug.Log("I waited to do something!");
    }
}
