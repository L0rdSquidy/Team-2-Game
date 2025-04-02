using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMiniGame : MonoBehaviour
{
    [SerializeField] int minigameInt;
    public void Return()
    {
        SceneManager.LoadScene(minigameInt);
    }
}
