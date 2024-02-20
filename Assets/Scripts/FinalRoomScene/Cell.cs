using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private bool isEmpty = true;

    private void OnMouseDown()
    {
        GameObject obj = SetCrystals.Instance.GetSelectedCrystal();

        if (obj != null & isEmpty)
        {
            PlaceInCell(obj);
            SetCrystals.Instance.SetSelectedCrystal(null);
            SetCrystals.Instance.CellIsFull();
            isEmpty = false;
        }
    }

    private void PlaceInCell(GameObject obj)
    {
        obj.transform.position = transform.localPosition;
        obj.transform.rotation = Quaternion.Euler(23, 0, 0);

        Destroy(obj.GetComponent<SelectableObject>());
    }
}
