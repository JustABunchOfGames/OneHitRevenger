using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerScripts
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private PlayerCombat _playerCombat;

        private bool _canMove;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerCombat = GetComponent<PlayerCombat>();

            CanMove(true);

            PlayerInput input = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerInput>();

            if (input != null)
            {
                input.actions.FindAction("Move").performed += Move;
                input.actions.FindAction("Move").canceled += Move;

                input.actions.FindAction("Look").performed += Look;

                input.actions.FindAction("Grab").performed += Grab;

                input.actions.FindAction("Attack").performed += Attack;
            }
        }

        private void Move(InputAction.CallbackContext context)
        {
            _playerMovement.Move(context.ReadValue<Vector2>());
        }

        private void Look(InputAction.CallbackContext context)
        {
            _playerMovement.Look(context.ReadValue<Vector2>());
        }

        private void Grab(InputAction.CallbackContext context)
        {
            // Use it again when we have a grab animation
            // CanMove(false);
            _playerCombat.Grab();
        }

        private void Attack(InputAction.CallbackContext context)
        {
            _playerCombat.Attack();
        }

        public void CanMove(bool canMove)
        {
            _canMove = canMove;

            _playerMovement.Stop(!_canMove);
        }
    }
}