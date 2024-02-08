using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameObject obj = SetCrystals.Instance.GetSelectedCrystal();

        if (obj != null)
        {
            PlaceInCell(obj);
            SetCrystals.Instance.SetSelectedCrystal(null);
        }
    }

    private void PlaceInCell(GameObject obj)
    {
        obj.transform.position = transform.localPosition;
        obj.transform.rotation = Quaternion.Euler(23, 0, 0);
    }
}
