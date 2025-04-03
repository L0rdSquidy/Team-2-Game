using UnityEngine;

public class OpenWebsite : MonoBehaviour
{
    // Deze methode wordt aangeroepen als je op de knop klikt
    public void OpenLink()
    {
        Application.OpenURL("https://37354.hosts2.ma-cloud.nl/testRank/test.html#contact");
    }
}