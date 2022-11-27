using UnityEngine;
using System;
using Random = UnityEngine.Random;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Boss_Bear : MonoBehaviour
{
    #region Move Variabls
    [Header("Move Variabls")]
    public float speed;
    public float _maxRange;
    public float _minRange;
    private Vector3 _movedir;
    [SerializeField] private int _xHorizontal;
    [SerializeField] private int _yVertical;
    public Transform _pointHold;
    #endregion

    #region Attack Variabls
    [Header("Attack Variabls")]
    public int damage;
    public string[] nameAttack = new string[2];
    public GameObject bossTrap;
    private float timeBtwAttack;
    [SerializeField] private float startTimeBtwAttack;
    #endregion

    #region Аctions Variabls
    [Header("Аctions Variabls")]
    public bool _isAttack;
    public bool _isHold;
    public bool _isMove;
    public bool _isComeBack;
    public bool _isPlayerNear;
    #endregion

    #region Access To Scripts
    [Header("Access To Scripts")]
    public GameObject character = null;
    public Health player_health = null;
    private Animator _anim;
    private Rigidbody2D _rb;
    private Transform _player;
    #endregion

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindWithTag("Player").transform;
        player_health = character.GetComponent<Health>();
        DebugeErrorAccess();
        _isPlayerNear = false;
    }
    private void Update()
    {
        Move();
        if (Vector2.Distance(_player.position, transform.position) <= _maxRange)
        {
            _isMove = true;
            _isHold = false;
            if(Vector2.Distance(_player.position, transform.position) <= _minRange)
            {
                Attack();
                _isHold = true;
                _isMove = false;
            }
        }
        else
        {
            ComeBack();
        }
    }

    private void FixedUpdate()
    {
        if(_isMove == true)
        {
            Movement();
        }
        else
        {
            Hold();
        }
    }

    #region Аctions Methods

    #region Movemant Methods
    private void ComeBack()
    {
        if (Vector2.Distance(_pointHold.position, transform.position) >= _maxRange)
        {
            _isComeBack = true;
            _isMove = true;
            _isHold = false;
            speed = 200;
        }
        else if (Vector2.Distance(_pointHold.position, transform.position) <= _minRange)
        {
            _isComeBack = false;
            _isMove = false;
            _isHold = true;
            speed = 100;
        }
    }
    private void Move()
    {
        if(_isComeBack == false){
            _movedir = _player.position - transform.position;
        }
        else{
            _movedir = _pointHold.position - transform.position;
        }

        float angle = Mathf.Atan2(_movedir.y, _movedir.x) * Mathf.Rad2Deg;
        _movedir.Normalize();

        _xHorizontal = Convert.ToInt32(_movedir.x);
        _yVertical = Convert.ToInt32(_movedir.y);

        _anim.SetBool("isMoving", _isMove);
        _anim.SetFloat("X", _xHorizontal);
        _anim.SetFloat("y", _yVertical);

    }
    private void Movement()
    {
        _rb.velocity = _movedir * speed * Time.deltaTime;
    }

    private void Hold()
    {
        _anim.SetBool("isMoving", _isMove);
        _rb.velocity = Vector3.zero;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _maxRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _minRange);
    }

    #endregion

    #region Attack Methods
    private void Attack()
    {
        if (_isPlayerNear == true)
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
    private void RandomAttack()
    {
        int random = Random.Range(1, 4);
        Debug.Log(random);
        if(random == 1){
            damage = 5;
            _anim.SetTrigger(nameAttack[0]);
        }
        if(random == 2){
            damage = 7;
            _anim.SetTrigger(nameAttack[1]);
        }
        if(random == 3){
            damage = 10;
            _anim.SetTrigger(nameAttack[2]);
        } 
    }
    public void OnEnemyAttack()
    {
        if (_isPlayerNear == true)
        {
            player_health.TakeHit(damage);
        }
    }
    public void OnEnemyInstantiate()
    {
        Instantiate(bossTrap, transform.position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isPlayerNear = true;
            Attack();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isPlayerNear = false;
        }
    }

    #endregion

    #endregion

    #region Error Methods
    private void DebugeErrorAccess()
    {
        if(_anim == null){
            Debug.LogError("anim не назначен!");
        }  
        if(_rb == null){
            Debug.LogError("_rb не назначен!");
        }
        if(_player == null){
            Debug.LogError("_player не найден!");
        }
        if(_pointHold == null){
            Debug.LogError("_pointHold не найден!");
        }
        if(player_health == null)
        {
            Debug.LogError("player_health назначен!");
        }
        if (character == null)
        {
            Debug.LogError("character назначен!");
        }
        if(bossTrap == null)
        {
            Debug.LogError("bossTrap назначен!");
        }
    }

    #endregion
}
