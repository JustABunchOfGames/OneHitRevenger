using UnityEngine;

namespace EnemyScripts
{
    public class EnemyController : MonoBehaviour
    {
        private EnemyMovement _movement;
        private EnemyCombat _combat;

        private float _attackRange;
        private bool _isAttacking = false;

        private void Awake()
        {
            _movement = GetComponent<EnemyMovement>();
            _combat = GetComponent<EnemyCombat>();

            _attackRange = _combat.GetRange();
        }

        void FixedUpdate()
        {
            if (!_isAttacking)
            {
                float distance = _movement.Move();

                if (distance < _attackRange)
                {
                    _isAttacking = true;
                    _combat.Attack();
                }
            }
        }

        public void EndAttack()
        {
            _isAttacking = false;
        }
    }
}