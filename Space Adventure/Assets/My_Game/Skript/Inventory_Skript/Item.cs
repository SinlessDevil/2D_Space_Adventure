using UnityEngine;

public class Item : MonoBehaviour
{
    public int IndexId;

    private SwitchGun switchgun;

    private void Start()
    {
        switchgun = FindObjectOfType<SwitchGun>();
    }

    public void CheckActiveGun()
    {
        if(IndexId <= 3)
        {
            switchgun.ResetGun();
        }
    }
}
