using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoughKnead : MonoBehaviour
{
    [SerializeField] private Slider ProgressBar;
    [SerializeField] private float FailTime;
    [SerializeField] private GameObject BakingBar;

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            ProgressBar.value += 1f;
            FailTime = 0.1f;
        }
        if (FailTime > 0)
        {
            FailTime -= Time.deltaTime;
        } else 
        {
            ProgressBar.value -= 0.01f;
        }
        if (ProgressBar.value == ProgressBar.maxValue)
        {
            BakingBar.SetActive(true);
            ProgressBar.gameObject.SetActive(false);
            Destroy(this);
        }

    }
}
