using CharacterScripts;
using UnityEngine;
using WeaponScripts;

namespace EnemyScripts
{
    public class EnemyCombat : CharacterCombat
    {
        [SerializeField] private Weapon _weaponPrefab;
        [SerializeField] private float _attackRange;

        private void Awake()
        {
            if ( _weaponPrefab != null )
            {
                _currentWeapon = Instantiate(_weaponPrefab);

                _animator.runtimeAnimatorController = _currentWeapon.animator;
                _currentWeapon.GetGrabbed(_whereToPutWeapon);
            }
        }

        public float GetRange()
        {
            return _attackRange;
        }
    }
}