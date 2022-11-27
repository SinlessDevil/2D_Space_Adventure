using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Attack_Neandertal_Pink : MonoBehaviour
{

    #region Attack Variabls
    [Header("Attack Variabls")]
    private float timeBtwAttack;
    [SerializeField] private float startTimeBtwAttack;
    public int damage;
    public GameObject character = null;
    public Health player_health = null;
    private PatrolMobsPink _patrolMobsPink;
    private Animator _anim;
    #endregion

    void Start()
    {
        _patrolMobsPink = GetComponentInParent<PatrolMobsPink>();
        player_health = character.GetComponent<Health>();
        _anim = GetComponentInParent<Animator>();
    }

    public void Attack()
    {
        if (_patrolMobsPink._isPlayerNear == true)
        {
            if (timeBtwAttack <= 0)
            {
                _anim.SetTrigger("isAttack");
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }

    public void OnEnemyAttack()
    {
        if (_patrolMobsPink._isPlayerNear == true)
        {
            player_health.TakeHit(damage);
        }
        timeBtwAttack = startTimeBtwAttack;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _patrolMobsPink._isPlayerNear = true;
            Attack();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _patrolMobsPink._isPlayerNear = false;
        }
    }
}
