using UnityEngine;
using System;

public class PlayerController : MobBehaviour
{
    private PlayerMovement playerMovement;
    private CameraMovement cameraMovement;
    private TakeItem takeItem;
    private MobHp hp;
    private bool isEnabled = true;
    private bool isLive = true;
    public static Action onPlayerDied;

    void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        cameraMovement = gameObject.GetComponentInChildren<CameraMovement>();
        hp = gameObject.GetComponent<MobHp>();
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

    public override void SetDamage(float damage)
    {
        if (isLive)
        {
            if (hp.SetDamage(damage))
            {
                
            }
            else
            {
                if (onPlayerDied != null)
                {
                    onPlayerDied.Invoke();
                }
            }
        }
        Debug.Log("бьють");
    }

    private void OnEnable()
    {
        InventoryOpener.onInventoryOpened += SetDisable;
        InventoryOpener.onInventoryOpened += ShowCursor;

        InventoryOpener.onInventoryClosed += SetEnable;
        InventoryOpener.onInventoryClosed += HideCursor;

        LevelManager.onLevelCompleted += SetDisable;
    }

    private void OnDisable()
    {
        InventoryOpener.onInventoryOpened -= SetDisable;
        InventoryOpener.onInventoryOpened -= ShowCursor;

        InventoryOpener.onInventoryClosed -= SetEnable;
        InventoryOpener.onInventoryClosed -= HideCursor;

        LevelManager.onLevelCompleted -= SetDisable;
    }

    private void SetEnable()
    {
        isEnabled = true;
    }

    private void SetDisable()
    {
        isEnabled = false;
    }

    private void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
