using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class GoblinState
{
    public virtual void OnValidate(GoblinBehaviour goblin)
    {
        this.goblin = goblin;
    }

    protected GoblinBehaviour goblin;
    
    public virtual void Awake(GoblinBehaviour goblin)
    {
        this.goblin = goblin;
    }
        
    public virtual void Start() {}

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();

    public abstract void OnHit(int damage);
}

