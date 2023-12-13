using PlayerScripts;
using UnityEditor;
using UnityEngine;

namespace LevelScripts
{
    public class PlayerManager : MonoBehaviour
    {
        public PlayerSpawnScriptable GetPlayerSpawn(string path)
        {
            GameObject player = GetComponentInChildren<PlayerController>().gameObject;

            PlayerSpawnScriptable spawner = ScriptableObject.CreateInstance<PlayerSpawnScriptable>();
            spawner.InitSpawner(PrefabUtility.GetCorrespondingObjectFromOriginalSource(player), player.transform.position);

            AssetDatabase.CreateAsset(spawner, path + "/" + "PlayerSpawner.asset");

            return spawner;
        }

        public Transform SetPlayerSpawn(PlayerSpawnScriptable spawner)
        {
            ClearPlayerSpawn();

            GameObject go = Instantiate(spawner.playerPrefab, spawner.playerPosition, Quaternion.identity, transform);

            // Reconnect Prefab to Save/Load more efficiently
            ConvertToPrefabInstanceSettings settings = new ConvertToPrefabInstanceSettings();
            PrefabUtility.ConvertToPrefabInstance(go, spawner.playerPrefab, settings, InteractionMode.AutomatedAction);

            return go.transform;
        }

        public void ClearPlayerSpawn()
        {
            for (int i = transform.childCount; i > 0; i--)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
        }
    }
}