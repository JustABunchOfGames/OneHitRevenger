using CharacterScripts;
using System.Collections.Generic;
using UnityEngine;
using WeaponScripts;

namespace PlayerScripts
{
    public class PlayerCombat : CharacterCombat
    {
        private List<Weapon> _grabbableWeapon;

        private void Start()
        {
            _grabbableWeapon = new List<Weapon>();
        }

        public void Grab()
        {
            if (_grabbableWeapon.Count > 0)
            {
                if (_currentWeapon != null)
                {
                    _currentWeapon.PutOnGround(transform.position);
                    // _grabbableWeapon.Add(_currentWeapon);
                }

                _currentWeapon = _grabbableWeapon[0];
                _grabbableWeapon.Remove(_currentWeapon);

                _animator.runtimeAnimatorController = _currentWeapon.animator;
                _currentWeapon.GetGrabbed(_whereToPutWeapon);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Weapon weapon = other.GetComponent<Weapon>();
            if (weapon != null && weapon != _currentWeapon)
                _grabbableWeapon.Add(weapon);
        }

        private void OnTriggerExit(Collider other)
        {
            Weapon weapon = other.GetComponent<Weapon>();
            if (weapon != null)
                _grabbableWeapon.Remove(weapon);
        }

        // Called from animation (via PlayerAnimationEvent)
        public void DestroyWeapon()
        {
            Destroy(_currentWeapon.gameObject);
            _animator.runtimeAnimatorController = _defaultController;
            _currentWeapon = null;
        }
    }
}