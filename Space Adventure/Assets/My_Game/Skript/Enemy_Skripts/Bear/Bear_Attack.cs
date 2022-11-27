using UnityEngine;
using Random = UnityEngine.Random;

public class Bear_Attack : MonoBehaviour, IBearAttack
{
    #region Attack Variabls
    [Header("Attack Variabls")]
    public int damage;
    public string[] nameAttack = new string[2];
    private float timeBtwAttack;
    [SerializeField] private float startTimeBtwAttack;
    #endregion

    #region Access To Scripts
    private Bear bear;
    private Animator _anim;
    public GameObject bossTrap;
    public GameObject character = null;
    public Health player_health = null;
    private Animator canAnim;
    #endregion

    private void Start(){
        canAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        _anim = GetComponentInParent<Animator>();
        player_health = character.GetComponent<Health>();
        bear = GetComponentInParent<Bear>();
    }

    public void Attack(){
        if (bear._isPlayerNear == true)
        {
            if (timeBtwAttack <= 0)
            {
                RandomAttack();
                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }

    public void OnEnemyAttack(){
        if (bear._isPlayerNear == true)
        {
            player_health.TakeHit(damage);
        }
    }

    public void OnEnemyInstantiate(){
        canAnim.SetTrigger("isShake");
        Instantiate(bossTrap, transform.position, Quaternion.identity);
    }

    public void RandomAttack(){
        int random = Random.Range(1, 4);
        if (random == 1)
        {
            damage = 5;
            _anim.SetTrigger(nameAttack[0]);
        }
        if (random == 2)
        {
            damage = 7;
            _anim.SetTrigger(nameAttack[1]);
        }
        if (random == 3)
        {
            damage = 10;
            _anim.SetTrigger(nameAttack[2]);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player"))
        {
            bear._isPlayerNear = true;
            Attack();
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.CompareTag("Player"))
        {
            bear._isPlayerNear = false;
        }
    }
}
