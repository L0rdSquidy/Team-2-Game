using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    //obsolete

    GameObject mySpawnPoint;

    string spawnName; //name of the thing to spawn

    // Start is called before the first frame update
    void Start()
    {
        spawnName = "Car" + PhotonNetwork.LocalPlayer.CustomProperties["carNum"];

        

        mySpawnPoint = GameObject.Find("Start" + PhotonNetwork.LocalPlayer.ActorNumber);

        Invoke("CreatePlayer", 0.5f);
    }

    void CreatePlayer() 
    {

        //load asset at path

        PhotonNetwork.Instantiate(spawnName, mySpawnPoint.transform.position, mySpawnPoint.transform.rotation); //saken som instantiate-as måste ha en photon view och vara i resources
    
    }

}
