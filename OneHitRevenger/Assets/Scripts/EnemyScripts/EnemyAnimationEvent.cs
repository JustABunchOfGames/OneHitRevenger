using UnityEngine;

namespace EnemyScripts
{
    public class EnemyAnimationEvent : MonoBehaviour
    {
        private EnemyCombat _playerCombat;

        private void Awake()
        {
            _playerCombat = GetComponentInParent<EnemyCombat>();
        }

        public void Attack()
        {
            _playerCombat.CreateAoe();
        }

        public void EndAttack()
        {
            
        }
    }
}