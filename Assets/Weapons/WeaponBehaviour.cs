using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponBehaviour : MonoBehaviour
{
    public int damage;
    public MousePosSO mousePos;
    public ReadyShootState readyShootState = new ReadyShootState();
    public ShootCooldownState shootCooldownState = new ShootCooldownState();
    public ReloadState reloadState = new ReloadState();

    private WeaponState currentState = null;
    private List<WeaponState> states;
    [HideInInspector] public GameObject player;

    private void OnValidate()
    {
        states = new List<WeaponState>(){readyShootState, shootCooldownState, reloadState};
        foreach (var state in states)
        {
            state.OnValidate(this);
        }
    }

    private void Awake()
    {
        states = new List<WeaponState>(){readyShootState, shootCooldownState, reloadState};
        foreach (var state in states)
        {
            state.Awake(this);
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentState = readyShootState;
        foreach (var state in states)
        {
            state.Start();
        }
    }
    
    void Update()
    {
        SetPositionRotation();
        currentState.Update();
    }

    public void Transit(WeaponState targetState)
    {
        currentState.Exit();
        currentState = targetState;
        currentState.Enter();
    }

    private void SetPositionRotation()
    {
        var mp = new Vector3(mousePos.mousePosition.x, mousePos.mousePosition.y, 0);
        var difference = mp - player.transform.position;
        difference = difference.normalized;
        transform.position = player.transform.position + difference * 0.5f;
        transform.up = difference;
    }
}
