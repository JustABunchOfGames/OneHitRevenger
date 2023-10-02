using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerScripts
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private PlayerCombat _playerCombat;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerCombat = GetComponent<PlayerCombat>();

            PlayerInput input = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerInput>();

            if (input != null)
            {
                input.actions.FindAction("Move").performed += Move;
                input.actions.FindAction("Move").canceled += Move;

                input.actions.FindAction("Look").performed += Look;

                input.actions.FindAction("Grab").performed += Grab;
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
            _playerCombat.Grab();
        }
    }
}