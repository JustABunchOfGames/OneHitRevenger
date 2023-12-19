using System.Collections.Generic;
using UnityEngine;

namespace LevelScripts
{
    [System.Serializable]
    public struct EnemyPrefabPosition
    {
        public GameObject enemyPrefab;
        public Vector3 position;
    }

    public class EnemySpawnScriptable : ScriptableSpawner
    {
        [SerializeField] private List<EnemyPrefabPosition> _enemyPositionList = new List<EnemyPrefabPosition>();

        public List<EnemyPrefabPosition> enemyPositionList { get { return _enemyPositionList; } private set { } }

        public void AddEnemy(GameObject enemyPrefab, Vector3 position)
        {
            EnemyPrefabPosition epp = new EnemyPrefabPosition();
            epp.enemyPrefab = enemyPrefab;
            epp.position = position;

            enemyPositionList.Add(epp);
        }
    }
}