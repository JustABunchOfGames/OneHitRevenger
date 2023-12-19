using UnityEditor;
using UnityEngine;

namespace LevelScripts
{
    public class TerrainManager : MonoBehaviour
    {
        // All functions are called from LevelManager Events

        public void Save(LevelSpawnScriptable levelScriptable)
        {
            GameObject terrain = transform.GetChild(0).gameObject;

            TerrainSpawnScriptable spawner = ScriptableObject.CreateInstance<TerrainSpawnScriptable>();
            spawner.InitSpawner(PrefabUtility.GetCorrespondingObjectFromOriginalSource(terrain));

            AssetDatabase.CreateAsset(spawner, levelScriptable.path + "/" + "TerrainSpawner.asset");

            levelScriptable.SaveLevelSpawner(spawner);
        }

        public void Load(LevelSpawnScriptable levelScriptable)
        {
            Clear();

            TerrainSpawnScriptable spawner = (TerrainSpawnScriptable)levelScriptable.GetLevelSpawner(typeof(TerrainSpawnScriptable));

            GameObject go = Instantiate(spawner.terrainPrefab, transform);

            // Reconnect Prefab to Save/Load more efficiently
            ConvertToPrefabInstanceSettings settings = new ConvertToPrefabInstanceSettings();
            PrefabUtility.ConvertToPrefabInstance(go, spawner.terrainPrefab, settings, InteractionMode.AutomatedAction);
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