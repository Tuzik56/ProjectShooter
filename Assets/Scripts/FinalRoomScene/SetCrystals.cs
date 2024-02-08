using System.Collections.Generic;
using UnityEngine;

public class SetCrystals : MonoBehaviour
{
    public static SetCrystals Instance;
    [SerializeField] private GameObject[] crystals;
    private GameObject selectedCrystal;

    private void Awake()
    {
        Instance = this;
    }

    public void Set()
    {
        int count = InventoryManager.Instance.CountContainedItems(8);

        if (count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                if (i < crystals.Length)
                {
                    crystals[i].SetActive(true);
                }
            }
        }
    }

    public void SetSelectedCrystal(GameObject obj)
    {
        selectedCrystal?.GetComponent<SelectableObject>().DeselectObject();
        selectedCrystal = obj;
    }

    public GameObject GetSelectedCrystal()
    {
        return selectedCrystal;
    }
}
