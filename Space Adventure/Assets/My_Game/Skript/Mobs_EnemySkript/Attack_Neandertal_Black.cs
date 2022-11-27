using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Attack_Neandertal_Black : MonoBehaviour
{
    #region Attack Variabls
    [Header("Attack Variabls")]
    private float timeBtwAttack;
    [SerializeField] private float startTimeBtwAttack;
    public int damage;
    private PatrolMobsBlack _patrolMobsBlack;
    private Animator _anim;
    public GameObject character = null;
    public Health player_health = null;
    #endregion

    private void Start()
    {
        _patrolMobsBlack = GetComponentInParent<PatrolMobsBlack>();
        player_health = character.GetComponent<Health>();
        _anim = GetComponentInParent<Animator>();
    }
    public void Attack()
    {
        if (_patrolMobsBlack._isPlayerNear == true)
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
        if (_patrolMobsBlack._isPlayerNear == true)
        {
            player_health.TakeHit(damage);
        }
        timeBtwAttack = startTimeBtwAttack;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _patrolMobsBlack._isPlayerNear = true;
            Attack();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _patrolMobsBlack._isPlayerNear = false;
        }
    }
}
