using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveInactive : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    public void Set()
    {
        if (canvas.activeInHierarchy)
        {
            canvas.SetActive(false);
        }
        else
        {
            canvas.SetActive(true);
        }
    }
}
