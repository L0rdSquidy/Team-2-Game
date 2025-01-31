using System.Collections.Generic;
using UnityEngine;

public class BreakBrick : MonoBehaviour
{
    private float health;
    private float totalHealth;
    private float percentageHealth;
    private SpriteRenderer rockAndStone;
    private SpriteRenderer iron;
    [SerializeField] private List<Sprite> rockSprites;
    [SerializeField] private List<Sprite> ironSprites;

    private enum RockState
    {
        FullHealth,
        HighHealth,
        MediumHealth,
        LowHealth,
        CriticalHealth
    }

    private RockState currentRockState;

    void Start()
    {
        health = UnityEngine.Random.Range(1f, 10f);
        totalHealth = health;
        percentageHealth = (health / totalHealth) * 100;
        rockAndStone = GetComponent<SpriteRenderer>();
        iron = GetComponent<SpriteRenderer>();

        UpdateRockSprite();
    }

    private void OnMouseDown()
    {
        health -= 1f;
        Debug.Log(health);

        percentageHealth = (health / totalHealth) * 100;

        if (health < 0)
        {
            //Destroy(gameObject);
            iron.sprite = ironSprites[0];
        }
        else
        {
            UpdateRockSprite();
        }
    }

    private void UpdateRockSprite()
    {
        if (percentageHealth > 80)
        {
            currentRockState = RockState.FullHealth;
        }
        else if (percentageHealth > 60)
        {
            currentRockState = RockState.HighHealth;
        }
        else if (percentageHealth > 40)
        {
            currentRockState = RockState.MediumHealth;
        }
        else if (percentageHealth > 20)
        {
            currentRockState = RockState.LowHealth;
        }
        else
        {
            currentRockState = RockState.CriticalHealth;
        }

        switch (currentRockState)
        {
            case RockState.FullHealth:
                rockAndStone.sprite = rockSprites[0];
                break;
            case RockState.HighHealth:
                rockAndStone.sprite = rockSprites[1];
                break;
            case RockState.MediumHealth:
                rockAndStone.sprite = rockSprites[2];
                break;
            case RockState.LowHealth:
                rockAndStone.sprite = rockSprites[3];
                break;
            case RockState.CriticalHealth:
                rockAndStone.sprite = rockSprites[4]; // Adjust if needed
                break;
            default:
                rockAndStone.sprite = rockSprites[0];
                break;
        }
    }
}
