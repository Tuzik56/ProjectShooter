using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private CameraMovement cameraMovement;
    private TakeItem takeItem;
    private bool isEnabled = true;

    void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        cameraMovement = gameObject.GetComponentInChildren<CameraMovement>();
        takeItem = gameObject.GetComponent<TakeItem>();
    }

    void Update()
    {
        if (isEnabled) 
        { 
            playerMovement.MovePlayer();
            cameraMovement.MoveCamera();
            takeItem.Take();
        }
        playerMovement.PlayerGraviry();
    }

    private void OnEnable()
    {
        InventoryOpener.onInventoryOpened += SetDisable;
        InventoryOpener.onInventoryClosed += SetEnable;
    }

    private void SetEnable()
    {
        isEnabled = true;
    }

    private void SetDisable()
    {
        isEnabled = false;
    }
}
