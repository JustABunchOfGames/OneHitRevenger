using CharacterScripts;
using UnityEngine;
using WeaponScripts;
using static CharacterScripts.CharacterCombat;

namespace EnemyScripts
{
    public class EnemyCombat : CharacterCombat
    {
        [SerializeField] private Weapon _weaponPrefab;
        [SerializeField] private float _attackRange;

        private void Start()
        {
            if ( _weaponPrefab != null )
            {
                _currentWeapon = Instantiate(_weaponPrefab);

                changeAnimatorEvent.Invoke(_currentWeapon.animator);
                _currentWeapon.GetGrabbed(_whereToPutWeapon);
            }
        }

        public float GetRange()
        {
            return _attackRange;
        }
    }
}