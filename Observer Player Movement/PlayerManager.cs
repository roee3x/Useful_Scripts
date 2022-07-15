using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MenuSpace;


namespace PlayerSpace
{
    public class PlayerManager : MonoBehaviour
    {
        #region Public/Private Fields

        [Header("~~~Script Comunication~~~")]
        [SerializeField]
        internal InputScript inputScript;

        [SerializeField]
        internal MovementScript movementScript;

        [SerializeField]
        internal CollisionScript collisionScript;

        [SerializeField]
        internal MenuManager menuManager;

        #endregion

        #region MonoBehaviour Routines

        #endregion

        #region Helper Routines

        #endregion
    }
}

