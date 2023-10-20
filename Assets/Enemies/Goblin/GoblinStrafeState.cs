using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GoblinStrafeState : GoblinState
{
    public float speed = 2;
    public float shootCooldown;
    public Vector2 minMaxStrafeTime = new Vector2(0.5f, 2f);
    public GameObject arrow;
    private float currentShootCooldown;

    private float timer;
    private Vector2 direction;
    
    public override void Start()
    {
        
    }

    public override void Enter()
    {
        goblin.weaponSR.flipY = false;
        NewStrafeDirection();
        currentShootCooldown = shootCooldown;
    }

    public override void Exit()
    {
        goblin.weapon.transform.up = Vector3.right;
    }
    
    public override void Update()
    {
        goblin.weapon.transform.up = goblin.player.transform.position - goblin.transform.position;
        goblin.weapon.transform.localPosition = goblin.weapon.transform.up * 0.4f;
        TryShoot();

        goblin.sr.flipX = goblin.player.transform.position.x < goblin.transform.position.x;
        
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            NewStrafeDirection();
        }
        
        goblin.rb.velocity = direction * speed;
        
        CheckTransitions();
    }

    private void NewStrafeDirection()
    {
        timer = Random.Range(minMaxStrafeTime.x, minMaxStrafeTime.y);
        
        direction = (goblin.player.transform.position - goblin.transform.position).normalized;
        direction = new Vector2(direction.y, -direction.x);
        if (Random.Range(1, 2) == 1)
        {
            direction *= 1;
        }
    }

    private void TryShoot()
    {
        currentShootCooldown -= Time.deltaTime;
        if (currentShootCooldown <= 0)
        {
            currentShootCooldown = shootCooldown;
            var arrowBeh = Object.Instantiate(arrow, goblin.weapon.transform.position + goblin.weapon.transform.up * 0.1f,
                goblin.weapon.transform.rotation).GetComponent<ArrowBehaviour>();

            arrowBeh.damage = goblin.damageWithWeapon;
            arrowBeh.allied = false;
        }
    }

    public override void OnHit(int damage)
    {
        
    }
    
    private void CheckTransitions()
    {
        if (goblin.GetDistanceToPlayer() > 6.5f)
        {
            goblin.Transit(goblin.chaseState);
        }
        
        if (!goblin.GetPlayerInLineOfSight())
        {
            goblin.Transit(goblin.idleState);
        }
    }
}
