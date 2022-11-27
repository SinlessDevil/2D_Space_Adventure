using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    private Animator canAnim;
    public GameObject effectBood;
    public GameObject effectHealth;
    public Transform centerGameObejct;
    private DeadMenu _deadMenu;

    private void Start()
    {
        canAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        _deadMenu = FindObjectOfType<DeadMenu>();
    }

    public void TakeHit(int damage)
    {
        canAnim.SetTrigger("isShake");
        health -= damage;
        GameManager.InstanceObject(centerGameObejct, effectBood);
        if(health <= 0)
        {
            _deadMenu.GameOver();
        }
    }

    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;

        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
