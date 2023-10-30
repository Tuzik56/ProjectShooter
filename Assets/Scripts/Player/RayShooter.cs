using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    public float damage = 20.0f;
    public float range = 100.0f;
    public Camera _camera;

 
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && (HolderController.Instance.GetItemTag() == "Weapon"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
