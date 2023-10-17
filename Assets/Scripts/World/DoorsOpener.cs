using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsOpener : MonoBehaviour
{
    private GameObject[] enemies;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Destroy(gameObject);
        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0 )
        {
            Destroy(gameObject);
        }
    }
}
