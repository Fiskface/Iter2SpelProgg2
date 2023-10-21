using System.Collections;
using System.Collections.Generic;
using Enemies.FlyingCreature;
using UnityEngine;

[System.Serializable]
public class EnemyFC_PatrolState : EnemyFC_State
{
    public float speed = 3;
    public Vector2 minMaxTime = new Vector2(1f, 4f);
    
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
            
            LayerMask mask = LayerMask.GetMask("Map");
            RaycastHit2D hit = Physics2D.Raycast(enemy.transform.position, 
                direction, 3, mask);

            if (hit.collider == null)
                break;
        }

        enemy.sr.flipX = direction.x < 0;
        
        timer = Random.Range(minMaxTime.x, minMaxTime.y);

        direction *= speed;
        enemy.rb.velocity = direction;
    }

    public override void Exit()
    {
        
    }

    
    public override void Update()
    {
        timer -= Time.deltaTime;

        enemy.rb.velocity = direction;
        
        CheckTransitions();
    }

    public override void OnHit(int damage)
    {
        enemy.Transit(enemy.chaseState);
    }

    private void CheckTransitions()
    {
        if (timer <= 0)
        {
            enemy.Transit(enemy.idleState);
        }
        
        if (enemy.GetPlayerInLineOfSight() && enemy.GetDistanceToPlayer() < 8)
        {
            enemy.Transit(enemy.chaseState);
        }
    }
}
