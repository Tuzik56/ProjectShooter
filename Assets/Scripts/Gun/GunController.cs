using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : ItemController
{
    public GunShoot shoot;

    public override void SetActive()
    {
        shoot.enabled = true;
    }

    public override void SetDisabled()
    {
        shoot.enabled = false;
    }
}
