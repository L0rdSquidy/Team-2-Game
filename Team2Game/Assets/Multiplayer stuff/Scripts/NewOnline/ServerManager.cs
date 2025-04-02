using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class ServerManager : MonoBehaviourPunCallbacks
{
    //this manages connecting to the server (the first step)

    GameObject nameInput;

    public GameObject loadingTxt;

   // Slider carSlider;

    public int carNum = 1; //the car you have chosen

    bool hasPressedConnect;

    // Start is called before the first frame update
    void Start()
    {

        

        (loadingTxt = GameObject.Find("Loading")).SetActive(false);

        //nameInput = GameObject.Find("PlayerNickName");

       // carSlider = GameObject.Find("ChooseCar").GetComponent<Slider>();

        //carSlider.onValueChanged.AddListener(delegate { CarChosen(); });
    }

  /*  void CarChosen() 
    {
        if (!hasPressedConnect) 
        {
            carNum = (int)carSlider.value;
        }

    }*/
    

    public void InitConnection()
    {
        hasPressedConnect = true;

        //PhotonNetwork.NickName = nameInput.GetComponent<TMP_InputField>().text;

        PhotonNetwork.ConnectUsingSettings();
        print("Connecting...");

        GameObject.Find("ConnectButton").SetActive(false);

    }

    public override void OnConnectedToMaster() //när man har connectat så skickas man till ett rum. Efter man kommit in i ett rum sätts vänt-lobbyn på, där man kan se spelarlistan och tiden till start
    {
        //connectButton.SetActive(true);

        print($"Has connected to a server in {PhotonNetwork.CloudRegion}");
        PhotonNetwork.AutomaticallySyncScene = false;
        GetComponent<LobbyManager>().JoinRoom();
        //Destroy(GameObject.Find("DestroyOnceConnected"));
        loadingTxt.SetActive(true);

    }
}
