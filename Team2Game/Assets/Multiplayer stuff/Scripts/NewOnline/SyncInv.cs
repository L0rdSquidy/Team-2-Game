using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;
public class SyncInv : MonoBehaviourPunCallbacks
{
    //script for syncing inventories

    GameObject[] texts;

    PhotonView view;

    int syncNum = 0;

    GameObject numText;

    int[] resources = new int[5]{ 0, 0, 0, 0, 0 };

    bool inTradingScene;



    public override void OnEnable()
    {
        //Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("OnSceneLoaded: " + scene.name);
        //Debug.Log(mode);
        if(scene.buildIndex == 7) 
        {
            texts = GameObject.FindGameObjectsWithTag("TradeText");
            

            inTradingScene = true;
        }
        else 
        {
            inTradingScene = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        view = GetComponent<PhotonView>();

        //numText = GameObject.Find("Num");
        //numText.GetComponent<TextMeshProUGUI>().text = syncNum.ToString();

        
        
    }

    public void ButtonPressed(bool plus, int type)
    {//bool plus or minus, string resource type
     //activated when value changed through trading

        

        if (plus && type == 0) 
        {
            ResourceManager.Instance.RemoveResource(ResourceManager.ResourceType.Wood, 1);

            foreach(GameObject text in texts) 
            {
                if(text.name == "InvText" + type) 
                {
                    text.GetComponent<TextMeshProUGUI>().text = 
                    "" + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Wood);
                }
            }

            view.RPC("SyncPlus", RpcTarget.All, type);
        }
        if (plus && type == 1)
        {
            ResourceManager.Instance.RemoveResource(ResourceManager.ResourceType.Wheat, 1);

            foreach (GameObject text in texts)
            {
                if (text.name == "InvText" + type)
                {
                    text.GetComponent<TextMeshProUGUI>().text =
                    "" + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Wheat);
                }
            }

            view.RPC("SyncPlus", RpcTarget.All, type);
        }
        if (plus && type == 2)
        {
            ResourceManager.Instance.RemoveResource(ResourceManager.ResourceType.Bread, 1);
            foreach (GameObject text in texts)
            {
                if (text.name == "InvText" + type)
                {
                    text.GetComponent<TextMeshProUGUI>().text =
                    "" + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Bread);
                }
            }

            view.RPC("SyncPlus", RpcTarget.All, type);
        }
        if (plus && type == 3)
        {
            ResourceManager.Instance.RemoveResource(ResourceManager.ResourceType.Iron, 1);
            foreach (GameObject text in texts)
            {
                if (text.name == "InvText" + type)
                {
                    text.GetComponent<TextMeshProUGUI>().text =
                    "" + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Iron);
                }
            }
            view.RPC("SyncPlus", RpcTarget.All, type);
        }
        if (plus && type == 4)
        {
            ResourceManager.Instance.RemoveResource(ResourceManager.ResourceType.Sword, 1);
            foreach (GameObject text in texts)
            {
                if (text.name == "InvText" + type)
                {
                    text.GetComponent<TextMeshProUGUI>().text =
                    "" + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Sword);
                }
            }
            view.RPC("SyncPlus", RpcTarget.All, type);
        }
        if (!plus && type == 0)
        {
            ResourceManager.Instance.AddResource(ResourceManager.ResourceType.Wood, 1);
            foreach (GameObject text in texts)
            {
                if (text.name == "InvText" + type)
                {
                    text.GetComponent<TextMeshProUGUI>().text =
                    "" + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Wood);
                }
            }
            view.RPC("SyncMinus", RpcTarget.All, type);
        }
        if (!plus && type == 1)
        {
            ResourceManager.Instance.AddResource(ResourceManager.ResourceType.Wheat, 1);
            foreach (GameObject text in texts)
            {
                if (text.name == "InvText" + type)
                {
                    text.GetComponent<TextMeshProUGUI>().text =
                    "" + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Wheat);
                }
            }
            view.RPC("SyncMinus", RpcTarget.All, type);
        }
        if (!plus && type == 2)
        {
            ResourceManager.Instance.AddResource(ResourceManager.ResourceType.Bread, 1);
            foreach (GameObject text in texts)
            {
                if (text.name == "InvText" + type)
                {
                    text.GetComponent<TextMeshProUGUI>().text =
                    "" + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Bread);
                }
            }
            view.RPC("SyncMinus", RpcTarget.All, type);
        }
        if (!plus && type == 3)
        {
            ResourceManager.Instance.AddResource(ResourceManager.ResourceType.Iron, 1);
            foreach (GameObject text in texts)
            {
                if (text.name == "InvText" + type)
                {
                    text.GetComponent<TextMeshProUGUI>().text =
                    "" + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Iron);
                }
            }
            view.RPC("SyncMinus", RpcTarget.All, type);
        }
        if (!plus && type == 4)
        {
            ResourceManager.Instance.AddResource(ResourceManager.ResourceType.Sword, 1);
            foreach (GameObject text in texts)
            {
                if (text.name == "InvText" + type)
                {
                    text.GetComponent<TextMeshProUGUI>().text =
                    "" + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Sword);
                }
            }
            view.RPC("SyncMinus", RpcTarget.All, type);
        }




        //int num = 0; //change in value
        /*
        if (plus) 
        {
            num += 1;
        }
        else 
        {
            num -= 1;
        }

        if(type == 0) 
        {
            ResourceManager.Instance.AddResource(ResourceManager.ResourceType.Wood, num);
        }
        if(type == 1)
        {
            ResourceManager.Instance.AddResource(ResourceManager.ResourceType.Wood, num);
        }
        if (type == 2)
        {
            ResourceManager.Instance.AddResource(ResourceManager.ResourceType.Wood, num);
        }
        if (type == 3)
        {
            ResourceManager.Instance.AddResource(ResourceManager.ResourceType.Wood, num);
        }
        if (type == 4)
        {
            ResourceManager.Instance.AddResource(ResourceManager.ResourceType.Wood, num);
        }*/

        //plan: rpc other to add resource, function only here for remove. And reverse

       // view.RPC("Sync", RpcTarget.All, syncNum);
    }

    [PunRPC]
    public void SyncPlus(int type_) 
    {
         resources[type_]++;

        if (inTradingScene) 
        {
            foreach (GameObject text in texts)
            {
                if (text.name == "ShipText" + type_)
                {
                    text.GetComponent<TextMeshProUGUI>().text = "" + resources[type_];
                }
            }
        }

        //syncNum = num;
        //numText.GetComponent<TextMeshProUGUI>().text = num.ToString();
    }


    [PunRPC]
    public void SyncMinus(int type_)
    {
        
            resources[type_]--;

        if (inTradingScene)
        {
            foreach (GameObject text in texts)
            {
                if (text.name == "ShipText" + type_)
                {
                    text.GetComponent<TextMeshProUGUI>().text = "" + resources[type_];
                }
            }
        }
        //syncNum = num;
        //numText.GetComponent<TextMeshProUGUI>().text = num.ToString();
    }
}
