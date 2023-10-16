using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowShoot : BaseShoot
{
    public GameObject arrow;
    private CameraController cameraController;

    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    public override void Shoot(int damage)
    {
        var arrowBeh = Instantiate(arrow, transform.position + transform.up * 0.1f, transform.rotation)
            .GetComponent<ArrowBehaviour>();
        arrowBeh.damage = damage;
        arrowBeh.allied = true;
        cameraController.Shake(-transform.up, 0.5f, 0.05f);
    }
}
