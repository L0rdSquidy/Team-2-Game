using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using TMPro;
public class MultiplayerManage : MonoBehaviour
{
    //NetworkManager netManage;

    public string joinCode;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //netManage = GetComponent<NetworkManager>();
    }


   /* public void StartHost() 
    {
        netManage.StartHost();
        SessionStart();
    }

    public void StartJoin()
    {
        netManage.StartClient();
        SessionStart();
    }*/

    public void SessionStart(string jCode) //
    {
        joinCode = jCode;

        SceneManager.LoadScene(1);

        

        
    }
}
