using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviourPunCallbacks
{
    //this is a code i made for an earlier game, but modified to work with this game
    //and therefore some of the comments are in swedish

    //this code should manage the players joining the same game, or "room".
    //The player who joins first will play Amsterdam and the second Stockholm.


    //Currently joining does not require any password but i would like to add that

    PhotonView view;

    int AmsSceneNum = 5;
    int StockSceneNum = 6;

    //int sceneIndex = 1;

    bool hasJoinedRoom;

    //bool timerActive;

    //float timer;

   // TextMeshProUGUI timerTxt;

   // TextMeshProUGUI playerList; // detta är inte PhotonNetwork.PlayerList, utan en lista som visas i spelet

    int playerAmount;

    //Player[] players;

   // const byte timerEventCode =  1;

    public override void OnEnable()
    {
        base.OnEnable();

        PhotonNetwork.AddCallbackTarget(this);

        
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);

        base.OnDisable();
    }

    public override void OnJoinedRoom()
    {
        /*
        //följande kod tar vilken bil man valde och sparar värdet
        var hash = PhotonNetwork.LocalPlayer.CustomProperties;

        hash.Add("carNum", GetComponent<ServerManager>().carNum);

        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);

       //     print("starting lobby");

        */

        view = GetComponent<PhotonView>();
        
        /*
        if (PhotonNetwork.NickName == "")
        {

            PhotonNetwork.NickName = "Player" + PhotonNetwork.LocalPlayer.ActorNumber;

        }*/


        //playerList = GameObject.Find("PlayerList").GetComponent<TextMeshProUGUI>();

        UpdatePlayerList();

        GetComponent<ServerManager>().loadingTxt.SetActive(false);

            hasJoinedRoom = true;
        
    }
    public override void OnPlayerEnteredRoom(Player other)
    {
       

        UpdatePlayerList();

    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();

        base.OnPlayerLeftRoom(otherPlayer); //osäker på om detta behövs
    }

    private void UpdatePlayerList()
    {
        CheckPlayerAmount();


        /*for(int i = PhotonNetwork.PlayerList.Length - 1; i >= 0; i--)
        {
            if(PhotonNetwork.PlayerList[i] != null) 
            {
                players[i] = PhotonNetwork.PlayerList[i];
            }
        }*/

        /*string playerNames = "";
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if (player.NickName == "") //om man inte skriver in nickname får man ett med sitt nummer i
            {

                player.NickName = "Player" + player.ActorNumber;

            }

           // print("playerList");
            playerNames += BoldMyName(player.NickName) + "\n";
        }
        playerList.text = "Players:\n" + playerNames;
        */

    }

    /*public string BoldMyName(string name)
    {
        if (name == PhotonNetwork.NickName)
        {
            return "<b>" + name + "</b>";
        }
        return name;
    }*/

    public void CheckPlayerAmount() 
    {

        playerAmount = PhotonNetwork.PlayerList.Length;
    
    }
    
    private void Update() //after two players have joined the game starts
    {
        if (PhotonNetwork.IsMasterClient && hasJoinedRoom && playerAmount >= 2) 
        {
            //StartTimer(10);

            view.RPC("StartGame", RpcTarget.All, 30);
        }
        
        /*if (timerActive && playerAmount >= 2) 
        {
            timer -= Time.deltaTime;
            timerTxt.text = "Starting in " + timer.ToString("0.00"); //+ " seconds"
        }
        if (PhotonNetwork.IsMasterClient && timerActive && timer <= 0)
        {
            StartGame();

        }*/
    }


    [PunRPC]
    public void StartGame()
    {
        if(PhotonNetwork.LocalPlayer.ActorNumber <= 1) 
        {
            SceneManager.LoadScene(AmsSceneNum);
        }
        else 
        {
            SceneManager.LoadScene(StockSceneNum);
        }
        //timer = waitTime; //hur lång tid tills start
        //timerTxt = GameObject.Find("TimerTxt").GetComponent<TextMeshProUGUI>();
        //timerActive = true;

        //PhotonNetwork.Instantiate en timer
        
    }

 
    
    
   /* public void StartGame() //körs bara hos master 
    {
        PhotonNetwork.CurrentRoom.IsOpen = false; //gör så att ingen mer kan gå med efter start
        timerActive = false;

        
        //PhotonNetwork.LoadLevel(sceneIndex);
        //RaiseEventOptions eventOptions = 


        //PhotonNetwork.RaiseEvent(timerEvent, );

    }

    */
}
