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
        woodText.text = "Wood: " + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Wood);
        wheatText.text = "Wheat: " + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Wheat);
        breadText.text = "Bread: " + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Bread);
        ironText.text = "Iron: " + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Iron);
        swordText.text = "Sword: " + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceType.Sword);
    }
}