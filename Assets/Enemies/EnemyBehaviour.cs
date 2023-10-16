using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private TargetBehaviour target;
    public EnemyIdleState idleState = new EnemyIdleState();

    private EnemyState currentState;
    private List<EnemyState> states;

    private void OnValidate()
    {
        states = new List<EnemyState>(){idleState};
        foreach (var state in states)
        {
            state.OnValidate(this);
        }
    }

    private void Awake()
    {
        target = GetComponent<TargetBehaviour>();
        
        states = new List<EnemyState>(){idleState};
        foreach (var state in states)
        {
            state.Awake(this);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        target.hit += OnHit;
    }

    private void OnDisable()
    {
        target.hit -= OnHit;
    }

    private void OnHit(int damage)
    {
        currentState.OnHit(damage);
    }
}
