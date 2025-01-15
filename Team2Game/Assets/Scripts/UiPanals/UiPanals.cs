using UnityEngine;
using UnityEngine.EventSystems;

public class UiPanals : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject Panal;
    void Start()
    {
        if (Panal == null)
        {
            Panal.SetActive(true); 
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Panal != null)
        {
            Panal.SetActive(false); 
        }
    }
}
