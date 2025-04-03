using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeButton : MonoBehaviour
{

    GameObject syncObject;
    Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        syncObject = GameObject.Find("Syncing");
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        //Debug.Log("Clicked!");

        if(transform.name == "Plus0") 
        {
            syncObject.GetComponent<SyncInv>().ButtonPressed(true, 0);
        }
        if (transform.name == "Plus1")
        {
            syncObject.GetComponent<SyncInv>().ButtonPressed(true, 1);
        }
        if (transform.name == "Plus2")
        {
            syncObject.GetComponent<SyncInv>().ButtonPressed(true, 2);
        }
        if (transform.name == "Plus3")
        {
            syncObject.GetComponent<SyncInv>().ButtonPressed(true, 3);
        }
        if (transform.name == "Plus4")
        {
            syncObject.GetComponent<SyncInv>().ButtonPressed(true, 4);
        }
        if (transform.name == "Minus0")
        {
            syncObject.GetComponent<SyncInv>().ButtonPressed(false, 0);
        }
        if (transform.name == "Minus1")
        {
            syncObject.GetComponent<SyncInv>().ButtonPressed(false, 1);
        }
        if (transform.name == "Minus2")
        {
            syncObject.GetComponent<SyncInv>().ButtonPressed(false, 2);
        }
        if (transform.name == "Minus3")
        {
            syncObject.GetComponent<SyncInv>().ButtonPressed(false, 3);
        }
        if (transform.name == "Minus4")
        {
            syncObject.GetComponent<SyncInv>().ButtonPressed(false, 4);
        }


    }

}
