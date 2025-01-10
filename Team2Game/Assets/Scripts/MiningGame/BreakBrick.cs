using UnityEngine;

public class BreakBrick : MonoBehaviour
{
    private float health;
    void Start()
    {
        health = UnityEngine.Random.Range(1f, 10f);
    }
    private void OnMouseDown()
    {
        health -= 1f;
        Debug.Log(health);
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}
