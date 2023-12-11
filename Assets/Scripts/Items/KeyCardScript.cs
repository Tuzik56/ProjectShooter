using TMPro;
using UnityEngine;

public class KeyCardScript : MonoBehaviour
{
    private Transform cameraTransform;
    private LevelManager levelManager;

    private float range = 5;
    private string doorTag = "ExitLevel";

    void Start()
    {
        cameraTransform = Camera.main.transform;
        levelManager = new LevelManager();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (CheckDoor())
            {
                levelManager.CompleteLevel();
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
