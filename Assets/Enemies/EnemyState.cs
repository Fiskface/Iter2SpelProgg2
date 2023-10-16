using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class EnemyState
{
    public virtual void OnValidate(EnemyBehaviour enemy)
    {
        this.enemy = enemy;
    }

    protected EnemyBehaviour enemy;
    
    public virtual void Awake(EnemyBehaviour enemy)
    {
        this.enemy = enemy;
    }

    // Update is called once per frame
    public virtual void Start() {}

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();

    public abstract void OnHit(int damage);
}
