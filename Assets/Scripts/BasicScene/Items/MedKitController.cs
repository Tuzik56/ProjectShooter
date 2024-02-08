using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitController : ItemController
{
    public MedKitScript medKitScript;

    public override void SetActive()
    {
        medKitScript.enabled = true;
    }

    public override void SetDisabled()
    {
        medKitScript.enabled = false;
    }
}
