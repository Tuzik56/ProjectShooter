using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MobBehaviour
{
    [SerializeField] private EnemyMovement movement;
    [SerializeField] private MobHp hp;

    private bool isLive = true;

    private void Start()
    {
        
    }

    private void Update()
    {
        movement.Patrol();
    }

    public override void SetDamage(float damage)
    {
        if (isLive)
        {
            if (hp.SetDamage(damage))
            {

            }
            else
            {
                Debug.Log("Доигралися");
            }
        }
    }
}
