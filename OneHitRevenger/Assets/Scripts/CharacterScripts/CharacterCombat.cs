using UnityEngine;
using WeaponScripts;
using Core;
using UnityEngine.Events;
using UnityEditor.Animations;

namespace CharacterScripts
{
    public class CharacterCombat : MonoBehaviour, IDamageable
    {
        protected Weapon _currentWeapon;

        [SerializeField] protected Transform _whereToPutWeapon;

        [SerializeField] protected int _hp;

        public AttackEvent attackEvent = new AttackEvent();

        public ChangeAnimatorEvent changeAnimatorEvent = new ChangeAnimatorEvent();

        public void Attack()
        {
            attackEvent.Invoke();
        }

        // Called from animation (via CharacterAnimation)
        public void CreateAoe()
        {
            if (_currentWeapon != null)
                _currentWeapon.CreateAoe(transform.rotation);
        }

        // IDamageable
        public void TakeDamage()
        {
            _hp -= 1;
            if (_hp <= 0)
            {
                if (_currentWeapon != null)
                    _currentWeapon.PutOnGround(transform.position);

                Destroy(gameObject);
            }
        }

        public virtual void EndAttack()
        {

        }

        public class AttackEvent : UnityEvent { }

        public class ChangeAnimatorEvent : UnityEvent<AnimatorController> { }
    }
}