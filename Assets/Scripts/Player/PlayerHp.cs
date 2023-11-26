using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MobHp
{
    [SerializeField] private float originalHp = 500;
    private float currentHp;

    private void Start()
    {
        currentHp = originalHp;
    }

    public override bool SetDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp > 0)
        {
            return true;
        }
        else
        {
            Die();
            return false;
        }
    }

    private void Die()
    {
        Debug.Log("недолго песенка играла");
    }
}
