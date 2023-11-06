using CharacterScripts;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerMovement : CharacterMovement
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
                // We're directing the attack on the right direction in case the player didn't stop before attacking
                if (Time.timeScale == 1f)
                    transform.LookAt(_lookDir);

                Time.timeScale = 1f;
                return;
            }
            else
            {
                if (_moveDir == Vector3.zero)
                {
                    transform.LookAt(_lookDir);

                    Time.timeScale = 0f;
                    moveEvent.Invoke(false);
                }
                else
                {
                    transform.forward = _moveDir;

                    Time.timeScale = 1f;
                    moveEvent.Invoke(true);
                }
            }

            _controller.Move(_moveDir * _moveSpeed * Time.deltaTime);
        }
    }
}