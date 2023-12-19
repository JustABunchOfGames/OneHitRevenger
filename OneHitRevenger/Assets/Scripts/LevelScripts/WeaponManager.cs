using UnityEditor;
using UnityEngine;
using WeaponScripts;

namespace LevelScripts
{
    public class WeaponManager : MonoBehaviour
    {
        // All functions are called from LevelManager Events

        public void Save(LevelSpawnScriptable levelScriptable)
        {
            WeaponSpawnScriptable spawner = ScriptableObject.CreateInstance<WeaponSpawnScriptable>();

            foreach (Transform child in transform)
            {
                GameObject weapon = child.gameObject;

                spawner.AddWeapon(PrefabUtility.GetCorrespondingObjectFromOriginalSource(weapon), weapon.transform.position);
            }

            AssetDatabase.CreateAsset(spawner, levelScriptable.path + "/" + "WeaponSpawner.asset");

            levelScriptable.SaveLevelSpawner(spawner);
        }

        public void Load(LevelSpawnScriptable levelScriptable)
        {
            Clear();

            WeaponSpawnScriptable spawner = (WeaponSpawnScriptable)levelScriptable.GetLevelSpawner(typeof(WeaponSpawnScriptable));

            foreach (WeaponPrefabPosition weapon in spawner.weaponPositionList)
            {
                GameObject go = Instantiate(weapon.weaponPrefab, weapon.position, Quaternion.identity, transform);

                // Reconnect Prefab to Save/Load more efficiently
                ConvertToPrefabInstanceSettings settings = new ConvertToPrefabInstanceSettings();
                PrefabUtility.ConvertToPrefabInstance(go, weapon.weaponPrefab, settings, InteractionMode.AutomatedAction);

                // Position and rotation to display it clearly on ground
                Weapon wep = go.GetComponent<Weapon>();
                wep.PutOnGround(weapon.position);
                wep.transform.parent = transform;
            }
        }

        public void Clear()
        {
            for( int i = transform.childCount; i > 0; i-- )
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
        }
    }
}