using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Resource : MonoBehaviour
{
    //this is the inventory and game manager. This script is shared between both players

    public static Resource Instance;

    public int[] amsPlayerInv = new int[5]; //amsterdam
    public int[] amsShipInv = new int[5]; //amsterdam
    public int[] stockPlayerInv = new int[5]; //stockholm
    public int[] stockShipInv = new int[5]; //stockholm
    //resources[0] for wood, [1] for wheat, [2] for iron, [3] for bread, [4] for weapons

    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }



    
    
}
