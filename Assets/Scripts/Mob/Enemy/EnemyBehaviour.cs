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

    private enum state { Patrol, Chase, Attack, AvoidObstacles };
    private state currentState;

    private void Start()
    {
        currentState = state.Patrol;
    }

    private void Update()
    {
        if (currentState == state.Patrol)
        {
            movement.Patrol();
            SetAnimationIdle();
            if (vision.DetectPlayer())
            {
                currentState = state.Chase;
            }
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

        if (currentState == state.AvoidObstacles)
        {
            if (vision.DecectObstacle())
            {
                currentState = state.Attack;
            }
            else
            {
                movement.ChaseTarget(player);
                SetAnimationIdle();
            }
        }

        if (currentState == state.Attack)
        {
            if (vision.CheckDistance(player, 10))
            {
                if (vision.DecectObstacle())
                {
                    movement.Stay();
                    movement.LookOnTarget(player);
                    attack.Attack(player);
                    SetAnimationAttack();
                }
                else
                {
                    currentState = state.AvoidObstacles;
                }
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
