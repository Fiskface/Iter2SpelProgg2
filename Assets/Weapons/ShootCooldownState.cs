using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShootCooldownState : WeaponState
{
    public float cooldownTime;

    private float currentCooldown;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void Enter()
    {
        currentCooldown = cooldownTime;
    }

    public override void Exit()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0)
        {
            weapon.Transit(weapon.canShootState);
        }
    }
    
}
