using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmithingMinigame : MonoBehaviour
{
    [SerializeField] GameObject dotPrefab; // Prefab for the dots
    [SerializeField] Image swordImage; // Image component of the sword
    //[SerializeField] int dotCount; // Number of dots to spawn
    [SerializeField] float spawnInterval; // Time interval between each dot spawn

    private Texture2D spriteTexture; // Texture of the sword sprite
    private GameObject currentDot;   // Reference to the current dot being shown

    private int buttonPressCount = 0; // Tracks button presses in the smithing minigame
    public int smithingScore = 0;   // Tracks score specific to the smithing minigame
    [SerializeField] int pressesPerPoint = 10; // Number of presses required for one point

    [SerializeField] GameObject instructionsUI;
    [SerializeField] GameObject noIronUI;

    void Start()
    {
        Cursor.visible = true;
        spriteTexture = swordImage.sprite.texture;
        StartCoroutine(SpawnDotsCoroutine()); // Start the coroutine to spawn dots one at a time
    }

    IEnumerator SpawnDotsCoroutine()
    {
        //for (int i = 0; i < dotCount; i++) (not using this atm, might bring back if gameplay is unsatisfactory)

        while (true) // Infinite loop to keep spawning dots
        {
            // Wait for the specified interval before spawning a new dot
            yield return new WaitForSeconds(spawnInterval);

            // If a dot is already spawned, despawn it (not using this atm, might bring back if gameplay is unsatisfactory)
           /* if (currentDot != null)
            {
                Destroy(currentDot);
            }*/

            Vector2 randomPoint;

            // Try finding a valid point within the sword
            do
            {
                randomPoint = GenerateRandomPointInBounds();
            }
            while (!IsPointVisible(randomPoint));

            // Instantiate the new dot and position it
            currentDot = Instantiate(dotPrefab, swordImage.rectTransform);
            currentDot.transform.localPosition = randomPoint; // Position relative to the sword
        }
    }


    Vector2 GenerateRandomPointInBounds()
    {
        // Generate a random point within the RectTransform bounds
        float x = Random.Range(-swordImage.rectTransform.rect.width / 2, swordImage.rectTransform.rect.width / 2);
        float y = Random.Range(-swordImage.rectTransform.rect.height / 2, swordImage.rectTransform.rect.height / 2);
        return new Vector2(x, y);
    }

    bool IsPointVisible(Vector2 localPoint)
    {
        // Convert local UI point to texture space
        Vector2 texturePoint = LocalToTextureCoords(localPoint);
        if (texturePoint.x < 0 || texturePoint.x >= spriteTexture.width || texturePoint.y < 0 || texturePoint.y >= spriteTexture.height)
            return false;

        // Check alpha channel of the pixel at the point
        Color pixel = spriteTexture.GetPixel((int)texturePoint.x, (int)texturePoint.y);
        return pixel.a > 0.1f; // Consider visible if alpha > 0.1
    }

    Vector2 LocalToTextureCoords(Vector2 localPoint)
    {
        // Convert local UI point to sprite texture coordinates
        Rect spriteRect = swordImage.sprite.rect; // Sprite's rect within the texture
        Vector2 pivotOffset = new Vector2(
            (localPoint.x / swordImage.rectTransform.rect.width + 0.5f),
            (localPoint.y / swordImage.rectTransform.rect.height + 0.5f)
        );

        // Map to the sprite texture's pixel space
        return new Vector2(
            pivotOffset.x * spriteRect.width + spriteRect.x,
            pivotOffset.y * spriteRect.height + spriteRect.y
        );
    }

    public void ButtonPressed()
    {
        buttonPressCount++;
        if (buttonPressCount >= pressesPerPoint)
        {
            buttonPressCount = 0; // Reset button press count
            smithingScore++;      // Increment smithing score

            Debug.Log("smithing minigame score: " + smithingScore);

            // [IN FUTURE] Notify game-manager about increase in sword amount (smithingScore), subtract iron, enable/disable UI depending on amount of iron.
        }
    }

    /*public int GetSmithingScore()
    {
        return smithingScore; // Getter if needed for UI (not used atm)
    }*/
}
