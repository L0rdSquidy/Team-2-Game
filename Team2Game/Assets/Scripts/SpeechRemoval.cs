using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechRemoval : MonoBehaviour
{
 
    private float timer;

   
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1.5f)
        {
            timer = 0;
            gameObject.SetActive(false);
        }
    }
}
