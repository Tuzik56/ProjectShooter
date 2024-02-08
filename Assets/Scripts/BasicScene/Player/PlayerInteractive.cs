using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    private Transform cameraTransform;
    private float range = 10f;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            InteractibleItem interactibleItem = TryInteracvite();
            if (interactibleItem != null)
            {
                interactibleItem.Interact();
            }
        }
    }

    private InteractibleItem TryInteracvite()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, range))
        {
            if (hit.transform.TryGetComponent(out InteractibleItem interactibleItem))
            {
                return interactibleItem;
            }
        }
        return null;
    }
}
