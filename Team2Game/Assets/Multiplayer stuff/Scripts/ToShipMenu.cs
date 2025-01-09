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
    GameObject text;
    TextMeshProUGUI txtComponent;

    Resource itemScript;

    private void Awake()
    {
        menu = transform.Find("Canvas").gameObject;
        text = menu.transform.Find("Text (TMP)").gameObject;
        menu.SetActive(false);
    }

    private void Start()
    {
        itemScript = GetComponent<Resource>();
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
                menu.SetActive(true);
                txtComponent = text.GetComponent<TextMeshProUGUI>();
            }
        }

        if (menu.activeSelf) 
        {
            txtComponent.text = "Wood: " + itemScript.resources[0];
            if (!PlayerBool) 
            {
                menu.SetActive(false);
            }
            
        }
    }


}
