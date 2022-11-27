using UnityEngine;
using System;

public class Bear_Movemant : MonoBehaviour, IBearControllable
{
    #region Move Variabls
    [Header("Move Variabls")]
    public float speed;
    public float maxspeed;
    private Vector3 _movedir;
    [SerializeField] private int _xHorizontal;
    [SerializeField] private int _yVertical;   
    #endregion

    #region Access To Scripts
    private Bear bear;
    private Animator _anim;
    private Rigidbody2D _rb;
    #endregion

    private void Start(){
        _anim = GetComponentInParent<Animator>();
        _rb = GetComponentInParent<Rigidbody2D>();
        bear = GetComponentInParent<Bear>();
    }

    public void ComeBack(){
        if (Vector2.Distance(bear._pointHold.position, transform.position) >= bear._maxRange)
        {
            bear._isComeBack = true;
            bear._isMove = true;
            bear._isHold = false;
            speed = maxspeed;
        }
        else if (Vector2.Distance(bear._pointHold.position, transform.position) <= bear._minRange)
        {
            bear._isComeBack = false;
            bear._isMove = false;
            bear._isHold = true;
            speed = 100;
        }
    }

    public void Hold(){
        _anim.SetBool("isMoving", bear._isMove);
        _rb.velocity = Vector3.zero;
    }

    public void Move(){
        _rb.velocity = _movedir * speed * Time.deltaTime;
    }

    public void Movemant(){
        if (bear._isComeBack == false)
        {
            _movedir = bear._player.position - transform.position;
        }
        else
        {
            _movedir = bear._pointHold.position - transform.position;
        }

        float angle = Mathf.Atan2(_movedir.y, _movedir.x) * Mathf.Rad2Deg;
        _movedir.Normalize();

        _xHorizontal = Convert.ToInt32(_movedir.x);
        _yVertical = Convert.ToInt32(_movedir.y);

        _anim.SetBool("isMoving", bear._isMove);
        _anim.SetFloat("X", _xHorizontal);
        _anim.SetFloat("y", _yVertical);

    }

}
