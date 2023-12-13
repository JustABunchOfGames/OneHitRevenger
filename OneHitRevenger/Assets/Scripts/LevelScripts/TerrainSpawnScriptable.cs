using UnityEngine;

namespace LevelScripts
{
    public class TerrainSpawnScriptable : ScriptableObject
    {
        [SerializeField] private GameObject _terrainPrefab;
        public GameObject terrainPrefab { get { return _terrainPrefab; } private set { } }

        public void InitSpawner(GameObject terrainPrefab)
        {
            _terrainPrefab = terrainPrefab;
        }
    }
}