using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechRemoval : MonoBehaviour
{
    [SerializeField]private List<Color> colors;
    private int chosenColor;
    private float timer;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        chosenColor = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        image.color = colors[chosenColor];
        if (timer > 1.5f)
        {
            timer = 0;
            chosenColor = 0;
            gameObject.SetActive(false);
        }
    }
}
