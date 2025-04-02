using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;


public class Resource : NetworkBehaviour
{
    //this is the inventory and game manager. This script is shared between both players

    public static Resource Instance;

    public NetworkList<int> amsPlayerInv = new NetworkList<int>();
    public NetworkList<int> stockPlayerInv = new NetworkList<int>();
    public NetworkList<int> amsShipInv = new NetworkList<int>();
    public NetworkList<int> stockShipInv = new NetworkList<int>();

    //public NetworkVariable<int[]> amsPlayerInv = new NetworkVariable<int[]>(); //amsterdam
    //public NetworkVariable<int[]> amsShipInv = new NetworkVariable<int[]>(); //amsterdam
    //public NetworkVariable<int[]> stockPlayerInv = new NetworkVariable<int[]>(); //stockholm
    //public NetworkVariable<int[]> stockShipInv = new NetworkVariable<int[]>(); //stockholm
    //public NetworkVariable<List<int>> stockShipInv2 = new NetworkVariable<List<int>>(); //stockholm

    //resources[0] for wood, [1] for wheat, [2] for iron, [3] for bread, [4] for weapons

    public bool isHostDutch;
    

    private void Awake()
    {
        /*if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;*/
        DontDestroyOnLoad(gameObject);
        
        

       amsPlayerInv[1] = 5;
       // amsPlayerInv.Value.Add(0);
       // amsPlayerInv.Value.Add(5);
       // amsPlayerInv.Value.Add(0);
       // amsPlayerInv.Value.Add(0);
       // amsPlayerInv.Value.Add(0);

       // stockPlayerInv.Value.Add(0);
       // stockPlayerInv.Value.Add(0);
       // stockPlayerInv.Value.Add(0);
       // stockPlayerInv.Value.Add(0);
      //  stockPlayerInv.Value.Add(2);
        stockPlayerInv[4] = 2;
    }

    public void CallSync() 
    {
        Debug.Log("Call");
       // SyncScriptServerRpc(amsPlayerInv.Value, stockPlayerInv.Value, amsShipInv.Value, stockShipInv.Value);
    }

    //int pingCount,
    //[ClientRpc(SendTo.NotMe)]
    //[ClientRpc]
   /* [ServerRpc(RequireOwnership = false)]
    public void SyncScriptServerRpc(List<int> amsPlayer, List<int> stockPlayer, List<int> amsShip, List<int> stockShip) 
{
        Debug.Log("RPC");
        amsPlayerInv.Value = amsPlayer;
        stockPlayerInv.Value = stockPlayer;
        amsShipInv.Value = amsShip;
        stockShipInv.Value = stockShip;
        //InventorySyncLocal(amsPlayerInv, stockPlayerInv, amsShipInv, stockShipInv);
    }*/



    /*    public void InventorySyncLocal(int[] amsPlayer, int[] stockPlayer, int[] amsShip, int[] stockShip) 
        {
            amsPlayerInv = amsPlayer;
            stockPlayerInv = stockPlayer;
            amsShipInv = amsShip;
            stockShipInv = stockShip;
        }*/

    //[ClientRpc]

}
