using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MobHp
{
    [SerializeField] private float originalHp = 50;
    private float currentHp;
    private DropItem dropItem;

    private void Start()
    {
        currentHp = originalHp;
        dropItem = GetComponent<DropItem>();
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
            dropItem.CheckMob();
            Die();
            return false;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}