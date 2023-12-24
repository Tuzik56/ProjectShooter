using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float shootPause = 2f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private AudioClip _audioClip;

    private float timeLastShoot = 0;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponentInChildren<AudioSource>();
    }

    public void Attack()
    {
        if (Time.time > timeLastShoot + shootPause)
        {
            PushProjectile();
            ShowShotEffect();
            timeLastShoot = Time.time;
        }
    }
    
    private void PushProjectile()
    {
        Vector3 projectilePosition = transform.position + new Vector3(0, 2f, 0) + transform.forward;
        GameObject projectile = Instantiate(projectilePrefab, projectilePosition, Quaternion.identity);
        Rigidbody projectileRigitbody = projectile.GetComponent<Rigidbody>();
        projectileRigitbody.AddForce(transform.forward * speed, ForceMode.VelocityChange);
    }

    private void ShowShotEffect()
    {
        if (_audioSource != null && _audioClip != null)
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}
