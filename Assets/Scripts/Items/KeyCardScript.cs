using TMPro;
using UnityEngine;

public class KeyCardScript : MonoBehaviour
{
    private Transform cameraTransform;

    private float range = 5;
    private string doorTag = "ExitLevel";

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (CheckDoor())
            {
                LevelManager.Instance.CompleteLevel();
            }
        }
    }

    private bool CheckDoor()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, range))
        {
            return (hit.collider.tag == doorTag);
        }
        return false;
    }
}
