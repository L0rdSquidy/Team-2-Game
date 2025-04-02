using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodeTxt : MonoBehaviour
{

    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        text.text = "Code to join game: " + GameObject.Find("NetManager").GetComponent<MultiplayerManage>().joinCode;
    }

   /* void OtherPlayerJoined() 
    {
        text.text = " ";
    }*/
}
