using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class createTarget : MonoBehaviour
{
    [SerializeField] bool toTarget;
    [SerializeField] GameObject target;
    [SerializeField] Renderer targetrenderer;
    private float timeelepsed = 0;

    public bool tradeMenuEnabled;

    public GameObject MenuObj;

    void Start() 
    {
        targetrenderer = target.GetComponent<Renderer>();
    }
    void Update()
    {

        if (tradeMenuEnabled && IsPointerOverGameObject(MenuObj))
        {
            return;
        }

        Vector3 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetrenderer.enabled = true;
            toTarget = true;
            mousPos += new Vector3(0, 0, 10);
            target.transform.position = mousPos;
        }
        if (toTarget)
        {
            timeelepsed += Time.deltaTime;
            if (timeelepsed > 1)
            {
                toTarget = false;
                timeelepsed = 0;
                targetrenderer.enabled = false;
            }
        }
        
    }

    //https://discussions.unity.com/t/detect-mouseover-click-for-ui-canvas-object/152611/5
    public static bool IsPointerOverGameObject(GameObject gameObject)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults.Any(x => x.gameObject == gameObject);
    }
}
