using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PatrolMobsBlack : MonoBehaviour
{
    #region Move Variabls
    [Header("Move Variabls")]
    public float speed;
    [SerializeField] private float _maxRange;
    [SerializeField] private float _minRange;
    [SerializeField] private Vector3 _movedir;
    [SerializeField] private int _xHorizontal;
    [SerializeField] private int _yVertical;
    public Transform _pointHold;
    [SerializeField] private bool _directionPlayer;
    private Attack_Neandertal_Black _attack;
    #endregion

    #region �ctions Variabls
    [Header("�ctions Variabls")]
    public bool _isAttack;
    public bool _ishold;
    public bool _isMove;
    public bool _isMovingRight;
    public bool _isPlayerNear;
    public bool _isComeBack;
    #endregion

    #region Access To Scripts
    private Animator _anim;
    private Rigidbody2D _rb;
    private Transform _player;
    #endregion
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindWithTag("Player").transform;
        DebugeErrorAccess();
        _isPlayerNear = false;
        _attack = GetComponentInChildren<Attack_Neandertal_Black>();
    }
    private void Update()
    {
        Move();
        if (Vector2.Distance(_player.position, transform.position) <= _maxRange)
        {
            _isMove = true;
            _ishold = false;
            speed = 70;
            if (Vector2.Distance(_player.position, transform.position) <= _minRange)
            {
                _attack.Attack();
                _ishold = true;
                _isMove = false;
            }
        }
        else
        {
            ComeBack();
            speed = 50;
        }
    }

    private void FixedUpdate()
    {
        if (_isMove == true)
        {
            Movement();
        }
        else
        {
            Hold();
        }
    }
    #region �ctions Methods

    private void ComeBack()
    {
        if (Vector2.Distance(_pointHold.position, transform.position) >= _maxRange)
        {
            _isComeBack = false;
            _isMove = true;
            _ishold = false;
        }
        else if (Vector2.Distance(_pointHold.position, transform.position) <= _minRange)
        {
            _isComeBack = true;
            _isMove = false;
            _ishold = true;
        }
    }

    private void Move()
    {
        if (_isComeBack == true)
        {
            _movedir = _player.position - transform.position;
        }
        else
        {
            _movedir = _pointHold.position - transform.position;
        }

        float angle = Mathf.Atan2(_movedir.y, _movedir.x) * Mathf.Rad2Deg;
        _movedir.Normalize();

        _xHorizontal = Convert.ToInt32(_movedir.x);
        _yVertical = Convert.ToInt32(_movedir.y);

        _anim.SetBool("isMoving", _isMove);
        _anim.SetFloat("x", _xHorizontal);
        _anim.SetFloat("y", _yVertical);

    }

    private void Movement()
    {
        _rb.velocity = _movedir * speed * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _maxRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _minRange);
    }

    private void Hold()
    {
        _anim.SetBool("isMoving", _isMove);
        _rb.velocity = Vector3.zero;
    }

    public void AttackParent()
    {
        _attack.OnEnemyAttack();
    }
    #endregion



    #region Error Methods
    private void DebugeErrorAccess()
    {
        if (_anim == null)
        {
            Debug.LogError("anim �� ��������!");
        }
        if (_rb == null)
        {
            Debug.LogError("_rb �� ��������!");
        }
        if (_player == null)
        {
            Debug.LogError("_player �� ������!");
        }
        if (_pointHold == null)
        {
            Debug.LogError("_pointHold �� ������!");
        }
    }
    #endregion

}
