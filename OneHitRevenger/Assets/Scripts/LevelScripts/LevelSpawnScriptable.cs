using System.Collections.Generic;
using UnityEngine;

namespace LevelScripts
{
    [CreateAssetMenu(menuName ="Level/Spawners")]
    public class LevelSpawnScriptable : ScriptableObject
    {
        public List<LevelSpawner> levelSpawners = new List<LevelSpawner>();

        public void AddLevel(LevelSpawner levelSpawner)
        {
            foreach (var level in levelSpawners)
            {
                if (level.world == levelSpawner.world && level.level == levelSpawner.level)
                {
                    levelSpawners.Remove(level);
                    break;
                }
            }

            levelSpawners.Add(levelSpawner);
        }

        public LevelSpawner GetLevelSpawner(int world, int level)
        {
            foreach(LevelSpawner spawner in levelSpawners)
            {
                if (spawner.world == world && spawner.level == level)
                    return spawner;
            }

            return null;
        }
    }
}