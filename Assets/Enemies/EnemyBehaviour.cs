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
    
    private GameObject player;
    [HideInInspector] public float distanceToPlayer;
    [HideInInspector] public bool canSeePlayer;
        
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
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        LayerMask mask = LayerMask.GetMask("Default");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, 
            player.transform.position - transform.position, distanceToPlayer, mask);

        if (hit.collider.CompareTag("Player"))
        {
            canSeePlayer = true;
        }
        else
        {
            canSeePlayer = false;
        }
        
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
    }
}
