using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GoblinChaseState : GoblinState
{
    public float speed;
    
    private Vector2 direction;
    
    public override void Start()
    {
        
    }

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }
    
    public override void Update()
    {
        direction = (goblin.player.transform.position - goblin.transform.position).normalized;

        goblin.rb.velocity = direction * speed;

        goblin.FlipSprite(direction.x < 0);
        
        CheckTransitions();
    }

    public override void OnHit(int damage)
    {
            
    }

    private void CheckTransitions()
    {
        if (goblin.GetDistanceToPlayer() <= 5)
        {
            goblin.Transit(goblin.strafeState);
        }
        
        if (!goblin.GetPlayerInLineOfSight())
        {
            goblin.Transit(goblin.idleState);
        }
    }
}
