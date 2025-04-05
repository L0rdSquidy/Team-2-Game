using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{ 
	public Button button;
	private GameObject SceneObject;
	private SceneHistory sceneHistory;

	void Start()
	{	
		SceneObject = GameObject.FindGameObjectWithTag("SceneHistory");
		sceneHistory = SceneObject.GetComponent<SceneHistory>();
		if (button!=null)
		{
			button.onClick.AddListener(sceneHistory.PreviousScene);
		}

	}


	public void TradingSwitch()
	
	{
		sceneHistory.LoadScene("Trading");
	}
}
