using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 50;
    public float shootPause = 1;
    private Camera _camera;
    private Transform cameraTransform;
    private float timeLastShoot = 0;

    private void Start()
    {
        _camera = gameObject.GetComponentInParent<Camera>();
        cameraTransform = _camera.transform;
    }

    private void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Time.time > timeLastShoot + shootPause)
            {
                GameObject bullet = Instantiate(bulletPrefab, cameraTransform.position + cameraTransform.forward, Quaternion.identity);
                Rigidbody bulletRigitbody = bullet.GetComponent<Rigidbody>();
                bulletRigitbody.AddForce(cameraTransform.forward * bulletSpeed, ForceMode.VelocityChange);
                timeLastShoot = Time.time;
            }
        }
    }
}
