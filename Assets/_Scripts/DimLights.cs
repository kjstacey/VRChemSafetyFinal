using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;
using UnityEngine.Video;
using static UnityEngine.Rendering.DebugUI;

public class DimLights : MonoBehaviour
{
    [SerializeField] Light light1;
    [SerializeField] Light light2;

    // Start is called before the first frame update
    public void LowerIntensity()
    {
        light1.intensity = 0.5f;
        light2.intensity = 0.3f;
    }

    private void OnVideoPlaybackComplete(VideoPlayer vp)
    {
        StartCoroutine(Wait());
        light1.intensity = 1.07f;
        light2.intensity = 1.07f;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }
}
