using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoReload : MonoBehaviour
{
    private AmmoMeneger ammoMeneger;
    [SerializeField] private int _amountAmmo;

    public Transform center_object;
    public GameObject effect_pickupAmmo;

    private void Start()
    {
        ammoMeneger = FindObjectOfType<AmmoMeneger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ammoMeneger.Ammo += _amountAmmo;
            if (ammoMeneger.Ammo > ammoMeneger.maxAmmo)
            {
                ammoMeneger.Ammo = ammoMeneger.maxAmmo;
            }
            GameManager.InstanceObject(center_object, effect_pickupAmmo);
            Destroy(this.gameObject);
        }
    }

}
