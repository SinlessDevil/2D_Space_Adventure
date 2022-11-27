using UnityEngine;

public class Boss_Zona : MonoBehaviour
{
    private Bear Bear;
    public GameObject sliderBoss;

    private void Start()
    {
        Bear = FindObjectOfType<Bear>();
        DebugeErrorAccess();
        sliderBoss.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            sliderBoss.SetActive(false);
            Bear._maxRange = 5;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sliderBoss.SetActive(true);
            Bear._maxRange = 10;
        }
    }

    private void DebugeErrorAccess()
    {
        if(Bear == null)
        {
            Debug.LogError("_bossBear не найден!");
        }

        if(sliderBoss == null)
        {
            Debug.LogError("_bossBear не назначен!");
        }
    }
}
