using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MobBehaviour
{
    [SerializeField] private BossMovement movement;
    [SerializeField] private MobHp hp;
    [SerializeField] private BossAttack attack;
    [SerializeField] private BossVision vision;
    [SerializeField] private GameObject player;
    [SerializeField] Animator animator;

    public static Action onMobDied;

    private bool isEnable = true;

    private enum state { Inactive, Attack, Chase };
    private state currentState;

    private void Start()
    {
        currentState = state.Inactive;
    }

    private void Update()
    {
        if (currentState == state.Inactive)
        {
            if (vision.DetectPlayer())
            {
                currentState = state.Chase;
            }
            else
            {
                SetAnimationIdle();
            }
        }

        if (currentState == state.Chase)
        {
            if (vision.DetectPlayer())
            {
                currentState = state.Attack;
            }
            else
            {
                movement.LookOnTarget(player);
            }
        }

        if (currentState == state.Attack)
        {
            if (vision.DecectObstacle())
            {
                movement.LookOnTarget(player);
                attack.Attack(player);
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
                currentState = state.Attack;
            }
            else
            {
                
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
