using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossAttack : MonoBehaviour
{
    [Header("Boss behaviour")]
    [SerializeField] private float shootPause = 4f;
    [Header("Projectile")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float rayDistance;
    [SerializeField] private int rayCount;

    private float rayAngle = 360;
    private float timeLastShoot = 0;

    private void Start()
    {
        projectilePrefab.GetComponent<Projectile>().SetLiveTime(5f);
    }

    public void Attack(GameObject target)
    {
        if (Time.time > timeLastShoot + shootPause)
        {
            CalculateProjectilePath();
            timeLastShoot = Time.time;
        }
    }

    private void CalculateProjectilePath()
    {
        float j = 0;
        for (int i = 0; i < rayCount; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);
            j += rayAngle * Mathf.Deg2Rad / rayCount;

            Vector3 direction = transform.TransformDirection(new Vector3(x, 0, y));
            PushProjectile(direction);
        }
    }

    private void PushProjectile(Vector3 direction)
    {
        Vector3 projectilePosition = transform.position + new Vector3(0, 0.5f, 0) + direction * 2f;
        GameObject projectile = Instantiate(projectilePrefab, projectilePosition, Quaternion.identity);
        Rigidbody projectileRigitbody = projectile.GetComponent<Rigidbody>();

        projectileRigitbody.AddForce(direction * speed, ForceMode.VelocityChange);
    }
}
