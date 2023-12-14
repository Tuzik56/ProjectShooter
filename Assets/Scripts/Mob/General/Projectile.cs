using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float liveTime;
    [SerializeField] private float damageRadius;
    [SerializeField] private ParticleSystem explodeEffect;
    private float deathTime;

    void Start()
    {
        deathTime = Time.time + liveTime;
    }

    private void FixedUpdate()
    {
        if (Time.time > deathTime)
        {
            Explode();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }
    
    private void Explode()
    {
        Destroy(gameObject);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, damageRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "Player")
            {
                hitCollider.GetComponent<PlayerController>().SetDamage(damage);
            }
        }
        Instantiate(explodeEffect, transform.position, transform.rotation);
    }

    public void SetLiveTime(float time)
    {
        liveTime = time;
    }
}
