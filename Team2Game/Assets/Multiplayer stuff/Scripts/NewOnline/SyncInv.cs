using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class SyncInv : MonoBehaviourPunCallbacks
{
    //script for syncing inventories

    PhotonView view;

    int syncNum = 0;

    GameObject numText;

    

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();

        numText = GameObject.Find("Num");
        numText.GetComponent<TextMeshProUGUI>().text = syncNum.ToString();
    }

    public void ButtonPressed(bool plus) //on value changed
    {
        if (plus) 
        {
            syncNum++;
        }
        else 
        {
            syncNum--;
        }

        view.RPC("Sync", RpcTarget.All, syncNum);
    }

    [PunRPC]
    public void Sync(int num) 
    {
        syncNum = num;
        numText.GetComponent<TextMeshProUGUI>().text = num.ToString();
    }
}
