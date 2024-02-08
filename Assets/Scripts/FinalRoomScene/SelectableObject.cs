using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    private Outline outline;

    private void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    private void OnMouseDown()
    {
        SelectObject();
    }

    private void SelectObject()
    {
        SetCrystals.Instance.SetSelectedCrystal(gameObject);
        outline.enabled = true;
    }

    public void DeselectObject()
    {
        outline.enabled = false;
    }
}
