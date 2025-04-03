using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Baking : MonoBehaviour
{
	[SerializeField] private Scrollbar ChanceBar;
	[SerializeField] private Scrollbar Arrow;
	[SerializeField] private Animator Dough;
	[SerializeField] private Sprite BurntDough;
	[SerializeField] private Image Bread;
	private EndMiniGame endMiniGame;
	private bool ClickedArrow;
	private bool SwitchScene;
	private float WaitTime = 1.5f;
	private float WaitScene = 2;
	private float PercentBaked;

	void Start()
	{
		ChanceBar.value = Random.Range(0f, 0.7f);
		endMiniGame = GetComponent<EndMiniGame>();
	}

	// Update is called once per frame
	void Update()
	{
		WaitTime -= Time.deltaTime;
		if (SwitchScene)
		{
			
				WaitScene -= Time.deltaTime;
				Debug.Log("he");
			if (WaitScene <= 0)
			{
				SceneManager.LoadScene(2);
			}
			
			
		}
		if (WaitTime < 0)
		{
			if (Arrow.value == 1)
			{
				Dough.Play("BreadBake");
			} else
			{
				PercentBaked = (1 - Arrow.value) / (1 - ChanceBar.value);
				Dough.speed = PercentBaked * (1/0.267f);
				Debug.Log(PercentBaked);
				if (PercentBaked > 1.2)
				{
					Debug.Log("hello");	
					Dough.Play("BurntBread");
					Bread.sprite = BurntDough;
				}
			}
			if (Arrow.value != 0 &&  ChanceBar.value > 0 && !ClickedArrow)
			{
				Arrow.value -= 0.01f / 4;
			} 
			if (Arrow.value <= 0 && !ClickedArrow)
			{
				Debug.Log("burnt");
				Dough.Play("BurntBread");
				ClickedArrow = true;
				SwitchScene = true;
			}
			
			if (Input.GetMouseButtonDown(0))
			{
				ClickedArrow = true;
				if (ChanceBar.value >= Arrow.value - 0.1 && ChanceBar.value <= Arrow.value + 0.1)
				{
					Debug.Log("Bread");
					ResourceManager.Instance.AddResource(ResourceManager.ResourceType.Bread, 1);
					SwitchScene = true;
				}else
				{
					Debug.Log("burnt");
					Dough.Play("BurntBread");
					SwitchScene = true;
				}
			}
		
		}
		
		
	}
}
