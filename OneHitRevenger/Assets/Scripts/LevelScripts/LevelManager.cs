using UnityEditor;
using UnityEngine;

namespace LevelScripts
{
    public class LevelManager : MonoBehaviour
    {
        private PlayerManager _playerManager;
        private WeaponManager _weaponManager;
        private EnemyManager _enemyManager;
        private TerrainManager _terrainManager;
        private SpecialLevelManager _specialLevelManager;

        [SerializeField] private LevelSpawnScriptable _levelSpawnScriptable;
        [SerializeField] private string _basePath = "Assets/Levels";

        [SerializeField] private int _world;
        [SerializeField] private int _level;

        private void Awake()
        {
            _playerManager = GetComponentInChildren<PlayerManager>();
            _weaponManager = GetComponentInChildren<WeaponManager>();
            _enemyManager = GetComponentInChildren<EnemyManager>();
            _terrainManager = GetComponentInChildren<TerrainManager>();
            _specialLevelManager = GetComponentInChildren<SpecialLevelManager>();
        }

#if UNITY_EDITOR
        [ContextMenu("SaveLevel")]
        public void SaveLevelSpawner()
        {
            // Get all managers
            _playerManager = GetComponentInChildren<PlayerManager>();
            _weaponManager = GetComponentInChildren<WeaponManager>();
            _enemyManager = GetComponentInChildren<EnemyManager>();
            _terrainManager = GetComponentInChildren<TerrainManager>();
            _specialLevelManager = GetComponentInChildren<SpecialLevelManager>();

            // Name for the level folder
            string levelPath = "Level" + _world + '-' + _level;

            if (!AssetDatabase.IsValidFolder(_basePath + "/" + levelPath))
                AssetDatabase.CreateFolder(_basePath, levelPath);
            
            // Full path for this level
            levelPath = _basePath + "/" + levelPath;

            // Create LevelSpawner
            LevelSpawner spawner = new LevelSpawner(_world, _level,
                _playerManager.GetPlayerSpawn(levelPath),
                _weaponManager.GetWeaponSpawn(levelPath),
                _enemyManager.GetEnemySpawn(levelPath),
                _terrainManager.GetTerrainSpawn(levelPath),
                _specialLevelManager.GetSpecialLevelSpawn(levelPath));

            // Add it in our spawner list (wich is a scriptable object)
            _levelSpawnScriptable.AddLevel(spawner);
        }

        [ContextMenu("LoadLevel")]
        public void LoadLevelSpawner()
        {
            // Get all managers
            _playerManager = GetComponentInChildren<PlayerManager>();
            _weaponManager = GetComponentInChildren<WeaponManager>();
            _enemyManager = GetComponentInChildren<EnemyManager>();
            _terrainManager = GetComponentInChildren<TerrainManager>();
            _specialLevelManager = GetComponentInChildren<SpecialLevelManager>();

            LevelSpawner spawner = _levelSpawnScriptable.GetLevelSpawner(_world, _level);

            if (spawner == null)
            {
                Debug.Log("No Level To Load");
                return;
            }

            _terrainManager.SetTerrainSpawn(spawner.terrainSpawner);
            _weaponManager.SetWeaponSpawn(spawner.weaponSpawner);

            Transform playerTransform = _playerManager.SetPlayerSpawn(spawner.playerSpawner);
            _enemyManager.SetEnemySpawn(spawner.enemySpawner, playerTransform);

            _specialLevelManager.SetSpecialLevelSpawn(spawner.specialLevelSpawner);
        }

        [ContextMenu("ClearLevel")]
        public void ClearLevelSpawner()
        {
            // Get all managers
            _playerManager = GetComponentInChildren<PlayerManager>();
            _weaponManager = GetComponentInChildren<WeaponManager>();
            _enemyManager = GetComponentInChildren<EnemyManager>();
            _terrainManager = GetComponentInChildren<TerrainManager>();
            _specialLevelManager = GetComponentInChildren<SpecialLevelManager>();

            _playerManager.ClearPlayerSpawn();
            _weaponManager.ClearWeaponSpawn();
            _enemyManager.ClearEnemySpawn();
            _terrainManager.ClearTerrainSpawn();
            _specialLevelManager.ClearSpecialLevelSpawn();
        }
#endif
    }
}