using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Scripts
{
    public class PlayerBehaviour : MonoBehaviour
    {
        public float takeDamageCooldown = 1;
        private bool canTakeDamage = true;
        
        public MousePosSO mousePos;
    
        public PlayerIdleState idleState = new PlayerIdleState();
        public PlayerMovingState movingState = new PlayerMovingState();
        public PlayerDodgeState dodgeState = new PlayerDodgeState();
    
        [HideInInspector] public TargetBehaviour target;
        [HideInInspector] public Rigidbody2D rb;
        [HideInInspector] public SpriteRenderer sr;
        [HideInInspector] public Health health;
        [HideInInspector] public Animator animator; 
        [NonSerialized] public bool canDodge = true;
    
        private PlayerState currentState = null;
        private List<PlayerState> states;
    
        public readonly int aniMoving = Animator.StringToHash("Moving");
    
        public Vector2 Direction => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        private void SetStates()
        {
            states = new List<PlayerState>(){idleState, movingState, dodgeState};
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
            target = GetComponentInChildren<TargetBehaviour>();
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            health = GetComponent<Health>();
            animator = GetComponent<Animator>();
        
            SetStates();
            foreach (var state in states)
            {
                state.Awake(this);
            }
        }

        void Start()
        {
            currentState = idleState;
            foreach (var state in states)
            {
                state.Start();
            }
        }
    
        void Update()
        {
        
            currentState.Update();
        }

        public void Transit(PlayerState targetState)
        {
            currentState.Exit();
            currentState = targetState;
            currentState.Enter();
        }
    
        public void FlipSprite()
        {
            if (mousePos.mousePosition.x < transform.position.x)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
        
        public IEnumerator DodgeCooldown(float cooldown)
        {
            canDodge = false;
            yield return new WaitForSeconds(cooldown);
            canDodge = true;
        }

        public IEnumerator TakeDamageCooldown(float cooldown)
        {
            canTakeDamage = false;
            var c = sr.color;
            sr.color = new Color(c.r, c.g, c.b, 0.5f);
            yield return new WaitForSeconds(cooldown);
            canTakeDamage = true;
            sr.color = new Color(c.r, c.g, c.b, 1);
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
            if(canTakeDamage)
            {
                StartCoroutine(TakeDamageCooldown(takeDamageCooldown));
                health.changeHealth(-damage);
            }
        }
    }
}
