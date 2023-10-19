using UnityEngine;

namespace Enemies.FlyingCreature
{
    [System.Serializable]
    public class EnemyFC_IdleState : EnemyFC_State
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
            enemy.rb.velocity = Vector2.zero;
        }

        public override void Exit()
        {
        
        }

    
        public override void Update()
        {
            if (timer <= 0)
            {
                enemy.Transit(enemy.patrolState);
            }
            timer -= Time.deltaTime;
            
            enemy.rb.velocity = Vector2.zero;
        }

        public override void OnHit(int damage)
        {
        
        }
    }
}
