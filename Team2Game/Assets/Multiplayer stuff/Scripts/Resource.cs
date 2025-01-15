using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Resource : MonoBehaviour
{
    public static Resource Instance;

    public int[] playerInv = new int[5];
    public int[] ownShipInv = new int[5];
    public int[] otherShipInv = new int[5];
    //resources[0] for wood, [1] for wheat, [2] for iron, [3] for bread, [4] for weapons

    public bool isOwnShip;//is ship being interacted with the players own ship = true
                //is the ship the other players ship = false
    
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
