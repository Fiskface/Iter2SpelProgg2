using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateAmmoText : MonoBehaviour
{
    public IntSO ammoType;
    public TextMeshProUGUI text;

    private void Update()
    {
        text.text = $"{ammoType.value}";
    }
}
