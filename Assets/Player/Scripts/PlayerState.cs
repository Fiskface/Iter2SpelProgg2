using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class PlayerState : MonoBehaviour
{
    public virtual void OnValidate(PlayerBehaviour player)
    {
        this.player = player;
    }

    protected PlayerBehaviour player;
    
    // Start is called before the first frame update
    public virtual void Awake(PlayerBehaviour player)
    {
        this.player = player;
    }

    // Update is called once per frame
    public virtual void Start() {}

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}
