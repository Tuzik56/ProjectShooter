using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    public float range = 10.0f;
    public Camera _camera;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Take();
        }
    }

    void Take()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range))
        {
            ItemController itemController = hit.transform.GetComponent<ItemController>();
            if (itemController != null)
            {
                itemController.Take();
            }
        }
    }
}
