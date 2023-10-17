using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyPatrolState : EnemyState
{
    public float speed = 3;
    
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
            RaycastHit2D hit = Physics2D.Raycast(enemy.transform.position, 
                direction, 3, mask);

            if (hit.collider == null)
                break;
        }

        if (direction.x < 0)
            enemy.sr.flipX = true;
        else
            enemy.sr.flipX = false;
        
        timer = Random.Range(1f, 4f);

        enemy.rb.velocity = direction * speed;
    }

    public override void Exit()
    {
        
    }

    
    public override void Update()
    {
        if (timer <= 0)
        {
            enemy.Transit(enemy.idleState);
        }
        timer -= Time.deltaTime;
        
    }

    public override void OnHit(int damage)
    {
        
    }
}
