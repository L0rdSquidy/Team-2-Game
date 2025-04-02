using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmithingDot : MonoBehaviour
{
    [SerializeField] float selfDestructTimer = 2f;
    [SerializeField] Button button;

    void Start()
    {
        // Start the self-destruction timer and shrinking process
        StartCoroutine(SelfDestruct());
        StartCoroutine(ShrinkOverTime());

        // Add a listener to the button
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Button not assigned in inspector");
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(selfDestructTimer);
        Destroy(gameObject);
    }

    IEnumerator ShrinkOverTime()
    {
        RectTransform buttonRect = button.GetComponent<RectTransform>();
        if (buttonRect == null)
        {
            Debug.LogError("Button does not have a RectTransform component.");
            yield break;
        }

        Vector3 initialScale = buttonRect.localScale;
        Vector3 targetScale = Vector3.zero; // Shrink to zero

        float elapsedTime = 0f;

        while (elapsedTime < selfDestructTimer)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / selfDestructTimer;
            buttonRect.localScale = Vector3.Lerp(initialScale, targetScale, progress);
            yield return null;
        }

        // Ensure the button is fully shrunk at the end
        buttonRect.localScale = targetScale;
    }

    void OnButtonClick()
    {
        // Notify the SmithingGameManager about the button press
        SmithingMinigame smithingManager = FindObjectOfType<SmithingMinigame>();
        if (smithingManager != null)
        {
            smithingManager.ButtonPressed();
        }
        else
        {
            Debug.LogError("SmithingGameManager not found in the scene.");
        }

        // Destroy the dot after it is clicked
        Destroy(gameObject);
    }
}
