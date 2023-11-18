using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryOpener : MonoBehaviour
{
    public static InventoryOpener Instance;
    public static Action onInventoryOpened;
    public static Action onInventoryClosed;
    private bool isOpened = false;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!isOpened)
            {
                Open();
            }
            else
            {
                Close();
            }
        }
    }

    public void Open()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        InventoryManager.Instance.OpenInventory();
        isOpened = true;
        onInventoryOpened.Invoke();
    }

    public void Close()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        InventoryManager.Instance.CloseInvenroty();
        isOpened = false;
        onInventoryClosed.Invoke();
    }
}
