using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletScript : MonoBehaviour
{
    public float timeLive = 10;
    public float bulletDamage = 30;
    private float timeDeath;
    private void Start()
    {
        timeDeath = Time.time + timeLive;
    }

    private void FixedUpdate()
    {
        if (Time.time > timeDeath)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        MobBehaviour collisionBehaviour = collision.gameObject.GetComponent<MobBehaviour>();
        if (collisionBehaviour)
        {
            collisionBehaviour.SetDamage(bulletDamage);
        }
        Destroy(gameObject);
    }
}
