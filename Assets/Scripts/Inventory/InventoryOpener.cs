using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryOpener : MonoBehaviour
{
    public static InventoryOpener Instance;
    public static Action onInventoryOpened;
    public static Action onInventoryClosed;
    [SerializeField] private AudioClip _audioClip;

    private bool isOpened = false;
    private AudioSource _audioSource;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _audioSource = GameObject.FindGameObjectWithTag("MainAudioSource").GetComponent<AudioSource>();
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
        PlaySound();
        onInventoryOpened.Invoke();
    }

    public void Close()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        InventoryManager.Instance.CloseInvenroty();
        isOpened = false;
        PlaySound();
        onInventoryClosed.Invoke();
    }

    private void PlaySound()
    {
        if (_audioSource != null && _audioClip != null)
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}
