using System;
using UnityEngine;
using System.Collections.Generic;

namespace LevelScripts
{
    [System.Serializable]
    public class LevelSpawner
    {
        public int world;
        public int level;

        private Dictionary<Type, ScriptableSpawner> _spawnerDictionary;

        public LevelSpawner()
        {
            _spawnerDictionary = new Dictionary<Type, ScriptableSpawner>();
        }

        public ScriptableSpawner GetSpawner(Type type)
        {
            Debug.Log(type);

            Debug.Log(_spawnerDictionary.ContainsKey(type));

            Debug.Log(_spawnerDictionary.Count);

            if (_spawnerDictionary.ContainsKey(type))
                return _spawnerDictionary[type];
            return null;
        }

        public void AddSpawner(ScriptableSpawner spawner)
        {
            Type spawnerType = spawner.GetType();

            Debug.Log(spawnerType);

            if (_spawnerDictionary.ContainsKey(spawnerType))
                _spawnerDictionary[spawnerType] = spawner;
            else
                _spawnerDictionary.Add(spawnerType, spawner);

            Debug.Log(_spawnerDictionary.Count);
            Debug.Log(_spawnerDictionary[spawnerType]);
        }
    }
}