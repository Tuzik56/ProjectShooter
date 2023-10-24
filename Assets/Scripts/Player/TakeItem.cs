using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeItem : MonoBehaviour
{
    public GameObject _camera;
    public float distance = 10f;
    GameObject currentItem;
    bool canTake;
 


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) TakeTheItem();
        if (Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    void TakeTheItem()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "Weapon")
            {
                if (canTake) Drop();

                currentItem = hit.transform.gameObject;
                currentItem.GetComponent<Rigidbody>().isKinematic = true;
                currentItem.transform.parent = transform;
                currentItem.transform.localPosition = Vector3.zero;
                currentItem.transform.localEulerAngles = new Vector3(0f, -20f, 0f);
                canTake = true;
            }
        }
    }

    void Drop()
    {
        if (currentItem != null) 
        { 
            currentItem.transform.parent = null;
            currentItem.GetComponent<Rigidbody>().isKinematic = false;
            canTake = false;
            currentItem = null;
        }
    }
}
