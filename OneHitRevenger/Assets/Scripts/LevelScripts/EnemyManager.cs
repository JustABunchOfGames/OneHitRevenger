using EnemyScripts;
using UnityEditor;
using UnityEngine;

namespace LevelScripts
{
    public class EnemyManager : MonoBehaviour
    {
        // All functions are called from LevelManager Events

        public void Save(LevelSpawnScriptable levelScriptable)
        {
            EnemySpawnScriptable spawner = ScriptableObject.CreateInstance<EnemySpawnScriptable>();

            foreach (Transform child in transform)
            {
                GameObject enemy = child.gameObject;

                spawner.AddEnemy(PrefabUtility.GetCorrespondingObjectFromOriginalSource(enemy), enemy.transform.position);
            }

            AssetDatabase.CreateAsset(spawner, levelScriptable.path + "/" + "EnemySpawner.asset");

            levelScriptable.SaveLevelSpawner(spawner);
        }

        public void Load(LevelSpawnScriptable levelScriptable)
        {
            Clear();

            EnemySpawnScriptable spawner = (EnemySpawnScriptable) levelScriptable.GetLevelSpawner(typeof(EnemySpawnScriptable));

            foreach (EnemyPrefabPosition enemy in spawner.enemyPositionList)
            {
                GameObject go = Instantiate(enemy.enemyPrefab, enemy.position, Quaternion.identity, transform);

                // Reconnect Prefab to Save/Load more efficiently
                ConvertToPrefabInstanceSettings settings = new ConvertToPrefabInstanceSettings();
                PrefabUtility.ConvertToPrefabInstance(go, enemy.enemyPrefab, settings, InteractionMode.AutomatedAction);
            }
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