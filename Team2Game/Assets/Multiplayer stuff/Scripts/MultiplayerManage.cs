using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class MultiplayerManage : MonoBehaviour
{
    NetworkManager netManage;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        netManage = GetComponent<NetworkManager>();
    }



    public void SessionStart(bool host) 
    {
        if (host) 
        {
            netManage.StartHost();
        }
        else 
        {
            netManage.StartClient();
        }
    }
}
