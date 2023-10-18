using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : PlayerState
{
    public float speed = 5;
    
    private Vector2 direction;
    
    public override void Start()
    {
            
    }

    public override void Enter()
    {
        player.animator.SetBool(player.aniMoving, true);
    }

    public override void Exit()
    {
            
    }
        
    public override void Update()
    {
        player.FlipSprite();
        
        direction = player.Direction;
        if (direction == Vector2.zero)
        {
            player.Transit(player.idleState);
            return;
        }

        player.rb.velocity = direction * speed;
    }
}
