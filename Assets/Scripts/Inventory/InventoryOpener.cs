using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpener : MonoBehaviour
{
    private bool isOpened = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!isOpened)
            {
                InventoryManager.Instance.OpenInventory();
                isOpened = true;
            }
            else
            {
                InventoryManager.Instance.CloseInvenroty();
                isOpened = false;
            }
        }
    }
}
