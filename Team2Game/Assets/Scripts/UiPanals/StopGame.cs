using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StopGame : MonoBehaviour
{
    // Method to stop the game
    public void Stop()
    {
        // Stop the game by exiting play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}