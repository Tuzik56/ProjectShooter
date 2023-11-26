using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MobBehaviour
{
    [SerializeField] private EnemyMovement movement;
    [SerializeField] private MobHp hp;
    [SerializeField] private EnemyAttack attack;
    [SerializeField] private EnemyVision vision;
    [SerializeField] Animator animator;
    [SerializeField] private GameObject player;

    private bool isEnable = true;

    private enum state { Patrol, Chase, Attack };
    private state currentState = state.Patrol;

    private void Start()
    {

    }

    private void Update()
    {
        if (currentState == state.Patrol)
        {
            movement.Patrol();
            SetAnimationIdle();
        }

        if (currentState == state.Chase)
        {
            if (!vision.CheckDistance(player, 10))
            {
                movement.ChaseTarget(player);
                SetAnimationIdle();
            }
            else
            {
                currentState = state.Attack;
            }
        }

        if (currentState == state.Attack)
        {
            if (vision.CheckDistance(player, 10))
            {
                Attack();
                SetAnimationAttack();
            }
            else
            {
                currentState = state.Chase;
            }
        }
    }

    public override void SetDamage(float damage)
    {
        if (isEnable)
        {
            if (hp.SetDamage(damage))
            {
                currentState = state.Chase;
            }
            else
            {
                Debug.Log("Доигралися");
            }
        }
    }

    private void Attack()
    {
        movement.Stay();
        movement.LookOnTarget(player);
        attack.Attack(player);
    }

    private void SetAnimationIdle()
    {
        animator.SetBool("idle", true);
        animator.SetBool("attack", false);
    }

    private void SetAnimationAttack()
    {
        animator.SetBool("attack", true);
        animator.SetBool("idle", false);
    }
}
