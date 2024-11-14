using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class createTarget : MonoBehaviour
{
    [SerializeField] bool toTarget;
    [SerializeField] GameObject target;
    [SerializeField] Renderer targetrenderer;
    private float timeelepsed = 0;

    void Start() 
    {
        targetrenderer = target.GetComponent<Renderer>();
    }
    void Update()
    {
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
}
