using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoughKnead : MonoBehaviour
{
	[SerializeField] private Slider ProgressBar;
	[SerializeField] private float FailTime;
	[SerializeField] private GameObject BakingBar;
	[SerializeField] private List<Sprite> Windpusher;
	[SerializeField] private Image SpriteDisplay;
	
	private int currentSpriteIndex = 0;
	
	void Start()
	{
		Cursor.visible = true;
		if (Windpusher.Count > 0)
		{
			SpriteDisplay.sprite = Windpusher[currentSpriteIndex];
		}
	}

	void Update()
	{
		
		if (Input.GetMouseButtonDown(0))
		{	
			ProgressBar.value += 1f;
			FailTime = 0.1f;
			currentSpriteIndex = (currentSpriteIndex + 1) % Windpusher.Count;
            SpriteDisplay.sprite = Windpusher[currentSpriteIndex];
		}
		if (FailTime > 0)
		{
			FailTime -= Time.deltaTime;
		} else 
		{
			ProgressBar.value -= 0.01f;
		}
		if (ProgressBar.value == ProgressBar.maxValue)
		{
			BakingBar.SetActive(true);
			ProgressBar.gameObject.SetActive(false);
			Destroy(this);
		}

	}
}
