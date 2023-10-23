using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public IntSO arrowAmmo;
    public IntSO lightAmmo;

    private void Awake()
    {
        arrowAmmo.value = 30;
        lightAmmo.value = 15;
    }
}
