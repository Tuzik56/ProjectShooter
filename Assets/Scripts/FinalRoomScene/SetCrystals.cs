using UnityEngine;

public class SetCrystals : MonoBehaviour
{
    public static SetCrystals Instance;
    [SerializeField] private GameObject[] crystals;

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
}
