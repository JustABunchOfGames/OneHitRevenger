using UnityEngine;

namespace PlayerScripts
{
    public class PlayerMovement : MonoBehaviour
    {
        private CharacterController _controller;
        private Camera _camera;

        private Vector3 _moveDir;
        private Vector3 _lookDir;

        [SerializeField] private float _moveSpeed;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            _camera = Camera.main;

            _moveDir = Vector3.zero;
            _lookDir = Vector3.zero;
        }

        public void Move(Vector2 newMoveDir)
        {
            _moveDir.x = newMoveDir.x;
            _moveDir.z = newMoveDir.y;
        }

        public void Look(Vector2 newLook)
        {
            _lookDir = _camera.ScreenToWorldPoint(newLook);
            _lookDir.y = 1f;
        }

        private void Update()
        {
            _controller.Move(_moveDir * _moveSpeed * Time.deltaTime);

            transform.LookAt(_lookDir);
        }
    }
}