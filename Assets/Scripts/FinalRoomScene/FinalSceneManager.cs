using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FinalSceneManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _crushEffect;

    private void Start()
    {
        ShowCursor();
    }

    private void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnEnable()
    {
        SetCrystals.onCellsAreFull += StartFinalScene;
    }
    private void OnDisable()
    {
        SetCrystals.onCellsAreFull -= StartFinalScene;
    }

    private void StartFinalScene()
    {
        StartCoroutine(StartFinalSceneCoroutine());
    }

    private IEnumerator StartFinalSceneCoroutine()
    {
        yield return new WaitForSeconds(5);
        _crushEffect.Play();
        yield return new WaitForSeconds(_crushEffect.main.duration);
    }
}
