using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorsOpener : MonoBehaviour
{
    [SerializeField] private string mobTag;
    private GameObject[] mobs;

    private void Update()
    {
        mobs = GameObject.FindGameObjectsWithTag(mobTag);
        if (mobs.Length == 0)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        Destroy(gameObject);
    }
}
