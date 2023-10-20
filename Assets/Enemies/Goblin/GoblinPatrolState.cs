using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GoblinPatrolState : GoblinState
{
    public float speed = 2;
    public Vector2 minMaxTime = new Vector2(0.5f, 2f);
    
    private Vector3 direction;
    private float timer;
    
    public override void Start()
    {
        
    }

    public override void Enter()
    {
        int i = 0;
        while (true)
        {
            i++;
            if (i > 500)
                break;
            
            direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
            
            LayerMask mask = LayerMask.GetMask("Default");
            RaycastHit2D hit = Physics2D.Raycast(goblin.transform.position, 
                direction, 3, mask);

            if (hit.collider == null)
                break;
        }

        if (direction.x < 0)
        {
            goblin.sr.flipX = true;
            goblin.weapon.transform.localPosition = new Vector3(-goblin.weaponStartX, 0, 0);
            goblin.weaponSR.flipY = true;
        }
        else
        {
            goblin.sr.flipX = false;
            goblin.weapon.transform.localPosition = new Vector3(goblin.weaponStartX, 0, 0);
            goblin.weaponSR.flipY = false;
        }
        
        timer = Random.Range(minMaxTime.x, minMaxTime.y);

        direction *= speed;
        goblin.rb.velocity = direction;
        
        
    }

    public override void Exit()
    {
        
    }

    
    public override void Update()
    {
        timer -= Time.deltaTime;

        goblin.rb.velocity = direction;
        
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
            goblin.Transit(goblin.idleState);
        }
        
        if (goblin.GetPlayerInLineOfSight() && goblin.GetDistanceToPlayer() < 8)
        {
            goblin.Transit(goblin.chaseState);
        }
    }
}
