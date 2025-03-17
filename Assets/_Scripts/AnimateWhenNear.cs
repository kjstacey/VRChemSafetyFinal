using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateWhenNear : MonoBehaviour
{
    public Animation doorAnimation;  // The Animation component attached to the door
    public string animationName = "Open";  // Name of the embedded animation

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Ensure the player is the one triggering the door
        {
            Debug.Log("Player entered the trigger zone!");
            if (!doorAnimation.isPlaying)  // Play the animation only if it's not already playing
            {
                doorAnimation.Play(animationName);  // Play the animation
            }
        }
    }
}
