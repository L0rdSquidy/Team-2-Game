using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Baking : MonoBehaviour
{
    [SerializeField] private Scrollbar ChanceBar;
    [SerializeField] private Scrollbar Arrow;
    private bool ClickedArrow;
    private float WaitTime = 1.5f;

    void Start()
    {
        ChanceBar.value = Random.Range(0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        WaitTime -= Time.deltaTime;
        if (WaitTime < 0)
        {
            if (Arrow.value != 0 &&  ChanceBar.value > 0 && !ClickedArrow)
        {
            Arrow.value -= 0.01f / 10;
        } 
        if (Arrow.value <= 0 && !ClickedArrow)
        {
            Debug.Log("burnt");
            ClickedArrow = true;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            ClickedArrow = true;
            if (ChanceBar.value >= Arrow.value - 0.1 && ChanceBar.value <= Arrow.value + 0.1)
            {
                Debug.Log("Bread");
            }else
            {
                Debug.Log("burnt");
            }
        }
        
        }
        
        
    }
}
