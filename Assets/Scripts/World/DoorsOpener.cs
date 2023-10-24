using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsOpener : MonoBehaviour
{
    private GameObject[] enemies;
    public int doorNumber;

    void Start()
    {
        
    }

    void Update()
    {
        //enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //if (enemies.Length == 0 )
        //{
        //    Destroy(gameObject);
        //}
        if (doorNumber == 1)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Destroy(gameObject);
            }
        }
        else if (doorNumber == 2)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Destroy(gameObject);
            }
        }
        
    }
}
