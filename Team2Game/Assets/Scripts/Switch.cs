using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    public void sweden()
    {
        SceneManager.LoadScene(0);
    }
    public void nl()
    {
        SceneManager.LoadScene(1);
    }
}
