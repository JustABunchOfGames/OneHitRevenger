using CharacterScripts;
using UnityEngine;

namespace EnemyScripts
{
    public class EnemyMovement : CharacterMovement
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private float _speed;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public float Move()
        {
            if (_playerTransform == null)
                return 100f;

            Vector3 targetPosition = _playerTransform.position;
            Vector3 currentPosition = transform.position;

            float distance = Vector3.Distance(currentPosition, targetPosition);
            Debug.Log("distance :" + distance);

            Vector3 direction = targetPosition - currentPosition;
            direction.Normalize();

            _rigidbody.MovePosition(currentPosition + (direction * _speed * Time.deltaTime));

            transform.LookAt(targetPosition);

            moveEvent.Invoke(true); // Animation

            return distance;
        }
    }
}