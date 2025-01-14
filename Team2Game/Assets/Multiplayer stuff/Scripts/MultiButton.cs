using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiButton : MonoBehaviour
{
    GameObject NetManager;

    bool hosting;

    // Start is called before the first frame update
    void Start()
    {
        NetManager = GameObject.Find("NetManager");
        if(transform.name == "Host") 
        {
            hosting = true;
        }
        else 
        {
            hosting = false;
        }
    }

    public void ButtonPressed() 
    {
        NetManager.GetComponent<MultiplayerManage>().SessionStart();//hosting
    }
}
