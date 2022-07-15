using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSpace
{
    public class MovementScript : MonoBehaviour
    {
        #region Public/Private Fields

        [Header("~~~Manager Comunication~~~")]
        [SerializeField]
        PlayerManager playerScript;

        [Header("~~~Vectors & Scripts~~~")] [SerializeField] private float _walkSpeed;
        [SerializeField] private float _camSensitivity;
        private float xRotation = 0f;

        [Header("~~~Phyisical Refs~~~")] private CharacterController _controller;
        public Camera Cam;
        public GameObject playerBody;

        [Header("~~~Gravity Stuff~~~")] [SerializeField] private float _gravity = -9.81f; //Default if -9.81f
        internal Vector3 velocity;
        [SerializeField] private float _jumpHeight;
        #endregion

        #region MonoBehaviour Routines
        private void Start()
        {
            _controller = GetComponent<CharacterController>();

            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            MoveYoAss();
            LookAround();
        }
        #endregion

        #region Helper Routines

        private void MoveYoAss()
        {
            Vector3 forFuckSake = Quaternion.Euler(0f, Cam.transform.eulerAngles.y, 0f) * playerScript.inputScript._direction;

            velocity.y += _gravity * Time.deltaTime;

            _controller.Move(forFuckSake * _walkSpeed * Time.deltaTime);
            _controller.Move(velocity * Time.deltaTime);
        }

        public void Jump()
        {
            if(playerScript.collisionScript.IsGrounded)
            {
                //velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
                velocity.y = _jumpHeight;
            }
        }

        private void LookAround()
        {
            float mouseX = playerScript.inputScript._viewVector.x * _camSensitivity * Time.deltaTime;
            float mouseY = playerScript.inputScript._viewVector.y * _camSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            Cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.transform.Rotate(Vector3.up * mouseX);

        }
        #endregion
    }
}

