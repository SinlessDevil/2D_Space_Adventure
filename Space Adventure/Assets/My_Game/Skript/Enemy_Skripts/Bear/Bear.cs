using UnityEngine;
using System;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Bear : MonoBehaviour
{
    #region Àctions Variabls
    [Header("Àctions Variabls")]
    public bool _isAttack;
    public bool _isHold;
    public bool _isMove;
    public bool _isComeBack;
    public bool _isPlayerNear;
    #endregion

    #region Other To Scripts
    [Header("Other To Scripts")]
    public float _maxRange;
    public float _minRange;
    public Transform _player;
    public Transform _pointHold;

    public Transform CenterBear;
    #endregion

    #region Interface To Scripts
    [Header("Interface To Scripts")]
    public GameObject bear_is_attack;
    private IBearAttack bearAttack;

    public GameObject bear_is_move;
    private IBearControllable bearControllable;
    #endregion

    private void Start(){
        _player = GameObject.FindWithTag("Player").transform;

        bearAttack = bear_is_attack.GetComponent<IBearAttack>();
        bearControllable = bear_is_move.GetComponent<IBearControllable>();

        DebugeErrorAccess();

        _isPlayerNear = false;
        _isHold = true;
    }

    private void Update(){
        bearControllable.Movemant();
        if (Vector2.Distance(_player.position, CenterBear.transform.position) <= _maxRange)
        {
            _isMove = true;
            _isHold = false;
            if (Vector2.Distance(_player.position, CenterBear.transform.position) <= _minRange)
            {
                bearAttack.Attack();
                _isHold = true;
                _isMove = false;
            }
        }
        else
        {
            bearControllable.ComeBack();
        }
    }

    private void FixedUpdate(){
        if (_isMove == true)
        {
            bearControllable.Move();
        }
        else
        {
            bearControllable.Hold();
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(CenterBear.transform.position, _maxRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(CenterBear.transform.position, _minRange);
    }

    public void AttackBear(){
        bearAttack.OnEnemyAttack();
    }
    public void SpawnTrap(){
        bearAttack.OnEnemyInstantiate();
    }

    #region Error Methods
    private void DebugeErrorAccess()
    {
        if (_player == null)
        {
            Debug.LogError("_player íå íàéäåí!");
        }
        if (_pointHold == null)
        {
            Debug.LogError("_pointHold íå íàéäåí!");
        }

        if(bearAttack == null)
        {
            throw new NullReferenceException("bear_is_attack dons not have IBearAttack interface");
        }
        if (bearControllable == null)
        {
            throw new NullReferenceException("bear_is_move dons not have IBearControllable interface");
        }
    }

    #endregion
}
