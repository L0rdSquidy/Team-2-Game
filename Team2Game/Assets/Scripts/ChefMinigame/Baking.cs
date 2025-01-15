using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Baking : MonoBehaviour
{
    [SerializeField] private Scrollbar ChanceBar;
    [SerializeField] private Scrollbar Arrow;
    private EndMiniGame endMiniGame;
    private bool ClickedArrow;
    private float WaitTime = 1.5f;

    void Start()
    {
        ChanceBar.value = Random.Range(0f, 1f);
        endMiniGame = GetComponent<EndMiniGame>();
    }

    // Update is called once per frame
    void Update()
    {
        WaitTime -= Time.deltaTime;
        if (WaitTime < 0)
        {
            if (Arrow.value != 0 &&  ChanceBar.value > 0 && !ClickedArrow)
        {
            Arrow.value -= 0.01f / 2;
        } 
        if (Arrow.value <= 0 && !ClickedArrow)
        {
            Debug.Log("burnt");
            ClickedArrow = true;
            SceneManager.LoadScene(1);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            ClickedArrow = true;
            if (ChanceBar.value >= Arrow.value - 0.1 && ChanceBar.value <= Arrow.value + 0.1)
            {
                Debug.Log("Bread");
                SceneManager.LoadScene(1);
            }else
            {
                Debug.Log("burnt");
                SceneManager.LoadScene(1);
            }
        }
        
        }
        
        
    }
}
