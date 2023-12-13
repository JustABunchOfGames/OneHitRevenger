using UnityEditor;
using UnityEngine;

namespace LevelScripts
{
    public class SpecialLevelManager : MonoBehaviour
    {
        public SpecialLevelSpawnScriptable GetSpecialLevelSpawn(string path)
        {
            GameObject specialLevel = transform.GetChild(0).gameObject;

            SpecialLevelSpawnScriptable spawner = ScriptableObject.CreateInstance<SpecialLevelSpawnScriptable>();
            spawner.InitSpawner(PrefabUtility.GetCorrespondingObjectFromOriginalSource(specialLevel));

            AssetDatabase.CreateAsset(spawner, path + "/" + "SpecialLevelSpawner.asset");

            return spawner;
        }

        public void SetSpecialLevelSpawn(SpecialLevelSpawnScriptable spawner)
        {
            ClearSpecialLevelSpawn();

            GameObject go = Instantiate(spawner.specialLevelPrefab, transform);

            // Reconnect Prefab to Save/Load more efficiently
            ConvertToPrefabInstanceSettings settings = new ConvertToPrefabInstanceSettings();
            PrefabUtility.ConvertToPrefabInstance(go, spawner.specialLevelPrefab, settings, InteractionMode.AutomatedAction);
        }

        public void ClearSpecialLevelSpawn()
        {
            for (int i = transform.childCount; i > 0; i--)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
        }
    }
}