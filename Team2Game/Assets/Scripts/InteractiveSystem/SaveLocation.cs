using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLocation : MonoBehaviour
{
    [SerializeField] private GameObject location;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Target;

    void Start()
    {
        Load();
    }
    
    public void Save()
    {
        location.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, 0);    
    }
    public void Load()
    {
        Player.transform.position = location.transform.position;
        Target.transform.position = Player.transform.position;
    }
}
