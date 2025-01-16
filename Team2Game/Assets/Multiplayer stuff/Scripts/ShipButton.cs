using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipButton : MonoBehaviour
{
    
    //GameObject ship;
    TradeMenu script;

    bool giveItem; //or send item (false)
    int itemNum;
    string buttonName;

    private void Awake()
    {   buttonName = transform.name;
        //ship = transform.parent.parent.gameObject;
        int.TryParse(buttonName.Substring(4), out itemNum);
        string nameNoNum = buttonName.Remove(buttonName.Length - 1);
        if (nameNoNum == "Give")
        {
            giveItem = true;   
        }
        else if(nameNoNum == "Take") 
        {
            giveItem = false;
        }
    }

    private void Start()
    {
        script = GameObject.Find("TradeManager").GetComponent<TradeMenu>();
    }

    public void ButtonPressed() 
    {
        //script = ship.GetComponent<ToShipMenu>();
        //script.TransferItem(itemNum, giveItem);
        Debug.Log("pressed");
        script.TransferItem(itemNum, giveItem);
    }
}
