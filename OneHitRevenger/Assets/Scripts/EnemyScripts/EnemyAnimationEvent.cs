using UnityEngine;

namespace EnemyScripts
{
    public class EnemyAnimationEvent : MonoBehaviour
    {
        private EnemyCombat _combat;
        private EnemyController _controller;

        private void Awake()
        {
            _combat = GetComponentInParent<EnemyCombat>();
            _controller = GetComponentInParent<EnemyController>();
        }

        public void Attack()
        {
            _combat.CreateAoe();
        }

        public void EndAttack()
        {
            _controller.EndAttack();
        }
    }
}