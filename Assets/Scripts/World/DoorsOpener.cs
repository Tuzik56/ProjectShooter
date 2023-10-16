using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsOpener : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Destroy(gameObject);
        }
    }
}
