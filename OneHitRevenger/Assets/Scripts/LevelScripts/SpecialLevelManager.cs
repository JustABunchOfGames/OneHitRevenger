using UnityEditor;
using UnityEngine;

namespace LevelScripts
{
    public class SpecialLevelManager : MonoBehaviour
    {
        // All functions are called from LevelManager Events

        public void Save(LevelSpawnScriptable levelScriptable)
        {
            GameObject specialLevel = transform.GetChild(0).gameObject;

            SpecialLevelSpawnScriptable spawner = ScriptableObject.CreateInstance<SpecialLevelSpawnScriptable>();
            spawner.InitSpawner(PrefabUtility.GetCorrespondingObjectFromOriginalSource(specialLevel));

            AssetDatabase.CreateAsset(spawner, levelScriptable.path + "/" + "SpecialLevelSpawner.asset");

            levelScriptable.SaveLevelSpawner(spawner);
        }

        public void Load(LevelSpawnScriptable levelScriptable)
        {
            Clear();

            SpecialLevelSpawnScriptable spawner = (SpecialLevelSpawnScriptable)levelScriptable.GetLevelSpawner(typeof(SpecialLevelSpawnScriptable));

            GameObject go = Instantiate(spawner.specialLevelPrefab, transform);

            // Reconnect Prefab to Save/Load more efficiently
            ConvertToPrefabInstanceSettings settings = new ConvertToPrefabInstanceSettings();
            PrefabUtility.ConvertToPrefabInstance(go, spawner.specialLevelPrefab, settings, InteractionMode.AutomatedAction);
        }

        public void Clear()
        {
            for (int i = transform.childCount; i > 0; i--)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
        }
    }
}