using EnemyScripts;
using UnityEditor;
using UnityEngine;

namespace LevelScripts
{
    public class EnemyManager : MonoBehaviour
    {
        public EnemySpawnScriptable GetEnemySpawn(string path)
        {
            EnemySpawnScriptable spawner = ScriptableObject.CreateInstance<EnemySpawnScriptable>();

            foreach (Transform child in transform)
            {
                GameObject enemy = child.gameObject;

                spawner.AddEnemy(PrefabUtility.GetCorrespondingObjectFromOriginalSource(enemy), enemy.transform.position);
            }

            AssetDatabase.CreateAsset(spawner, path + "/" + "EnemySpawner.asset");

            return spawner;
        }

        public void SetEnemySpawn(EnemySpawnScriptable spawner, Transform target)
        {
            ClearEnemySpawn();

            foreach (EnemyPrefabPosition enemy in spawner.enemyPositionList)
            {
                GameObject go = Instantiate(enemy.enemyPrefab, enemy.position, Quaternion.identity, transform);

                // Reconnect Prefab to Save/Load more efficiently
                ConvertToPrefabInstanceSettings settings = new ConvertToPrefabInstanceSettings();
                PrefabUtility.ConvertToPrefabInstance(go, enemy.enemyPrefab, settings, InteractionMode.AutomatedAction);

                EnemyMovement enemyMovement = go.GetComponent<EnemyMovement>();
                enemyMovement.SetTarget(target);
            }
        }

        public void ClearEnemySpawn()
        {
            for (int i = transform.childCount; i > 0; i--)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
        }
    }
}