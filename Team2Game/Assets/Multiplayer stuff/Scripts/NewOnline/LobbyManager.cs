using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    //this manages the creation of the room

    int roomSize = 2;

    int roomNum = 0;

    public void JoinRoom() 
    {

        PhotonNetwork.JoinRandomRoom();
        print("trying to join room");
    
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("Failed to find room");
        CreateRoom();
        
    }

    void CreateRoom() 
    {

        print("Creating new room");
        //int rng = Random.Range(0, 1000000000);

        roomNum += 1;

        RoomOptions options = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = roomSize, //(byte)

        };
        
        PhotonNetwork.CreateRoom("Room" + roomNum, options);

    
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        CreateRoom();
    }


}
