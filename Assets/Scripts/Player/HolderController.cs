using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HolderController : MonoBehaviour
{
    public static HolderController Instance;
    private GameObject currentItem;
    private Item Item;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    public void Place(Item item)
    {
        if (currentItem != null) 
        {
            RemoveCurrentItem();
        }
        Item = item;
        currentItem = Instantiate(item.gameObj);
        currentItem.GetComponent<Rigidbody>().isKinematic = true;
        currentItem.transform.parent = transform;
        currentItem.transform.localPosition = item.position;
        currentItem.transform.localEulerAngles = item.rotation;
        currentItem.GetComponent<ItemController>().SetActive();
    }

    public void RemoveCurrentItem()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(currentItem);
    }

    public void Drop()
    {
        if (currentItem != null) {
            currentItem.GetComponent<ItemController>().SetDisabled();
            currentItem.transform.parent = null;
            currentItem.GetComponent<Rigidbody>().isKinematic = false;
            currentItem = null;
        }
    }
}
