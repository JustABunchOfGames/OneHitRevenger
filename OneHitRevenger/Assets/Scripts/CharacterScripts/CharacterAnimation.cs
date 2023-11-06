using UnityEditor.Animations;
using UnityEngine;

namespace CharacterScripts
{
    public class CharacterAnimation : MonoBehaviour
    {
        protected Animator _animator;
        [SerializeField] protected AnimatorController _defaultController;

        protected CharacterCombat _combat;
        protected CharacterMovement _movement;

        protected virtual void Awake()
        {
            _combat = GetComponentInParent<CharacterCombat>();
            _movement = GetComponentInParent<CharacterMovement>();

            _animator = GetComponent<Animator>();

            _combat.attackEvent.AddListener(AttackTrigger);
            _combat.changeAnimatorEvent.AddListener(ChangeAnimator);

            _movement.moveEvent.AddListener(MoveAnimation);
        }

        protected virtual void AttackTrigger()
        {
            if (_animator.runtimeAnimatorController != _defaultController)
            {
                _animator.SetBool("IsMoving", false);
                _animator.SetTrigger("Attack");
            }
        }

        private void ChangeAnimator(AnimatorController controller)
        {
            if (controller != null)
                _animator.runtimeAnimatorController = controller;
            else
                _animator.runtimeAnimatorController = _defaultController;
        }

        private void MoveAnimation(bool isMoving)
        {
            _animator.SetBool("IsMoving",isMoving);
        }

        public void Attack()
        {
            _combat.CreateAoe();
        }

        public virtual void EndAttack()
        {
            
        }
    }
}