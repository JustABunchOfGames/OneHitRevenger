using UnityEngine;

namespace PlayerScripts
{
    public class PlayerAnimationEvent : MonoBehaviour
    {
        private PlayerCombat _playerCombat;
        private PlayerController _playerController;

        private void Awake()
        {
            _playerCombat = GetComponentInParent<PlayerCombat>();
            _playerController = GetComponentInParent<PlayerController>();
        }

        public void Attack()
        {
            _playerCombat.CreateAoe();
        }

        public void EndAttack()
        {
            _playerController.CanMove(true);
            _playerCombat.DestroyWeapon();
        }
    }
}