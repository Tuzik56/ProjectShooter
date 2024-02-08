using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardController : ItemController
{
    public KeyCardScript keyCardScript;

    public override void SetActive()
    {
        keyCardScript.enabled = true;
    }

    public override void SetDisabled()
    {
        keyCardScript.enabled = false;
    }
}
