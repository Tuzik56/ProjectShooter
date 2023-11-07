using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MobBehaviour
{
    public MobHp thisHp;
    private bool isLive = true;

    void Start()
    {
        thisHp = GetComponent<MobHp>();
    }

    public override void SetDamage(float damage)
    {
        if (isLive)
        {
            if (thisHp.SetDamage(damage))
            {

            }
            else
            {
                Debug.Log("Доигралися");
            }
        }
    }
}
