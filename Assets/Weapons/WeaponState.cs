using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class WeaponState
{
    public virtual void OnValidate(WeaponBehaviour weapon)
    {
        this.weapon = weapon;
    }

    protected WeaponBehaviour weapon;
    
    // Start is called before the first frame update
    public virtual void Awake() {}

    // Update is called once per frame
    public virtual void Start() {}

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}
