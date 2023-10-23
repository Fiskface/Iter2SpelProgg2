using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GoblinIdleState : GoblinState
{
    public Vector2 minMaxTime;
    
    private float timer;
    public override void Start()
    {
        base.Start();
    }

    public override void Enter()
    {
        timer = Random.Range(minMaxTime.x, minMaxTime.y);
        goblin.rb.velocity = Vector2.zero;

        goblin.FlipSprite(goblin.sr.flipX);

    }

    public override void Exit()
    {
        
    }

    
    public override void Update()
    {
        timer -= Time.deltaTime;
            
        goblin.rb.velocity = Vector2.zero;
        
        

        CheckTransitions();
    }

    public override void OnHit(int damage)
    {
        goblin.Transit(goblin.chaseState);
    }

    private void CheckTransitions()
    {
        if (timer <= 0)
        {
            goblin.Transit(goblin.patrolState);
        }

        if (goblin.GetPlayerInLineOfSight() && goblin.GetDistanceToPlayer() < 8)
        {
            goblin.Transit(goblin.chaseState);
        }
    }
}
