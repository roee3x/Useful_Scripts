using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace PlayerSpace
{
    public class InputScript : MonoBehaviour
    {
        #region Public/Private Fields


        [Header("~~~Manager Comunication~~~")]
        [SerializeField]
        PlayerManager playerScript;

        [Header("~~~Input System~~~")] private PlayerInput _playerInput;
        internal MainPlayerInput _mainPlayerInput;
        private Vector3 _inputVector;
        internal Vector3 _direction;
        private Transform _camTrans;
        internal Vector3 _viewVector;
        

        #endregion

        #region MonoBehaviour Routines

        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
            _mainPlayerInput = new MainPlayerInput();

            _mainPlayerInput.KeyboardAndMouse.Enable();
            _mainPlayerInput.KeyboardAndMouse.Jump.performed += x => playerScript.movementScript.Jump();
            _mainPlayerInput.KeyboardAndMouse.Look.performed += x => _viewVector = x.ReadValue<Vector2>();
            _camTrans = Camera.main.transform;
        }

        private void Update()
        {
            _inputVector = _mainPlayerInput.KeyboardAndMouse.Walk.ReadValue<Vector2>();
            _direction = new Vector3(_inputVector.x, 0f, _inputVector.y);
            Vector3 forFuckSake = Quaternion.Euler(0f, _camTrans.eulerAngles.y, 0f) * _direction;

        }
        #endregion

        #region Helper Routines

        private void JumpRef(InputAction.CallbackContext context)
        {
            if (context.performed && playerScript.collisionScript.IsGrounded)
                playerScript.movementScript.Jump();
        }

        #endregion
    }
}
