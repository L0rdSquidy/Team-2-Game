using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceDisplay : MonoBehaviour
{
    public TMP_Text woodText;
    public TMP_Text wheatText;
    public TMP_Text breadText;
    public TMP_Text ironText;
    public TMP_Text swordText;

    void Update()
    {
        // Update de UI-elementen met de actuele waarden
        woodText.text = "" + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Wood);
        wheatText.text = "" + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Wheat);
        breadText.text = "" + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Bread);
        ironText.text = "" + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Iron);
        swordText.text = "" + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Sword);
    }
}