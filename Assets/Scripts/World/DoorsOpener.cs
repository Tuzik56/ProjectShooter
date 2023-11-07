using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsOpener : MonoBehaviour
{
    private GameObject[] enemies;

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0 )
        {
            Destroy(gameObject);
        }
    }
}
