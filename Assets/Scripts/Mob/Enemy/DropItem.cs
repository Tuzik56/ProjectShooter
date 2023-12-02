using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private string mobTag;
    [SerializeField] private Item item;
    private GameObject[] mobs;
    private bool enable = true;

    public void CheckMob()
    {
        mobs = GameObject.FindGameObjectsWithTag(mobTag);
        if (enable && mobs.Length <= 1)
        {
            Drop();
        }
    }

    private void Drop()
    {
        enable = false;
        var obj = Instantiate(item.gameObj);
        obj.GetComponent<Rigidbody>().isKinematic = false;
        obj.transform.localPosition = transform.position;

        obj.GetComponent<ItemController>().SetDisabled();
        obj.transform.parent = null;
    }
}
