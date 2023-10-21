using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShoot : BaseShoot
{
    public GameObject bullet;
    private CameraController cameraController;
    private AudioSource audioSource;

    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        audioSource = GetComponent<AudioSource>();
    }

    public override void Shoot(int damage)
    {
        audioSource.Play();
        var bulletBeh = Instantiate(bullet, transform.position + transform.up * 0.3f, transform.rotation)
            .GetComponent<ArrowBehaviour>();
        bulletBeh.damage = damage;
        bulletBeh.allied = true;
        cameraController.Shake(-transform.up, 0.7f, 0.06f);
    }
}
