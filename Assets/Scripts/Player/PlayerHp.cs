using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MobHp
{
    [SerializeField] private float originalHp = 200;
    [SerializeField] private Slider hpStatus;
    private float currentHp;

    private void Start()
    {
        currentHp = originalHp;
        hpStatus.maxValue = originalHp;
        hpStatus.value = currentHp;
    }

    public override bool SetDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp > 0)
        {
            hpStatus.value = currentHp;
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
