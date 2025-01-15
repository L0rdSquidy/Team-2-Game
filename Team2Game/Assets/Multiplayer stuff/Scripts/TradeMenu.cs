using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TradeMenu : MonoBehaviour
{
    GameObject menu;
    TextMeshProUGUI shipTxtComponent;
    TextMeshProUGUI playerTxtComponent;

    //GameObject greyPanel;

    Button sendShipButton;//button to send the selected ship to other player
    Button exitButton;//button to exit trading

    //Resource instance = Resource.Instance;

    bool isOwnShip;//is ship being interacted with the players own ship = true
                  //is the ship the other players ship = false


    int[] playerInventory;
    int[] shipInventory;

    // Start is called before the first frame update
    void Start()
    {
        //greyPanel = GameObject.Find("greyPanel");
       // greyPanel.SetActive(false);

        playerInventory = Resource.Instance.playerInv;
        if (Resource.Instance.isOwnShip) 
        {
            shipInventory = Resource.Instance.ownShipInv;
            menu = transform.Find("Give").gameObject;
            transform.Find("Take").gameObject.SetActive(false);
        }
        else 
        {
            shipInventory = Resource.Instance.otherShipInv;
            menu = transform.Find("Take").gameObject;
            transform.Find("Give").gameObject.SetActive(false);
        }

        shipTxtComponent = menu.transform.Find("shipInvTxt").gameObject.GetComponent<TextMeshProUGUI>();
        playerTxtComponent = menu.transform.Find("playerInvTxt").gameObject.GetComponent<TextMeshProUGUI>();
        
        //sendShipButton = menu.transform.Find("SendShip").GetComponent<Button>();
       //sendShipButton.onClick.AddListener(MenuUpdate);

        exitButton = menu.transform.Find("Exit").GetComponent<Button>();
        exitButton.onClick.AddListener(TradeExit);

        MenuUpdate();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            TradeExit();
        }
    }

    public void TransferItem(int num, bool playerToShip)
    {//playerToShip = true means player is giving to ship,
     //false means they are taking from ship
     //num is for which resource.
     //shipInv is for which inventory (own ship or other players ship)
     // playerInv is for player inv

        if (playerToShip)
        {
            shipInventory[num] += 1;
            playerInventory[num] -= 1;
            MenuUpdate();
        }
        else
        {
            shipInventory[num] -= 1;
            playerInventory[num] += 1;
            MenuUpdate();
        }
    }

    private void MenuUpdate()
    {
        shipTxtComponent.text = "Wood: " + shipInventory[0] + "\n"
        + "Wheat: " + shipInventory[1] + "\n"
        + "Iron: " + shipInventory[2] + "\n"
        + "Bread: " + shipInventory[3] + "\n"
        + "Weapons: " + shipInventory[4] + "\n";

        playerTxtComponent.text = "Wood: " + playerInventory[0] + "\n"
        + "Wheat: " + playerInventory[1] + "\n"
        + "Iron: " + playerInventory[2] + "\n"
        + "Bread: " + playerInventory[3] + "\n"
        + "Weapons: " + playerInventory[4] + "\n";
    }

    /*private void DisableMenu() 
    {
        greyPanel.SetActive(true);
        AdjustInventories(true, true);
    }*/

    private void AdjustInventories(bool adjustPlayerInv, bool adjustShipInv) 
    {
        if (adjustPlayerInv)
        {
            for(int i = 0; i <= playerInventory.Length; i++)//foreach(int i in playerInventory) 
            {
                Resource.Instance.playerInv[i] = playerInventory[i];
            }
        }

        if (adjustShipInv && isOwnShip) 
        {
            for (int i = 0; i <= shipInventory.Length; i++)
            {
                Resource.Instance.ownShipInv[i] = shipInventory[i];
            }

        }
        else if(adjustPlayerInv && !isOwnShip) 
        {
            for (int i = 0; i <= shipInventory.Length; i++)
            {
                Resource.Instance.otherShipInv[i] = shipInventory[i];
            }
        }
    }

    private void TradeExit() 
    {
        AdjustInventories(true, true);
        SceneManager.LoadScene(1);
    }
}
