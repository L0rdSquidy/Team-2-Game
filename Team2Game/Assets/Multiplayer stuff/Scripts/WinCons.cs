using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinCons : MonoBehaviour
{
    TextMeshProUGUI winTxt;
    TextMeshProUGUI timerTxt;

    int[] lastPlayerInv;
    //int[] lastPlayerInv;
    //int[] lastAmsShipInv;
    //int[] lastStockShipInv;

    bool dutch;

    float timer = 360;

    // Start is called before the first frame update
    void Start()
    {
        timerTxt = GameObject.Find("TimerTxt").GetComponent<TextMeshProUGUI>();
        winTxt = GetComponent<TextMeshProUGUI>();
        dutch = WhoHost.Instance.dutch;
        CheckInventory();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0) 
        {
            SceneManager.LoadScene("Defeat");
        
        }
        timerTxt.text = "Time left: " + timer.ToString("0.0");

        CheckInventory();
    }

    void CheckInventory() 
    {
        int[] currentInv;

        if (dutch) 
        {
            currentInv = Resource.Instance.amsPlayerInv;
        }
        else
        {
            currentInv = Resource.Instance.stockPlayerInv;
        }

        if (lastPlayerInv != currentInv)
        {
            WriteInventories(currentInv);
            lastPlayerInv = currentInv;   
        }
    }

    void WriteInventories(int[] inv) 
    {
        if (dutch) 
        {
            winTxt.text = "Wood: " + inv[0] + "/7" + "\n"
            + "Wheat: " + inv[1] + "" + "\n"
            + "Iron: " + inv[2] + "/5" + "\n"
            + "Bread: " + inv[3] + "" + "\n"
            + "Weapons: " + inv[4] + "" + "\n";

        }
        else 
        {
            winTxt.text = "Wood: " + inv[0] + "" + "\n"
            + "Wheat: " + inv[1] + "" + "\n"
            + "Iron: " + inv[2] + "" + "\n"
            + "Bread: " + inv[3] + "/5" + "\n"
            + "Weapons: " + inv[4] + "/5" + "\n";

        }
        

    }

    /*void CheckInventories(int[] lastInv, int[] currentInv)  
    {
        if(lastInv != currentInv) 
        {
            
        }
    }*/
}
