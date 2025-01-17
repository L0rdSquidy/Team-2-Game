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

    bool isDutch; //false = swedish

    List<int> playerInventory;
    List<int> shipInventory;

    // Start is called before the first frame update
    void Start()
    {
        //greyPanel = GameObject.Find("greyPanel");
        // greyPanl.SetActive(false);

        isOwnShip = WhoHost.Instance.isOwnShip;
        isDutch = WhoHost.Instance.dutch;


        //if ship and player are from same place: give to ship
        //if ship and player are from different places: take from ship

        if (isOwnShip && isDutch)//ship is dutch, player is dutch
        {
            menu = GameObject.Find("OwnShip");
            GameObject.Find("OtherShip").gameObject.SetActive(false);
            
            for(int i = 0; i < Resource.Instance.amsShipInv.Count; i++) 
            {
                shipInventory[i] = Resource.Instance.amsShipInv[i];
                playerInventory[i] = Resource.Instance.amsPlayerInv[i];
            }
            
        }
        else if (isOwnShip && !isDutch)//ship is swedish, player is swedish
        {
            menu = GameObject.Find("OwnShip");
            GameObject.Find("OtherShip").gameObject.SetActive(false);
            for (int i = 0; i < Resource.Instance.amsShipInv.Count; i++)
            {
                shipInventory[i] = Resource.Instance.stockShipInv[i];
                playerInventory[i] = Resource.Instance.stockPlayerInv[i];
            }
            //shipInventory = Resource.Instance.stockShipInv.Value;
            //playerInventory = Resource.Instance.stockPlayerInv.Value;
        }
        else if(!isOwnShip && isDutch)//ship is swedish, player is dutch
        {
            menu = GameObject.Find("OtherShip");
            GameObject.Find("OwnShip").gameObject.SetActive(false);
            for (int i = 0; i < Resource.Instance.amsShipInv.Count; i++)
            {
                shipInventory[i] = Resource.Instance.stockShipInv[i];
                playerInventory[i] = Resource.Instance.amsPlayerInv[i];
            }
            //shipInventory = Resource.Instance.stockShipInv.Value;
            //playerInventory = Resource.Instance.amsPlayerInv.Value;
        }
        else if(!isOwnShip && !isDutch)//ship is dutch, player is swedish
        {
            menu = GameObject.Find("OtherShip");
            GameObject.Find("OwnShip").gameObject.SetActive(false);
            for (int i = 0; i < Resource.Instance.amsShipInv.Count; i++)
            {
                shipInventory[i] = Resource.Instance.amsShipInv[i];
                playerInventory[i] = Resource.Instance.stockPlayerInv[i];
            }
            //shipInventory = Resource.Instance.amsShipInv.Value;
           // playerInventory = Resource.Instance.stockPlayerInv.Value;
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

        Debug.Log("transfer");
        if (playerToShip && playerInventory[num] > 0)
        {
            shipInventory[num] += 1;
            playerInventory[num] -= 1;
            MenuUpdate();
        }
        else if(!playerToShip && shipInventory[num] > 0)
        {
            shipInventory[num] -= 1;
            playerInventory[num] += 1;
            MenuUpdate();
        }
        Debug.Log("done");
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
        Debug.Log("menu");
    }

    /*private void DisableMenu() 
    {
        greyPanel.SetActive(true);
        AdjustInventories(true, true);
    }*/

    private void AdjustInventories() //bool adjustPlayerInv, bool adjustShipInv
    {

        if (isOwnShip && isDutch)//ship is dutch, player is dutch
        {
            for (int i = 0; i <= Resource.Instance.amsPlayerInv.Count - 1; i++)//foreach(int i in playerInventory) 
            {
                Resource.Instance.amsShipInv[i] = shipInventory[i];
                Resource.Instance.amsPlayerInv[i] = playerInventory[i];
            }
        }
        else if (isOwnShip && !isDutch)//ship is swedish, player is swedish
        {
            for (int i = 0; i <= Resource.Instance.amsPlayerInv.Count- 1; i++)//foreach(int i in playerInventory) 
            {
                Resource.Instance.stockShipInv[i] = shipInventory[i];
                Resource.Instance.stockPlayerInv[i] = playerInventory[i];
            }
        }
        else if (!isOwnShip && isDutch)//ship is swedish, player is dutch
        {
            for (int i = 0; i <= Resource.Instance.amsPlayerInv.Count- 1; i++)//foreach(int i in playerInventory) 
            {
                Resource.Instance.stockShipInv[i] = shipInventory[i];
                Resource.Instance.amsPlayerInv[i] = playerInventory[i];
            }
        }
        else if (!isOwnShip && !isDutch)//ship is dutch, player is swedish
        {
            for (int i = 0; i <= Resource.Instance.amsPlayerInv.Count - 1; i++)//foreach(int i in playerInventory) 
            {
                Resource.Instance.amsShipInv[i] = shipInventory[i];
                Resource.Instance.stockPlayerInv[i] = playerInventory[i];
            }
        }
    }

    private void TradeExit() 
    {
        AdjustInventories();
        Resource.Instance.CallSync();
        SceneManager.LoadScene(1);
    }
}
