using UnityEngine;

namespace Player.Scripts
{
    public class PlayerIdle : PlayerState
    {
        public override void Start()
        {
            
        }

        public override void Enter()
        {
            player.rb.velocity = Vector2.zero;
            player.animator.SetBool(player.aniMoving, false);
        }

        public override void Exit()
        {
            
        }
        
        public override void Update()
        {
            player.FlipSprite();
            
            if (player.Direction != Vector2.zero)
            {
                player.Transit(player.movingState);
                return;
            }

            player.rb.velocity = Vector2.zero;
        }
    }
}
