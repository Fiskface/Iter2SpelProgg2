using UnityEngine;

namespace Player.Scripts
{
    [System.Serializable]
    public class PlayerIdleState : PlayerState
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
            player.rb.velocity = Vector2.zero;
            
            CheckTransitions();
        }
        
        private void CheckTransitions()
        {
            //To Moving
            if (player.Direction != Vector2.zero)
            {
                player.Transit(player.movingState);
            }

            //To dodge
            if (Input.GetButton("Fire2") && player.canDodge)
            {
                player.Transit(player.dodgeState);
            }
        }
    }
    
}
