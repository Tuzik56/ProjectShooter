using System;
using UnityEngine;

public class KeyCardScript : MonoBehaviour
{
    [SerializeField] private AudioClip openDoorSound;

    private Transform cameraTransform;
    private float range = 5;
    private string doorTag = "ExitLevel";
    private AudioSource audioSource;

    public static Action OnFinalDoorActivated;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (CheckDoor())
            {
                if (OnFinalDoorActivated != null)
                {
                    OnFinalDoorActivated.Invoke();
                    PlaySound(openDoorSound);
                }
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

    private void PlaySound(AudioClip audio)
    {
        if (audio != null)
        {
            audioSource.PlayOneShot(audio);
        }
    }
}
