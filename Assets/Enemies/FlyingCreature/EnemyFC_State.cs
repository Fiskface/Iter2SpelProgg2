namespace Enemies.FlyingCreature
{
    [System.Serializable]
    public abstract class EnemyFC_State
    {
        public virtual void OnValidate(EnemyFC_Behaviour enemy)
        {
            this.enemy = enemy;
        }

        protected EnemyFC_Behaviour enemy;
    
        public virtual void Awake(EnemyFC_Behaviour enemy)
        {
            this.enemy = enemy;
        }
        
        public virtual void Start() {}

        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();

        public abstract void OnHit(int damage);
    }
}
