using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    [SerializeField] GameObject doors;

    private void Start()
    {
        Invoke("OpenDoor", 20f);
    }

    void OpenDoor()
    {
        doors.GetComponent<Animation>().Play("Open");
    }
}
