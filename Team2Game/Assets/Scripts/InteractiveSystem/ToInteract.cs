using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class ToInteract : MonoBehaviour
{
    [SerializeField] GameObject selectedPerson;
    [SerializeField] Color normalColor = Color.white;
    [SerializeField] Color SelectedColor;
    [SerializeField] Color targetColor;
    [SerializeField] SpriteRenderer selectedRenderer;
    [SerializeField] float elepsedTime;
    
    void Start()
    {
        targetColor = normalColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedPerson != null)
        {
            selectedRenderer.color = Color.Lerp(selectedRenderer.color, targetColor, 1f * Time.deltaTime);
            elepsedTime += Time.deltaTime;
        }
        if (elepsedTime > 2)
        {
            targetColor = normalColor;
        } 
        if (elepsedTime > 3.5)
        {
            selectedPerson = null;
            elepsedTime = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Person"))
        {
            Debug.Log("hello");
            selectedPerson = other.gameObject;
            selectedRenderer = selectedPerson.GetComponent<SpriteRenderer>();
            targetColor = SelectedColor;
        }
    }
}
