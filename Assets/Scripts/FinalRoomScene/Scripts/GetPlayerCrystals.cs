using UnityEngine;

public class GetPlayerCrystals : InventoryItemController
{
    public void GetInventoryCrystals()
    {
        if (item.id == 8)
        {
            SetCrystals.Instance.Set();
            InventoryOpener.Instance.Close();
        }
    }
}
