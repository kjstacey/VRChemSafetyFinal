using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AspectRatio : MonoBehaviour
{
    [SerializeField] VideoPlayer vp;
    // Start is called before the first frame update
    void Start()
    {
        vp.aspectRatio = VideoAspectRatio.Stretch;
    }
}
