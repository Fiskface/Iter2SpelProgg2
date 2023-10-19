using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies.FlyingCreature
{
    public class EnemyFC_Behaviour : MonoBehaviour
    {
        public int damage = 1;
        
        private TargetBehaviour target;
        public EnemyFC_IdleState idleState = new EnemyFC_IdleState();
        public EnemyFC_PatrolState patrolState = new EnemyFC_PatrolState();
        public EnemyFC_ChaseState chaseState = new EnemyFC_ChaseState();

        [HideInInspector] public Rigidbody2D rb;
        [HideInInspector] public SpriteRenderer sr;
        [HideInInspector] public EnemyHealth health;
    
        [NonSerialized] public GameObject player;
        
        private EnemyFC_State currentFcState;
        private List<EnemyFC_State> states;

        private void SetStates()
        {
            states = new List<EnemyFC_State>(){idleState, patrolState, chaseState};
        }
        
        private void OnValidate()
        {
            SetStates();
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
            health = GetComponent<EnemyHealth>();
        
            SetStates();
            foreach (var state in states)
            {
                state.Awake(this);
            }
        }

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            currentFcState = idleState;
            foreach (var state in states)
            {
                state.Start();
            }
        }

        // Update is called once per frame
        void Update()
        {
            currentFcState.Update();
        }
    
        public void Transit(EnemyFC_State targetFcState)
        {
            currentFcState.Exit();
            currentFcState = targetFcState;
            currentFcState.Enter();
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
            currentFcState.OnHit(damage);
            health.changeHealth(-damage);
        }

        public float GetDistanceToPlayer()
        {
            return Vector3.Distance(transform.position, player.transform.position);
        }
    
        public bool GetPlayerInLineOfSight()
        {
            LayerMask mask = LayerMask.GetMask("RaycastBox", "Default");

            var timer = Time.time;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, 
                player.transform.position - transform.position, Mathf.Infinity, mask);

            if (hit.collider.CompareTag("Player"))
            {
                return true;
            }
            return false;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player") && other.TryGetComponent<TargetBehaviour>(out TargetBehaviour playerTarget))
            {
                playerTarget.hit(damage);
            }
        }
        
    }
}
