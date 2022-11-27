using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    #region Public variabls
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject inventory;
    [Header("Image")]
    [SerializeField] private Image _chestImg;
    [SerializeField] private Sprite _chestOpen;
    [SerializeField] private Sprite _chestClose;

    #endregion

    #region Private variabls
    private bool inventoryOn;
    #endregion

    private void Start()
    {
        inventoryOn = false;
    }

    public void Chest()
    {
        if (inventoryOn == false)
        {
            inventoryOn = true;
            inventory.SetActive(true);
            _chestImg.sprite = _chestOpen;
        }
        else if (inventoryOn == true)
        {
            inventoryOn = false;
            inventory.SetActive(false);
            _chestImg.sprite = _chestClose;
        }
    }
}
