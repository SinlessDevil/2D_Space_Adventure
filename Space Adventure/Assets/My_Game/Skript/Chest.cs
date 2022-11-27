using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour
{
    [SerializeField] private bool _isActiveOpen;
    private Animator anim;
    [SerializeField] private GameObject chest;
    public GameObject item;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    public void ButtonClickChest()
    {
        if(_isActiveOpen == true)
        {
            anim.SetTrigger("Open_Trigger");
            StartCoroutine(SpawnAndDestory());
        }
        else if(_isActiveOpen == false)
        {
            anim.SetTrigger("Click_Tirgger");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isActiveOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isActiveOpen = false;
    }

    private void DropItem()
    {
        Instantiate(item, transform.position, Quaternion.identity);
    }

    private void Destroy()
    {
        Destroy(chest);
    }


    IEnumerator SpawnAndDestory()
    {
        yield return new WaitForSeconds(1f);
        DropItem();
        yield return new WaitForSeconds(1f);
        Destroy();
    }
}
