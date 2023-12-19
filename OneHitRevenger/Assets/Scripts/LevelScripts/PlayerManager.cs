using PlayerScripts;
using UnityEditor;
using UnityEngine;

namespace LevelScripts
{
    public class PlayerManager : MonoBehaviour
    {
        // All functions are called from LevelManager Events

        public void Save(LevelSpawnScriptable levelScriptable)
        {
            GameObject player = GetComponentInChildren<PlayerController>().gameObject;

            PlayerSpawnScriptable spawner = ScriptableObject.CreateInstance<PlayerSpawnScriptable>();
            spawner.InitSpawner(PrefabUtility.GetCorrespondingObjectFromOriginalSource(player), player.transform.position);

            AssetDatabase.CreateAsset(spawner, levelScriptable.path + "/" + "PlayerSpawner.asset");

            levelScriptable.SaveLevelSpawner(spawner);
        }

        public void Load(LevelSpawnScriptable levelScriptable)
        {
            Clear();

            PlayerSpawnScriptable spawner = (PlayerSpawnScriptable)levelScriptable.GetLevelSpawner(typeof(PlayerSpawnScriptable));

            GameObject go = Instantiate(spawner.playerPrefab, spawner.playerPosition, Quaternion.identity, transform);

            // Reconnect Prefab to Save/Load more efficiently
            ConvertToPrefabInstanceSettings settings = new ConvertToPrefabInstanceSettings();
            PrefabUtility.ConvertToPrefabInstance(go, spawner.playerPrefab, settings, InteractionMode.AutomatedAction);
        }

        public void Clear()
        {
            for (int i = transform.childCount; i > 0; i--)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
        }
    }
}