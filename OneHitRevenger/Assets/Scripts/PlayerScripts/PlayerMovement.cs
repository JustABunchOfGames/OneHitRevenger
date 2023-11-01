using UnityEngine;

namespace PlayerScripts
{
    public class PlayerMovement : MonoBehaviour
    {
        private CharacterController _controller;
        private Camera _camera;

        private Vector3 _moveDir;
        private Vector3 _lookDir;

        // Stop & Restart Movement (for other action)
        private bool _stopped;


        [SerializeField] private float _moveSpeed;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            _camera = Camera.main;

            _moveDir = Vector3.zero;
            _lookDir = Vector3.zero;

            _stopped = false;
        }

        public void Move(Vector2 newMoveDir)
        {

            _moveDir.x = newMoveDir.x;
            _moveDir.z = newMoveDir.y;
        }

        public void Stop(bool stopped)
        {
            // Movement stopped => Other actions are performed
            _stopped = stopped;
        }

        public void Look(Vector2 newLook)
        {
            _lookDir = _camera.ScreenToWorldPoint(newLook);
            _lookDir.y = 1f;
        }

        private void Update()
        {
            if (_stopped)
            {
                Time.timeScale = 1f;
                return;
            }
            else
            {
                if (_moveDir == Vector3.zero)
                    Time.timeScale = 0f;
                else
                    Time.timeScale = 1f;
            }

            _controller.Move(_moveDir * _moveSpeed * Time.deltaTime);

            transform.LookAt(_lookDir);
        }
    }
}