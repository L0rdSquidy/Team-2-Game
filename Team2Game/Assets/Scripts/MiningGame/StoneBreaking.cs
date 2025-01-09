using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class StoneBreaking : MonoBehaviour
{
   int health;
   
   
   
    private void Start() 
    {
        health = Random.Range(0, 10);
        Debug.Log(health);
    }

   private void OnMouseDown()
    {
        health -= 1;
        Debug.Log(health);
        if (health <0)
        {
            Destroy(gameObject);
        }
   } 

}
