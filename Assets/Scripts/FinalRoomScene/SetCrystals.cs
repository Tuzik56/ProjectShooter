using System;
using UnityEngine;

public class SetCrystals : MonoBehaviour
{
    public static SetCrystals Instance;
    public static Action onCellsAreFull;

    [SerializeField] private GameObject[] crystals;

    private int cells;
    private GameObject selectedCrystal;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        cells = crystals.Length;
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

    public void CellIsFull()
    {
        cells--;
        if (cells == 0)
        {
            if (onCellsAreFull != null)
            {
                onCellsAreFull.Invoke();
            }
        }
    }
}
