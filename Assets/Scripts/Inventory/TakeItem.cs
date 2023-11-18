using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _range = 10f;

    public void Take()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ItemController item = FindItem();
            if (item != null)
            {
                item.Take();
            }
        }
    }

    public ItemController FindItem()
    {
        RaycastHit hit;
        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out hit, _range))
        {
            if (hit.transform.TryGetComponent(out ItemController item))
            {
                return item;
            }
        }
        return null;
    }
}
