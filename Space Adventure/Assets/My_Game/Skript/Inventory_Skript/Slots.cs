using UnityEngine;

public class Slots : MonoBehaviour
{
    #region Private variabls
    private Inventory inventory;
    #endregion

    #region Public variabls
    public int i;
    #endregion

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }

    }

    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            child.GetComponent<Item>().CheckActiveGun();
            GameObject.Destroy(child.gameObject);
        }
    }
}
