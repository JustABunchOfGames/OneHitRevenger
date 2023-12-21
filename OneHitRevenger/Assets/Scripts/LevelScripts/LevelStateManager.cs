using SpecialLevelScripts;
using UnityEngine;

namespace LevelScripts
{
    public class LevelStateManager : MonoBehaviour
    {
        private int _nbOfEnemySpawned;

        private bool _hasSpecialWinCondition;

        private void Awake()
        {
            SpecialLevelManager.specialLevelSpawnEvent.AddListener((bool b) => _hasSpecialWinCondition = b);

            EnemyManager.enemySpawnEvent.AddListener((int i) => _nbOfEnemySpawned = i);
        }
    }
}