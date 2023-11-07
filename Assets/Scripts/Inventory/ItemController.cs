using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item item;

    public void Take()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }

    public virtual void SetActive()
    {

    }

    public virtual void SetDisabled()
    {

    }
}
