using UnityEditor;
using UnityEngine;

namespace LevelScripts
{
    public class TerrainManager : MonoBehaviour
    {
        public TerrainSpawnScriptable GetTerrainSpawn(string path)
        {
            GameObject terrain = transform.GetChild(0).gameObject;

            TerrainSpawnScriptable spawner = ScriptableObject.CreateInstance<TerrainSpawnScriptable>();
            spawner.InitSpawner(PrefabUtility.GetCorrespondingObjectFromOriginalSource(terrain));

            AssetDatabase.CreateAsset(spawner, path + "/" + "TerrainSpawner.asset");

            return spawner;
        }

        public void SetTerrainSpawn(TerrainSpawnScriptable spawner)
        {
            ClearTerrainSpawn();

            GameObject go = Instantiate(spawner.terrainPrefab, transform);

            // Reconnect Prefab to Save/Load more efficiently
            ConvertToPrefabInstanceSettings settings = new ConvertToPrefabInstanceSettings();
            PrefabUtility.ConvertToPrefabInstance(go, spawner.terrainPrefab, settings, InteractionMode.AutomatedAction);
        }

        public void ClearTerrainSpawn()
        {
            for (int i = transform.childCount; i > 0; i--)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
        }
    }
}