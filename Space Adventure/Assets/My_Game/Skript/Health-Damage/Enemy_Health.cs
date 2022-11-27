using UnityEngine;
[RequireComponent(typeof(Animator))]

public class Enemy_Health : MonoBehaviour
{
    [SerializeField] private float _health_enemy;
    [SerializeField] private float _MaxHealth_enemy;

    [SerializeField] private string _nameEnemy;
    public Animator anim;
    public GameObject item;
    private HealthBarBeheviar Healthbar;
    private HPBarMobs Healthbarmobs;
    
    public GameObject[] componentBoss;

    public GameObject effectBood;
    public Transform centerGameObejct;

    private void Start()
    {
        Healthbarmobs = GetComponentInChildren<HPBarMobs>();
        Healthbar = FindObjectOfType<HealthBarBeheviar>();
        _health_enemy = _MaxHealth_enemy;
        anim = GetComponent<Animator>();
        if (_nameEnemy == "Boss_Bear")
        {
            Healthbar.SetHealth(_health_enemy, _MaxHealth_enemy);
        }
        if (_nameEnemy == "Mobs")
        {
            Healthbarmobs.SetHealth(_health_enemy, _MaxHealth_enemy);
        }
    }

    private void Update()
    {
        Die();
    }

    public void TakeDamage(int damage)
    {
        _health_enemy -= damage;
        if(_nameEnemy == "Barrel")
        {
            anim.SetTrigger("Hit_Trigger");
        }
        if(_nameEnemy == "Boss_Bear")
        {
            GameManager.InstanceObject(centerGameObejct, effectBood);
            Healthbar.SetHealth(_health_enemy, _MaxHealth_enemy);
        }
        if(_nameEnemy == "Mobs")
        {
            GameManager.InstanceObject(centerGameObejct, effectBood);
            Healthbarmobs.SetHealth(_health_enemy, _MaxHealth_enemy);
        }
    }
    private void Die()
    {
        if (_health_enemy <= 0)
        {
            if(_nameEnemy == "Barrel")
            {
                anim.SetTrigger("Dead_Trigger");
            }
            if(_nameEnemy == "Boss_Bear")
            {
                DestroyBossBear();
                DropItem();
            }
            if(_nameEnemy == "Mobs")
            {
                Destroy();
                DropItem();
            }
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    public void DropItem()
    {
        Instantiate(item, transform.position, Quaternion.identity);
    }

    private void DestroyBossBear()
    {
        for (int i = 0; i < componentBoss.Length; i++)
        {
            Destroy(componentBoss[i]);
        }
    }

}
