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
        if ((isHost && GameObject.Find("NationSlider").GetComponent<Slider>().value == 0)
            || (!isHost && GameObject.Find("NationSlider").GetComponent<Slider>().value != 0))
        {
            dutch = true;
        }
        else if((isHost && GameObject.Find("NationSlider").GetComponent<Slider>().value != 0)
            ||(!isHost && GameObject.Find("NationSlider").GetComponent<Slider>().value == 0))
        {
            dutch = false;
        }
    }
}
