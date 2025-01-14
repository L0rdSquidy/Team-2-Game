using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ToShipMenu : MonoBehaviour
{
    [SerializeField] private LayerMask PlayerCheck;
    [SerializeField] private LayerMask NpcCheck;
    [SerializeField] private bool PlayerBool;
    //[SerializeField] private int MinigameInt;

    GameObject menu;
    GameObject shipTxt;
    GameObject playerTxt;
    GameObject player;
    GameObject mouseTracker;
    TextMeshProUGUI shipTxtComponent;
    TextMeshProUGUI playerTxtComponent;

    Resource shipInv;
    Resource playerInv;

    int dutch;

    private void Awake()
    {
        dutch = Random.Range(0, 2); //0 = swedish
        menu = transform.Find("Canvas").gameObject;
        shipTxt = menu.transform.Find("shipInvTxt").gameObject;
        playerTxt = menu.transform.Find("playerInvTxt").gameObject;
        mouseTracker = GameObject.Find("MouseTracker");
    }

    private void Start()
    {
        mouseTracker.GetComponent<createTarget>().MenuObj = menu.transform.Find("Background").gameObject;
        menu.SetActive(false);
        shipInv = GetComponent<Resource>();
        player = GameObject.FindWithTag("Player");

        if (dutch == 1) 
        {
            transform.position = new Vector3(-1, 2.3f, 0);
        }
        else if(dutch == 0) 
        {
            transform.position = new Vector3(2, 2.82f, 0);
        }
    }

    void Update()
    {
        if (Physics2D.CircleCast(transform.position, 1.5f, Vector2.zero, 5, PlayerCheck))
        {
            PlayerBool = true;
        }
        else
        {
            PlayerBool = false;
        }
        if (Physics2D.CircleCast(transform.position, 1.1f, Vector2.zero, 5, NpcCheck))
        {

        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickpos, Vector2.zero, Mathf.Infinity, NpcCheck);
            if (hit.collider != null && PlayerBool)
            {
                Debug.Log("AHHHHHH");
                Debug.Log(hit.collider.gameObject.name);
                MenuSwitch(true);
                shipTxtComponent = shipTxt.GetComponent<TextMeshProUGUI>();
                playerTxtComponent = playerTxt.GetComponent<TextMeshProUGUI>();
                playerInv = player.GetComponent<Resource>();
                MenuUpdate();
            }
        }

        if (menu.activeSelf && !PlayerBool) 
        {
            MenuSwitch(false);
        }
    }

    void MenuSwitch(bool newState) 
    {
        menu.SetActive(newState);
        mouseTracker.GetComponent<createTarget>().tradeMenuEnabled = newState;
    }

    public void TransferItem(int num, bool playerToShip)//playerToShip = true means player is giving to ship, false means they are taking from ship
    {//num is for which resource
        if (playerToShip) 
        {
            shipInv.resources[num] += 1;
            playerInv.resources[num] -= 1;
            MenuUpdate();
        }
        else if (!playerToShip) 
        {
            shipInv.resources[num] -= 1;
            playerInv.resources[num] += 1;
            MenuUpdate();
        }
    }

    private void MenuUpdate() 
    {
        shipTxtComponent.text = "Wood: " + shipInv.resources[0] + "\n"
        + "Wheat: " + shipInv.resources[1] + "\n"
        + "Iron: " + shipInv.resources[2] + "\n"
        + "Bread: " + shipInv.resources[3] + "\n"
        + "Weapons: " + shipInv.resources[4] + "\n";

        playerTxtComponent.text = "Wood: " + playerInv.resources[0] + "\n"
        + "Wheat: " + playerInv.resources[1] + "\n"
        + "Iron: " + playerInv.resources[2] + "\n"
        + "Bread: " + playerInv.resources[3] + "\n"
        + "Weapons: " + playerInv.resources[4] + "\n";
    }
}
