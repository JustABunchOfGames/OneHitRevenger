using System.Collections.Generic;
using UnityEngine;
using WeaponScripts;

namespace PlayerScripts
{
    public class PlayerCombat : MonoBehaviour
    {
        private Weapon _currentWeapon;

        private List<Weapon> _grabbableWeapon;

        private void Start()
        {
            _grabbableWeapon = new List<Weapon>();
        }

        public void Grab()
        {
            if (_grabbableWeapon.Count > 0)
            {
                _currentWeapon = _grabbableWeapon[0];
                _grabbableWeapon.Remove(_currentWeapon);
                Debug.Log(_currentWeapon.ToString());
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            IGrabbable grabbable = other.GetComponent<IGrabbable>();
            if (grabbable != null)
                _grabbableWeapon.Add(other.GetComponent<Weapon>());
        }

        private void OnTriggerExit(Collider other)
        {
            IGrabbable grabbable = other.GetComponent<IGrabbable>();
            if (grabbable != null)
                _grabbableWeapon.Remove(other.GetComponent<Weapon>());
        }
    }
}