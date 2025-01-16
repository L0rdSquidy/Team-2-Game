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


    private void Start()
    {
        /*bool isDutch = WhoHost.Instance.dutch;

        if (isDutch) 
        {
            transform.position = new Vector3(-1.28f, 2.21f, 0);
            transform.name = "DutchShip";
        }
        else if (!isDutch) 
        {
            transform.position = new Vector3(3.62f, 3.05f, 0);
            transform.name = "SwedishShip";
        }*/

        //menu.SetActive(false);
        //player = GameObject.FindWithTag("Player");
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
                WhoHost.Instance.EnterTrade(name);
                SceneManager.LoadScene("Trade");//menu.SetActive(true);
            }
        }
    }
}
