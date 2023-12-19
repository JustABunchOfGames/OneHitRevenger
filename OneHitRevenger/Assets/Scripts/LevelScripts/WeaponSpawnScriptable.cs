using System.Collections.Generic;
using UnityEngine;

namespace LevelScripts
{
    [System.Serializable]
    public struct WeaponPrefabPosition
    {
        public GameObject weaponPrefab;
        public Vector3 position;
    }

    public class WeaponSpawnScriptable : ScriptableSpawner
    {
        [SerializeField] private List<WeaponPrefabPosition> _weaponPositionList = new List<WeaponPrefabPosition>();

        public List<WeaponPrefabPosition> weaponPositionList { get { return _weaponPositionList; } private set { } }

        public void AddWeapon(GameObject weaponPrefab, Vector3 position)
        {
            WeaponPrefabPosition wpp = new WeaponPrefabPosition();
            wpp.weaponPrefab = weaponPrefab;
            wpp.position = position;

            weaponPositionList.Add(wpp);
        }
    }
}