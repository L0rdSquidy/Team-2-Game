using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class FarmLand : MonoBehaviour
{
    public List<GameObject> FarmPlaces = new List<GameObject>();
    [SerializeField] private List<GameObject> Wheeeeet;
    [SerializeField] private Animator Sickle;
    private bool fullGrown;
    public GameObject childPrefab; 
    public float pickInterval = 0.5f; 

    [SerializeField] private float timer;

    void Start()
    {
        for(int i = 0, count = transform.childCount; i < count; i++)
        {
            FarmPlaces.Add(transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {
        if (!fullGrown)
        {
            if (timer >= pickInterval)
            {
                timer = 0f;
                AssignChildToRandomObjectWithoutTag("Planted");
            }
            timer += Time.deltaTime;
        }
        
        
    }


    void AssignChildToRandomObjectWithoutTag(string excludedTag)
    {
        List<GameObject> eligibleObjects = FarmPlaces.Where(obj => !obj.CompareTag(excludedTag)).ToList();

        if (eligibleObjects.Count > 0)
        {
            GameObject randomObject = eligibleObjects[Random.Range(0, eligibleObjects.Count)];
            GameObject newChild = Instantiate(childPrefab, randomObject.transform);
            newChild.transform.localPosition = Vector3.zero;
            if (randomObject.tag != "Planted")
            {
                randomObject.tag = "Planted";
            }
        }
        else
        {
            fullGrown = true;
        }
    }

    public void WheeetHarvest()
{
    Sickle.Play("Harvest");
    List<GameObject> HarvestSoils = FarmPlaces.Where(obj => obj.CompareTag("Planted")).ToList();
    List<GameObject> WheetList = new List<GameObject>();
    List<GameObject> ToBeSoilList = new List<GameObject>();
    fullGrown = false;
    
    foreach (var soil in HarvestSoils)
    {
        if (soil.transform.childCount > 0) 
        {
            GameObject child = soil.transform.GetChild(0).gameObject;

            if (child.CompareTag("Grown"))
            {
                ToBeSoilList.Add(soil);
                WheetList.Add(child);
            }
        }
    }

    Debug.Log("Weet harvested: " + WheetList.Count);

    foreach (var wheet in WheetList)
    {
        wheet.SetActive(false);
        Destroy(wheet);
    }
    
    foreach (var soil in ToBeSoilList)
    {
        soil.tag = "Soil";
    }
}


}
