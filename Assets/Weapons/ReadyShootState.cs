using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ReadyShootState : WeaponState
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
        shoot.Shoot(weapon.damage);
        weapon.ammoType.value--;
    }
    
    public override void Update()
    {
        if (Input.GetButton("Fire1") && weapon.ammoType.value > 0)
        {
            weapon.Transit(weapon.shootCooldownState);
        }
    }

    
}
