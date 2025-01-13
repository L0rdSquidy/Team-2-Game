using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodeTxt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Code to join game: " + GameObject.Find("NetManager").GetComponent<MultiplayerManage>().joinCode;
    }

    
}
