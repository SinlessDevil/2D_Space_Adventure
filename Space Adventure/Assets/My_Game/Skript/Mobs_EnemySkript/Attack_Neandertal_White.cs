using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Attack_Neandertal_White : MonoBehaviour
{
    #region Attack Variabls
    private float timeBtwAttack;
    [SerializeField] private float startTimeBtwAttack;
    public int damage;
    public GameObject character = null;
    public Health player_health = null;
    private PatrolMobs _patrolMobs;
    private Animator _anim;
    #endregion

    private void Start()
    {
        _patrolMobs = GetComponentInParent<PatrolMobs>();
        player_health = character.GetComponent<Health>();
        _anim = GetComponentInParent<Animator>();
    }
    public void Attack()
    {
        if (_patrolMobs._isPlayerNear == true)
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
        if (_patrolMobs._isPlayerNear == true)
        {
            player_health.TakeHit(damage);
        }
        timeBtwAttack = startTimeBtwAttack;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _patrolMobs._isPlayerNear = true;
            Attack();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _patrolMobs._isPlayerNear = false;
        }
    }
}
