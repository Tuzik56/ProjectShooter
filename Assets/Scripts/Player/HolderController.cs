using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HolderController : MonoBehaviour
{
    public static HolderController Instance;
    GameObject currentItem;


    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    public void Place(GameObject item)
    {
        if (currentItem != null) 
        { 
            Destroy(currentItem); 
        
        }
        currentItem = Instantiate(item);
        currentItem.GetComponent<Rigidbody>().isKinematic = true;
        currentItem.transform.parent = transform;
        currentItem.transform.localPosition = Vector3.zero;
        currentItem.transform.localEulerAngles = new Vector3(0f, -20f, 0f);
    }

    public void Drop()
    {
        if (currentItem != null)
        {
            currentItem.transform.parent = null;
            currentItem.GetComponent<Rigidbody>().isKinematic = false;
            currentItem = null;

            InventoryItemController.Instance.RemoveItem();
        }
    }
}
