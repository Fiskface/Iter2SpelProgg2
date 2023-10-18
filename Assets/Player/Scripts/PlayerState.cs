using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class PlayerState
{
    public virtual void OnValidate(PlayerBehaviour player)
    {
        this.player = player;
    }

    protected PlayerBehaviour player;
    
    public virtual void Awake(PlayerBehaviour player)
    {
        this.player = player;
    }
    
    public virtual void Start() {}

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}
