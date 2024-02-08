using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private Item item;
    private GameObject[] mobs;
    private bool enable = true;

    public void CheckMob()
    {
        mobs = GameObject.FindGameObjectsWithTag(transform.tag);
        if (enable && mobs.Length <= 1)
        {
            Drop();
            enable = false;
        }
    }

    private void Drop()
    {
        var obj = Instantiate(item.gameObj, transform.position + new Vector3(0, 1.5f, 0), transform.rotation);
        obj.GetComponent<Rigidbody>().isKinematic = false;

        obj.GetComponent<ItemController>().SetDisabled();
        obj.transform.parent = null;
    }
}
