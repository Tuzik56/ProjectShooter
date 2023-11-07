using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public CameraMovement cameraMovement;
    public 

    void Start()
    {
        playerMovement = gameObject.GetComponentInChildren<PlayerMovement>();
        cameraMovement = gameObject.GetComponentInChildren<CameraMovement>();
    }

    void Update()
    {
        playerMovement.MovePlayer();
        cameraMovement.MoveCamera();

    }
}
