using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    #region Private variabls
    private Inventory inventory;
    #endregion
    #region Public variabls
    public GameObject slotButton;
    public Transform center_object;
    public GameObject effect_pickup;
    #endregion


    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(slotButton, inventory.slots[i].transform);
                    GameManager.InstanceObject(center_object, effect_pickup);
                    Destroy(gameObject);
                    break;
                }
            }

        }
    }
}
