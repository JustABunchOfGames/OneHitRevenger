using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace LevelScripts
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelSpawnScriptable _levelSpawnScriptable;
        [SerializeField] private string _basePath = "Assets/Levels";

        [SerializeField] private int _world;
        [SerializeField] private int _level;

        [SerializeField] public SaveLevelEvent saveLevelEvent = new SaveLevelEvent();
        [SerializeField] public LoadLevelEvent loadLevelEvent = new LoadLevelEvent();
        [SerializeField] public ClearLevelEvent clearLevelEvent = new ClearLevelEvent();

#if UNITY_EDITOR
        [ContextMenu("SaveLevel")]
        public void SaveLevelSpawner()
        {
            // Name for the level folder
            string levelPath = "Level" + _world + '-' + _level;

            if (!AssetDatabase.IsValidFolder(_basePath + "/" + levelPath))
                AssetDatabase.CreateFolder(_basePath, levelPath);

            // Full path for this level
            levelPath = _basePath + "/" + levelPath;

            // Set path in the scriptable for all Managers to use
            _levelSpawnScriptable.path = levelPath;

            // Set level in the scriptable for all Managers to use
            _levelSpawnScriptable.world = _world;
            _levelSpawnScriptable.level = _level;

            saveLevelEvent.Invoke(_levelSpawnScriptable);
        }

        [ContextMenu("LoadLevel")]
        public void LoadLevelSpawner()
        {
            // Set level in the scriptable for all Managers to use
            _levelSpawnScriptable.world = _world;
            _levelSpawnScriptable.level = _level;

            if (!_levelSpawnScriptable.LevelExist())
            {
                Debug.Log("No Level To Load");
                return;
            }

            loadLevelEvent.Invoke(_levelSpawnScriptable);
        }
        
        [ContextMenu("ClearLevel")]
        public void ClearLevelSpawner()
        {
            clearLevelEvent.Invoke();
        }
#endif
        [System.Serializable]
        public class SaveLevelEvent : UnityEvent<LevelSpawnScriptable> { }

        [System.Serializable]
        public class LoadLevelEvent : UnityEvent<LevelSpawnScriptable> { }

        [System.Serializable]
        public class ClearLevelEvent : UnityEvent { }
    }
}