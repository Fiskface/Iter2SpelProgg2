using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private WeaponState currentState = null;
    private List<PlayerState> states;
    
    private void OnValidate()
    {
        states = new List<PlayerState>(){};
        foreach (var state in states)
        {
            state.OnValidate(this);
        }
    }

    private void Awake()
    {
        states = new List<PlayerState>(){};
        foreach (var state in states)
        {
            state.Awake(this);
        }
    }

    void Start()
    {
        //currentState = ;
        foreach (var state in states)
        {
            state.Start();
        }
    }
    
    void Update()
    {
        
        currentState.Update();
    }

    public void Transit(WeaponState targetState)
    {
        currentState.Exit();
        currentState = targetState;
        currentState.Enter();
    }
}
