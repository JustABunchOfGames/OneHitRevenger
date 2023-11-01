using UnityEngine;

namespace EnemyScripts
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private float _speed;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public float Move()
        {
            Vector3 targetPosition = _playerTransform.position;
            Vector3 currentPosition = transform.position;

            float distance = Vector3.Distance(currentPosition, targetPosition);

            Vector3 direction = targetPosition - currentPosition;
            direction.Normalize();

            _rigidbody.MovePosition(currentPosition + (direction * _speed * Time.deltaTime));

            transform.LookAt(targetPosition);

            return distance;
        }
    }
}