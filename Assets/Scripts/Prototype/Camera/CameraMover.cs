using System;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace Prototype.Camera
{
    public class CameraMover : MonoBehaviour
    {
        #region Variables publiques

        
        [Range(0.5f,10f)]
        public float moveSpeed;

        [Range(1f,20f)]
        public float scrollSpeed;
        /*
         *la variable deadzone va stocker la distance de la
         * souris d'un bord pour faire bouger la camera 
         */
        public int deadZone;
        
        
        
        #endregion

        #region Variables privées

        private Vector3 _nextCameraMovements;

        #endregion
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            _nextCameraMovements = Vector3.zero;
            
            if (Input.mousePosition.x < 0 + deadZone)
            {
                _nextCameraMovements -= transform.right*moveSpeed;
            }

            if (Input.mousePosition.x > Screen.width - deadZone)
            {
                _nextCameraMovements += transform.right*moveSpeed;
            }

            if (Input.mousePosition.y < 0 + deadZone)
            {
                _nextCameraMovements += Vector3.back*moveSpeed;
            }

            if (Input.mousePosition.y > Screen.height - deadZone)
            {
                _nextCameraMovements += Vector3.forward*moveSpeed;
            }

            _nextCameraMovements += scrollSpeed * Input.GetAxis("Mouse ScrollWheel") * transform.forward;
        }

        private void FixedUpdate()
        {
            //la on va mettre les mouvements
            transform.position += _nextCameraMovements*Time.fixedDeltaTime;
        }
    }
}
