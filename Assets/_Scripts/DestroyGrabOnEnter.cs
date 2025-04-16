using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DestroyGrabOnEnter : MonoBehaviour
{
    [SerializeField] GameObject vhsTape;

    public void PreventInteraction()
    {
        vhsTape.layer = 2;
    }
}
