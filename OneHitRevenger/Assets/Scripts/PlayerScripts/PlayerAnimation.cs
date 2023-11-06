using CharacterScripts;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerAnimation : CharacterAnimation
    {
        private PlayerController _controller;

        protected override void Awake()
        {
            base.Awake();
            _controller = GetComponentInParent<PlayerController>();
        }

        protected override void AttackTrigger()
        {
            if (_animator.runtimeAnimatorController != _defaultController)
            {
                _animator.SetTrigger("Attack");
                _controller.CanMove(false);
            }
            else
            {
                _controller.CanMove(true);
            }
        }

        public override void EndAttack()
        {
            _controller.CanMove(true);
            _combat.EndAttack();
        }
    }
}