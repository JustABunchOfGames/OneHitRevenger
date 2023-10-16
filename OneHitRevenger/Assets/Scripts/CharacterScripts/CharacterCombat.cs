using UnityEngine;
using WeaponScripts;
using UnityEditor.Animations;
using Core;

namespace CharacterScripts
{
    public class CharacterCombat : MonoBehaviour, IDamageable
    {
        protected Weapon _currentWeapon;

        [SerializeField] protected Transform _whereToPutWeapon;

        [SerializeField] protected Animator _animator;
        [SerializeField] protected AnimatorController _defaultController;

        [SerializeField] protected int _hp;

        public void Attack()
        {
            if (_animator.runtimeAnimatorController != _defaultController)
                _animator.SetTrigger("Attack");
        }

        // Called from animation (via AnimationEvent (Player/Enemy))
        public void CreateAoe()
        {
            if (_currentWeapon != null)
                _currentWeapon.CreateAoe(transform.rotation);
        }

        public void TakeDamage()
        {
            _hp -= 1;
            if (_hp <= 0)
            {
                _currentWeapon.PutOnGround(transform.position);
                Destroy(gameObject);
            }
        }
    }
}