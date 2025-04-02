using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    // Enum met de vijf vaste resource types
    public enum ResourceType { Wood, Wheat, Bread, Iron, Sword }

    // Dictionary om de hoeveelheid per resource op te slaan
    private Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();

    private void Awake()
    {
        // Singleton instellen en zorgen dat dit object niet vernietigd wordt bij scene-loads
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeResources();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Initialiseer alle resources met een startwaarde (bijv. 0)
    private void InitializeResources()
    {
        foreach (ResourceType type in System.Enum.GetValues(typeof(ResourceType)))
        {
            resources[type] = 3;
        }
    }

    // Voeg een bepaalde hoeveelheid toe aan een resource
    public void AddResource(ResourceType type, int amount)
    {
        if (resources.ContainsKey(type))
        {
            resources[type] += amount;
        }
        else
        {
            resources[type] = amount;
        }
        Debug.Log($"Added {amount} of {type}. Total now: {resources[type]}");
    }

    // Probeer een hoeveelheid van een resource te verwijderen. Retourneert true als dit gelukt is.
    public bool RemoveResource(ResourceType type, int amount)
    {
        if (resources.ContainsKey(type) && resources[type] >= amount)
        {
            resources[type] -= amount;
            Debug.Log($"Removed {amount} of {type}. Total now: {resources[type]}");
            return true;
        }
        else
        {
            Debug.LogWarning($"Not enough {type} to remove. Current: {GetResourceAmount(type)}");
            return false;
        }
    }

    // Haal de huidige hoeveelheid op van een resource
    public int GetResourceAmount(ResourceType type)
    {
        return resources.ContainsKey(type) ? resources[type] : 0;
    }
}
