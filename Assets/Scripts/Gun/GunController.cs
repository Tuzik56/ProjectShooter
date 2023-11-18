using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : ItemController
{
    public GunShoot gunShoot;

    public override void SetActive()
    {
        gunShoot.enabled = true;
    }

    public override void SetDisabled()
    {
        gunShoot.enabled = false;
    }
}
