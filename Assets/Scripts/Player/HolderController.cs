using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class HolderController : MonoBehaviour
{
    public static HolderController Instance;
    GameObject currentItem;
    private Item Item;
    private string itemTag;


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
        itemTag = item.gameObj.tag;
        currentItem = Instantiate(item.gameObj);
        currentItem.GetComponent<Rigidbody>().isKinematic = true;
        currentItem.transform.parent = transform;
        currentItem.transform.localPosition = Vector3.zero;
        currentItem.transform.localEulerAngles = new Vector3(0f, -20f, 0f);
    }

    public void RemoveCurrentItem()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(currentItem);
    }

    public void Drop()
    {
        if (currentItem != null)
        {
            currentItem.transform.parent = null;
            currentItem.GetComponent<Rigidbody>().isKinematic = false;
            currentItem = null;
            itemTag = null;
        }
    }

    public string GetItemTag()
    {
        return itemTag;
    }
}
