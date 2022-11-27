using UnityEngine;
using UnityEngine.UI;

public class AmmoMeneger : MonoBehaviour
{
    #region Public variabls
    public float maxAmmo;
    public float Ammo;
    public Image AmmoBar;
    #endregion
    
    private void Start()
    {
        Ammo = maxAmmo;
    }

    private void Update()
    {
        AmmoBarFill();
    }
   
    public void AmmoBarFill()
    {
        AmmoBar.fillAmount = Ammo / maxAmmo;
    }
}
