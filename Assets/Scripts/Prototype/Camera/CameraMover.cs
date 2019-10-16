using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace Prototype.Camera
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
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
        private CinemachineVirtualCamera _camera;

        #endregion

        #region MonoBehaviour Callbacks

        void Start()
        {
            _camera = GetComponent<CinemachineVirtualCamera>();
        }

        // Update is called once per frame
        void Update()
        {
            /**
             * TODO: Optimier cette merde
             */
            if (_camera.Follow) return;
            FreeMove();
        }

        private void FreeMove()
        {
            _nextCameraMovements = Vector3.zero; //Par défaut la caméra ne bouge pas


            _nextCameraMovements += scrollSpeed * Input.GetAxis("Mouse ScrollWheel") * transform.forward;


            //Les champs suivants vont regarder si la souris est dans une zine morte
            //de l'écran et calculer un vecteur de déplacement en conséquence

            if (Input.mousePosition.x < 0 + deadZone)
            {
                _nextCameraMovements -= transform.right * moveSpeed;
            }

            if (Input.mousePosition.x > Screen.width - deadZone)
            {
                _nextCameraMovements += transform.right * moveSpeed;
            }

            if (Input.mousePosition.y < 0 + deadZone)
            {
                _nextCameraMovements += Vector3.back * moveSpeed;
            }

            if (Input.mousePosition.y > Screen.height - deadZone)
            {
                _nextCameraMovements += Vector3.forward * moveSpeed;
            }
        }

        private void LateUpdate()
        {
            
            //On verifie que la caméra ne follow rien
            
            
            //On applique le mouvement calculer precedement
            transform.position += _nextCameraMovements*Time.fixedDeltaTime;
        }

        #endregion
        
    }
}
