using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : ItemController
{
    public CrystalScript crystalScript;

    public override void SetActive()
    {
        crystalScript.enabled = true;
    }

    public override void SetDisabled()
    {
        crystalScript.enabled = false;
    }
}
