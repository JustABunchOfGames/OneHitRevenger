using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelScripts
{
    [CreateAssetMenu(menuName ="Level/Spawners")]
    public class LevelSpawnScriptable : ScriptableObject
    {
        public List<LevelSpawner> levelSpawners = new List<LevelSpawner>();

        public string path { get; set; }

        // World & Level are set from the LevelManager
        public int world { private get; set; }
        public int level { private get; set; }

        public void SaveLevelSpawner(ScriptableSpawner scriptableSpawner)
        {
            foreach (LevelSpawner spawner in levelSpawners)
            {
                if (spawner.world == world && spawner.level == level)
                {
                    spawner.AddSpawner(scriptableSpawner);
                    return;
                }
            }

            LevelSpawner levelSpawner = new LevelSpawner();
            levelSpawner.world = world;
            levelSpawner.level = level;
            levelSpawner.AddSpawner(scriptableSpawner);
            levelSpawners.Add(levelSpawner);
        }

        public ScriptableSpawner GetLevelSpawner(Type type)
        {
            foreach(LevelSpawner spawner in levelSpawners)
            {
                if (spawner.world == world && spawner.level == level)
                    return spawner.GetSpawner(type);
            }

            return null;
        }

        public bool LevelExist()
        {
            foreach (LevelSpawner spawner in levelSpawners)
            {
                if (spawner.world == world && spawner.level == level)
                    return true;
            }
            return false;
        }
    }
}