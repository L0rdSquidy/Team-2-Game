using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
	public void sweden()
	{
		SceneManager.LoadScene(7);
	}
	public void nl()
	{
		SceneManager.LoadScene(7);
	}
	
	public void BacktoScene(bool ISnl)
	
	{
		if (ISnl)
		{
			SceneManager.LoadScene(2);
		} else
		{
			SceneManager.LoadScene(1);
		}
	}
}
