using UnityEngine;

namespace Enemies.FlyingCreature
{
    [System.Serializable]
    public class EnemyFC_ChaseState : EnemyFC_State
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
            direction = (enemy.player.transform.position - enemy.transform.position).normalized;

            enemy.rb.velocity = direction * speed;
        
            CheckTransitions();
        }

        public override void OnHit(int damage)
        {
            
        }

        private void CheckTransitions()
        {
            if (!enemy.GetPlayerInLineOfSight())
            {
                enemy.Transit(enemy.idleState);
            }
        }
    }
}
