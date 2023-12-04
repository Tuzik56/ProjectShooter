using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float shootPause = 2f;
    [SerializeField] private GameObject projectilePrefab;
    private float timeLastShoot = 0;

    public void Attack()
    {
        if (Time.time > timeLastShoot + shootPause)
        {
            PushProjectile();
            Debug.Log("Оно пытается драться");
        }
    }
    
    private void PushProjectile()
    {
        Vector3 projectilePosition = transform.position + new Vector3(0, 1.5f, 0) + transform.forward;
        GameObject projectile = Instantiate(projectilePrefab, projectilePosition, Quaternion.identity);
        Rigidbody projectileRigitbody = projectile.GetComponent<Rigidbody>();
        projectileRigitbody.AddForce(transform.forward * speed, ForceMode.VelocityChange);

        timeLastShoot = Time.time;
    }
}
