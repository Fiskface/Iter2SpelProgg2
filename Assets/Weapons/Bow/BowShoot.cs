using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowShoot : BaseShoot
{
    public GameObject arrow;
    public override void Shoot()
    {
        Instantiate(arrow, transform.position + transform.up * 0.1f, transform.rotation);
    }
}
