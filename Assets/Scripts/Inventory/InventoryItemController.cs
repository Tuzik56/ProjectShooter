using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public static InventoryItemController Instance;
    public Item item;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaceInHolder()
    {
        HolderController.Instance.Place(item.gameObj);
        InventoryManager.Instance.CloseInvenroty();
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        //Destroy(gameObject);
    }
}
