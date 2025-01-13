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
   /* void Start()
    {
        netManage = GetComponent<NetworkManager>();
    }*/



    public void SessionStart() //bool host
    {
        joinCode = GameObject.Find("RelayManager").GetComponent<Relay>().joinCodeTxt.text;

        SceneManager.LoadScene(1);

        

        /*if (host) 
        {
            netManage.StartHost();
        }
        else 
        {
            netManage.StartClient();
        }*/
    }
}
