using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float _health = 50.0f;
    public void TakeDamage(float amount)
    {
        _health -= amount;
        if ( _health < 0 )
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
