using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private TargetBehaviour target;
    public EnemyIdleState idleState = new EnemyIdleState();
    public EnemyPatrolState patrolState = new EnemyPatrolState();

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public SpriteRenderer sr;
    [HideInInspector] public Health health;
    
    private GameObject player;
        
    private EnemyState currentState;
    private List<EnemyState> states;

    private void OnValidate()
    {
        states = new List<EnemyState>(){idleState, patrolState};
        foreach (var state in states)
        {
            state.OnValidate(this);
        }
    }

    private void Awake()
    {
        target = GetComponent<TargetBehaviour>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
        
        states = new List<EnemyState>(){idleState, patrolState};
        foreach (var state in states)
        {
            state.Awake(this);
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentState = idleState;
        foreach (var state in states)
        {
            state.Start();
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update();
    }
    
    public void Transit(EnemyState targetState)
    {
        currentState.Exit();
        currentState = targetState;
        currentState.Enter();
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
        health.changeHealth(-damage);
    }

    public float GetDistanceToPlayer()
    {
        return Vector3.Distance(transform.position, player.transform.position);
    }
    
    public bool GetPlayerInLineOfSight()
    {
        LayerMask mask = LayerMask.GetMask("Default");

        var timer = Time.time;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, 
            player.transform.position - transform.position, Mathf.Infinity, mask);

        if (hit.collider.CompareTag("Player"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
