using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    public Item Item;

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Take();
        }
    }

    void Take()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }
}
