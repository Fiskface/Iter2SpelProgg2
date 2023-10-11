using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CanShootState : WeaponState
{
    public BaseShoot shoot;
    public override void Start()
    {
        base.Start();
    }

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }
    
    public override void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            shoot.Shoot();
            weapon.Transit(weapon.shootCooldownState);
        }
    }

    
}