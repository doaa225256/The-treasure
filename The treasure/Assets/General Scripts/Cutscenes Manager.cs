using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutscenesManager : MonoBehaviour
{

    
    public VideoPlayer videoPlayer; 

    void Start()
    {
        
    }

    public void PlayCutscene()
    {
        // Play the cutscene when triggered
        videoPlayer.Play(); // Or play animation clips
    }

    public void StopCutscene()
    {
        // Stop the cutscene if needed (e.g., if the player skips it)
        videoPlayer.Stop(); // Or stop animations
    }
}
