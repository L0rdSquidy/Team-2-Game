using UnityEngine;

public class OpenWebsite : MonoBehaviour
{
    // Deze methode wordt aangeroepen als je op de knop klikt
    public void OpenLink()
    {
        Application.OpenURL("https://chatgpt.com/c/67ece6e7-7818-8002-b4d8-295d3a30d723");
    }
}