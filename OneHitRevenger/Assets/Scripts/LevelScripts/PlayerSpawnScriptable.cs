using UnityEngine;

namespace LevelScripts
{
    public class PlayerSpawnScriptable : ScriptableObject
    {
        [SerializeField] private GameObject _playerPrefab;
        public GameObject playerPrefab { get { return _playerPrefab; } private set { } }

        [SerializeField] private Vector3 _playerPosition;
        public Vector3 playerPosition { get { return _playerPosition; } private set { } }

        public void InitSpawner(GameObject playerPrefab, Vector3 playerPosition)
        {
            _playerPrefab = playerPrefab;
            _playerPosition = playerPosition;
        }
    }
}