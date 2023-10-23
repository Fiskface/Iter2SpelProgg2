using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBehaviour : MonoBehaviour
{
        public int damage = 1;
        public int damageWithWeapon = 1;

        public GameObject weapon;
        [HideInInspector] public SpriteRenderer weaponSR;
        [NonSerialized] public float weaponStartX;
        
        private TargetBehaviour target;

        public GoblinIdleState idleState = new GoblinIdleState();
        public GoblinPatrolState patrolState = new GoblinPatrolState();
        public GoblinChaseState chaseState = new GoblinChaseState();
        public GoblinStrafeState strafeState = new GoblinStrafeState();

        [HideInInspector] public Rigidbody2D rb;
        [HideInInspector] public SpriteRenderer sr;
        [HideInInspector] public EnemyHealth health;
        [HideInInspector] public Animator animator;
    
        [NonSerialized] public GameObject player;
        
        private GoblinState currentGoblinState;
        private List<GoblinState> states;

        private void SetStates()
        {
            states = new List<GoblinState>(){idleState, patrolState, chaseState, strafeState};
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
            weaponSR = weapon.GetComponent<SpriteRenderer>();
        
            SetStates();
            foreach (var state in states)
            {
                state.Awake(this);
            }
        }

        void Start()
        {
            weaponStartX = weapon.transform.localPosition.x;
            player = GameObject.FindGameObjectWithTag("Player");
            currentGoblinState = idleState;
            
            foreach (var state in states)
            {
                state.Start();
            }
        }

        // Update is called once per frame
        void Update()
        {
            currentGoblinState.Update();
        }
    
        public void Transit(GoblinState targetGoblinState)
        {
            currentGoblinState.Exit();
            currentGoblinState = targetGoblinState;
            currentGoblinState.Enter();
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
            currentGoblinState.OnHit(damage);
            health.changeHealth(-damage);
        }

        public void FlipSprite(bool flipped)
        {
            if (flipped)
            {
                sr.flipX = true;
                weapon.transform.localPosition = new Vector3(-weaponStartX, 0, 0);
                weaponSR.flipY = true;
            }
            else
            {
                sr.flipX = false;
                weapon.transform.localPosition = new Vector3(weaponStartX, 0, 0);
                weaponSR.flipY = false;
            }
        }

        public float GetDistanceToPlayer()
        {
            return Vector3.Distance(transform.position, player.transform.position);
        }
    
        public bool GetPlayerInLineOfSight()
        {
            LayerMask mask = LayerMask.GetMask("RaycastBox", "Map");

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
