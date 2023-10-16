using UnityEngine;

namespace PlayerScripts
{
    public class PlayerAnimationEvent : MonoBehaviour
    {
        private PlayerCombat _playerCombat;

        private void Awake()
        {
            _playerCombat = GetComponentInParent<PlayerCombat>();
        }

        public void Attack()
        {
            _playerCombat.CreateAoe();
        }

        public void EndAttack()
        {
            _playerCombat.DestroyWeapon();
        }
    }
}