using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Harvest : MonoBehaviour
{
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private FarmLand farmLand;
    private void Update() 
    {
        if (scrollbar.value == 1)
        {
            farmLand.WheeetHarvest();
            scrollbar.value = 0;
        }
        
    }
}
