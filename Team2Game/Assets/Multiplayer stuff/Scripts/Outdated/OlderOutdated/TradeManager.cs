using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeManager : MonoBehaviour
{
    GameObject giveMenu;
    GameObject takeMenu;

    private void Awake()
    {
        GameObject.Find("Give");
        GameObject.Find("Take");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
