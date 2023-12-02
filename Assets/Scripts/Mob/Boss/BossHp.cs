using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHp : MobHp
{
    [SerializeField] private float originalHp = 100;
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