using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheeeet : MonoBehaviour
{
    [SerializeField] private List<Sprite> GrowSprites;
    private SpriteRenderer WheeetRenderer;
    private float TimeElepsed;
    private int Growth = 0;
    private void Start()
    {
        WheeetRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        TimeElepsed += Time.deltaTime;

        if (TimeElepsed > 5 && Growth != 2)
        {
            Growth += 1;
            WheeetRenderer.sprite = GrowSprites[Growth];    
            if (Growth == 2)
            {
                this.gameObject.tag = "Grown";
            }
        }
    }
}
