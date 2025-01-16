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


    int dutch; //fix setting positions

    private void Awake()
    {
        dutch = Random.Range(0, 2); //0 = swedish
        
    }

    private void Start()
    {
        //menu.SetActive(false);
        //player = GameObject.FindWithTag("Player");

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
                SceneManager.LoadScene("Trade");//menu.SetActive(true);
            }
        }
    }
}
