using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPointerController : MonoBehaviour
{
    [SerializeField] Transform pointA; // Reference to the starting point
    [SerializeField] Transform pointB; // Reference to the ending point
    [SerializeField] RectTransform targetZone; // Reference to the target zone RectTransform
    [SerializeField] float moveSpeed;

    private float shakeAmount = 10f; // Distance of shake movement
    private int shakeCount = 4; // Number of shake movements
    private float shakeSpeed = 0.05f; // Speed of each shake movement

    private RectTransform pointerTransform;
    private Vector3 targetPosition;
    private bool isStopped = false;

    void Start()
    {
        pointerTransform = GetComponent<RectTransform>();

        if (Random.value > 0.5f)
        {
            targetPosition = pointB.position;
        }
        else
        {
            targetPosition = pointA.position;
        }
    }

    void Update()
    {
        if (!isStopped)
        {
            // Move the pointer towards the target position
            pointerTransform.position = Vector3.MoveTowards(pointerTransform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Change direction if the pointer reaches one of the points
            if (Vector3.Distance(pointerTransform.position, pointA.position) < 0.1f)
            {
                targetPosition = pointB.position;
            }
            else if (Vector3.Distance(pointerTransform.position, pointB.position) < 0.1f)
            {
                targetPosition = pointA.position;
            }
        }

        // Check for input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(HandleSpacePress());
        }
    }

    IEnumerator HandleSpacePress()
    {
        isStopped = true;
        CheckSuccess();

        bool isInsideTargetZone = RectTransformUtility.RectangleContainsScreenPoint(targetZone, pointerTransform.position, null);

        if (!isInsideTargetZone)
        {
            // Perform the shake animation if the pointer is outside the target zone
            yield return StartCoroutine(ShakePointer());
        }

        yield return new WaitForSeconds(1f); // Wait for 1 second

        if (Random.value > 0.5f)
        {
            gameObject.transform.position = pointB.position;
        }
        else
        {
            gameObject.transform.position = pointA.position;
        }

        // Move the pointer to a random position between pointA and pointB
        //Vector3 randomPosition = Vector3.Lerp(pointA.position, pointB.position, Random.value);
        //pointerTransform.position = randomPosition;

        isStopped = false; // Resume movement
    }

    IEnumerator ShakePointer()
    {
        Vector3 originalPosition = pointerTransform.position;

        for (int i = 0; i < shakeCount; i++)
        {
            // Move left
            pointerTransform.position = originalPosition + new Vector3(-shakeAmount, 0, 0);
            yield return new WaitForSeconds(shakeSpeed);

            // Move right
            pointerTransform.position = originalPosition + new Vector3(shakeAmount, 0, 0);
            yield return new WaitForSeconds(shakeSpeed);
        }

        // Return to original position
        pointerTransform.position = originalPosition;
    }

    void CheckSuccess()
    {
        // Check if the pointer is within the target zone
        if (RectTransformUtility.RectangleContainsScreenPoint(targetZone, pointerTransform.position, null))
        {
            Debug.Log("success");
        }
        else
        {
            Debug.Log("fail");
        }
    }
}

//Arvid