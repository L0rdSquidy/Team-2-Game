using UnityEngine;

public class FarmingButton : MonoBehaviour
{
    [SerializeField] GameObject Wheeeet;

    public void DestroyTarget() 
    {
        if (Wheeeet != null)
        {
            Destroy(Wheeeet);
        }
    }
}
