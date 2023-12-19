using UnityEngine;

namespace LevelScripts
{
    public class SpecialLevelSpawnScriptable : ScriptableSpawner
    {
        [SerializeField] private GameObject _specialLevelPrefab;
        public GameObject specialLevelPrefab { get { return _specialLevelPrefab; } private set { } }

        public void InitSpawner(GameObject prefab)
        {
            _specialLevelPrefab = prefab;
        }
    }
}