using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSpace
{
    public class CollisionScript : MonoBehaviour
    {
        #region Public/Private Fields


        [Header("~~~Manager Comunication~~~")]
        [SerializeField]
        PlayerManager playerScript;

        [Header("~~~Ground Check~~~")] private bool _isGrounded;
        public Transform GroundChecker;
        public LayerMask groundMask;
        [SerializeField] private float _groundDistance = 0.4f; //Default is 0.4f


        public bool IsGrounded { get => _isGrounded; }
        #endregion

        #region MonoBehaviour Routines

        private void Start()
        {
            
        }
        private void Update()
        {
            CheckForGround();
        }

        #endregion

        #region Helper Routines

        private void CheckForGround()
        {
            _isGrounded = Physics.CheckSphere(GroundChecker.position, _groundDistance, groundMask);
            if (_isGrounded && playerScript.movementScript.velocity.y < 0)
                playerScript.movementScript.velocity.y = -10f;
        }

        #endregion
    }
}
