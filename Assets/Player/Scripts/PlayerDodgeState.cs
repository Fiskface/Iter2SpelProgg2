using UnityEngine;

namespace Player.Scripts
{
    [System.Serializable]
    public class PlayerDodgeState : PlayerState
    {
        public float speed;
        public float dodgeCooldown;
        public float dodgeTime = 1f;

        private Vector2 direction;
        private float dodgeOverTimer;
        private static readonly int DodgeTimeMultiplier = Animator.StringToHash("DodgeTimeMultiplier");
        private static readonly int Dodge = Animator.StringToHash("Dodge");


        public override void Awake(PlayerBehaviour player)
        {
            base.Awake(player);
            player.animator.SetFloat(DodgeTimeMultiplier, 1 / dodgeTime);
        }

        public override void Enter()
        {
            direction = player.Direction;

            if (direction == Vector2.zero)
            {
                direction = !player.sr.flipX ? Vector2.right : Vector2.left;
            }

            direction *= speed;
            player.rb.velocity = direction;
        
            var c = player.sr.color;
            player.sr.color = new Color(c.r, c.g, c.b, 0.5f);

            player.animator.SetTrigger(Dodge);
            dodgeOverTimer = dodgeTime;
        }

        public override void Exit()
        {
            var c = player.sr.color;
            player.sr.color = new Color(c.r, c.g, c.b, 1);

            player.StartCoroutine(player.DodgeCooldown(dodgeCooldown));
        }

    
        public override void Update()
        {
            player.rb.velocity = direction;

            dodgeOverTimer -= Time.deltaTime;
            if (dodgeOverTimer <= 0)
            {
                player.Transit(player.idleState);
            }
        }
    }
}
