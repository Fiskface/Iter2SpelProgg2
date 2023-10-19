using UnityEngine;

namespace Player.Scripts
{
    [System.Serializable]
    public class PlayerMovingState : PlayerState
    {
        public float speed = 5;
    
        private Vector2 direction;
    
        public override void Start()
        {
            
        }

        public override void Enter()
        {
            player.animator.SetBool(player.aniMoving, true);
            player.rb.velocity = player.Direction;
        }

        public override void Exit()
        {
            
        }
        
        public override void Update()
        {
            player.FlipSprite();
        
            direction = player.Direction;
            if (CheckTransitions())
                return;

            player.rb.velocity = direction * speed;
        }

        private bool CheckTransitions()
        {
            //To Idle
            if (direction == Vector2.zero)
            {
                player.Transit(player.idleState);
                return true;
            }
        
            //To dodge
            if (Input.GetButton("Fire2") && player.canDodge)
            {
                player.Transit(player.dodgeState);
            }

            return false;
        }
    }
}
