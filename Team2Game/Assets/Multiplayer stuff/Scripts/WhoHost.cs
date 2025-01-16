using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhoHost : MonoBehaviour
{
    //this is the local game manager, not shared between players

    public static WhoHost Instance;

    public bool isHost = false; //set true from relay upon host button clicked

    public bool dutch; //true = is in amsterdam, false = is in stockholm
                       

    public bool isOwnShip;//is ship being interacted with the players own ship = true
                          //is the ship the other players ship = false


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void GameStart()
    {
        float value = GameObject.Find("NationSlider").GetComponent<Slider>().value;

        if (isHost && value == 0)
        {
            dutch = true;
            Resource.Instance.isHostDutch = true;
        }
        else if (isHost && value != 0)
        {
            dutch = false;
            Resource.Instance.isHostDutch = false;
        }
        else if (!isHost && !Resource.Instance.isHostDutch)
        {
            dutch = true;
        }
        else if(!isHost && Resource.Instance.isHostDutch)
        {
            dutch = false;
        }
    }

    public void EnterTrade(string boatName) 
    {
        if((boatName == "DutchShip" && dutch) || (boatName == "SwedishShip" && !dutch)) 
        {
            isOwnShip = true;
        }
        else 
        {
            isOwnShip = false;
        }
    }

    public void WonMinigame(int resourceNum, int amount)
    {
        if (dutch)
        {
            Resource.Instance.amsPlayerInv[resourceNum] += amount;
        }
        else 
        {
            Resource.Instance.stockPlayerInv[resourceNum] += amount;
        }
    }
}
