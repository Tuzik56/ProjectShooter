using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MobBehaviour
{
    private PlayerMovement playerMovement;
    private CameraMovement cameraMovement;
    private TakeItem takeItem;
    private MobHp hp;
    private bool isEnabled = true;
    private bool isLive = true;

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
                LevelManager.Instance.RestartLevel();
                Debug.Log("Доигралися");
            }
        }
        Debug.Log("бьють");
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
