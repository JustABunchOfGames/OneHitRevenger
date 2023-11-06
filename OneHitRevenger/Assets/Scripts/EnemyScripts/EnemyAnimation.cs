using CharacterScripts;

namespace EnemyScripts
{
    public class EnemyAnimation : CharacterAnimation
    {
        private EnemyController _controller;

        protected override void Awake()
        {
            base.Awake();
            _controller = GetComponentInParent<EnemyController>();
        }

        public override void EndAttack()
        {
            _controller.EndAttack();
        }
    }
}