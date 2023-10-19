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
            
            if(CheckTransitions())
                return;

            player.rb.velocity = Vector2.zero;
        }
        
        private bool CheckTransitions()
        {
            //To Moving
            if (player.Direction != Vector2.zero)
            {
                player.Transit(player.movingState);
                return true;
            }

            //To dodge
            if (Input.GetButton("Fire2"))
            {
                Debug.Log(player.canDodge);
                if (player.canDodge)
                {
                    Debug.Log("Hej");
                    player.Transit(player.dodgeState);
                }
            }
            {
                
            }

            return false;
        }
    }
    
}
