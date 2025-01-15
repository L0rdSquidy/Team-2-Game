using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class BreakBrick : MonoBehaviour
{
    private float health;
    private float TotalHealth;
    private float precentageHealth;
    private SpriteRenderer RockAndStone;
    private SpriteRenderer Iron;
    [SerializeField] private List<Sprite> RockSprites;
    [SerializeField] private List<Sprite> IronSprites;
    void Start()
    {
        health = UnityEngine.Random.Range(1f, 10f);
        TotalHealth = health;
        precentageHealth = (health/TotalHealth) * 100;
        RockAndStone = GetComponent<SpriteRenderer>();
        Iron = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {
        if (precentageHealth > 80)
        {
            RockAndStone.sprite = RockSprites[0];
        }
        else if (precentageHealth > 60)
        {
            RockAndStone.sprite = RockSprites[1];
        }
        else if (precentageHealth > 40)
        {
            RockAndStone.sprite = RockSprites[2];
        }
        else if (precentageHealth > 20)
        {
            RockAndStone.sprite = RockSprites[3];
        }
        else
        {
            RockAndStone.sprite = RockSprites[4]; // Adjust if needed
        }
       
        health -= 1f;
        Debug.Log(health);

        precentageHealth = (health/TotalHealth) * 100;
       
        if (health < 0)
        {
            //Destroy(gameObject);
            Iron.sprite = IronSprites[0];
        }
    }
}
