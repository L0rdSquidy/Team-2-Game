using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMinigame : MonoBehaviour
{
    [SerializeField] private LayerMask PlayerCheck;
    [SerializeField] private LayerMask NpcCheck;
    [SerializeField] private int MinigameInt;
    [SerializeField] private string MiniName;
    [SerializeField] private Color NormalColor = Color.white;
    [SerializeField] private Color SelectedColor;
    [SerializeField] private Color TargetColor;
    [SerializeField] private SaveLocation saveLocation;
    [SerializeField] private bool HasRecourceReq;
    [SerializeField] private int ResourceReq;
    [SerializeField] private GameObject SpeechBubble;
    private int wheet;
    private SpriteRenderer Enderer;
    [SerializeField] ResourceTemp Resource;
    private bool PlayerBool;

    void Start() 
    {
        
        Enderer = GetComponent<SpriteRenderer>();
        TargetColor = NormalColor;
    }

     void Update()
    {
        Enderer.color = Color.Lerp(Enderer.color, TargetColor, 5f * Time.deltaTime);
        if (Physics2D.CircleCast(transform.position, 1.5f, Vector2.zero, 5, PlayerCheck))
        {
            PlayerBool = true;
        } else
        {
            PlayerBool = false;
        }
        if (Physics2D.CircleCast(transform.position, 3f, Vector2.zero, 5, PlayerCheck))
        {
            TargetColor = SelectedColor;
        }else
        {
            TargetColor = NormalColor;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (HasRecourceReq)
            {
                Vector3 clickpos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(clickpos, Vector2.zero, Mathf.Infinity, NpcCheck);
                if (hit.collider != null && PlayerBool && hit.collider.gameObject.name == MiniName)
                {
                    if (ResourceReq <= Resource.Wheeeeeeeeet)
                    {
                        Resource.Wheeeeeeeeet -= ResourceReq;
                        saveLocation.Save();
                        Debug.Log(hit.collider.gameObject.name);
                        SceneManager.LoadScene(MinigameInt);
                    } else
                    {
                        SpeechBubble.SetActive(true);
                    }
                } 
                
            } else
            {
                Vector3 clickpos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(clickpos, Vector2.zero, Mathf.Infinity, NpcCheck);
                if (hit.collider != null && PlayerBool && hit.collider.gameObject.name == MiniName)
                {
                    saveLocation.Save();
                    Debug.Log(hit.collider.gameObject.name);
                    SceneManager.LoadScene(MinigameInt);
                } 
            }
            
        }

    }


    
}
