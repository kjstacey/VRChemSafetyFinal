using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    //[SerializeField] GameObject introText;

    public void ReloadCurrent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void EnterSimulationScene()
    {
        SceneManager.LoadScene("Demo");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
