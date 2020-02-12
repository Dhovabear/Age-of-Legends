using System;
using Cinemachine;
using Prototype.Unitees;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace Prototype.Camera
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraMover : MonoBehaviour
    {

        public static CameraMover currentInstance;
        
        #region Variables publiques

        
        [Range(0.5f,100f)]
        public float moveSpeed;

        [Range(1f,100f)]
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
        private CinemachineFramingTransposer _transposer;
        private bool isFocusSomething = false;
        private bool canMove = true;
        private bool isInUi; //Variable de débug qui va blocer le déblocage de la caméra si on est dans un UI
        
        #endregion

        #region MonoBehaviour Callbacks

        void Start()
        {
            _camera = GetComponent<CinemachineVirtualCamera>();
            _transposer = _camera.GetCinemachineComponent<CinemachineFramingTransposer>();
            if (!currentInstance) currentInstance = this;
        }

        // Update is called once per frame
        void Update()
        {
            /**
             * TODO: Optimier cette merde
             */

            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                if (Physics.Raycast(UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition),
                    out hit, float.PositiveInfinity))
                {
                    Debug.Log(hit.transform.name);
                    IFocusable obj = hit.transform.gameObject.GetComponent<IFocusable>();
                    if ( obj != null)
                    {
                        setFocus(hit.transform);
                        return;
                    }
                    if(isFocusSomething) stopFocus();
                    
                }
            }

            
            
            if (isFocusSomething)
            {
                FocusZoom();//calcul du zoom de focus (le mouvement est gérer par CM )
            }
            else
            { 
                FreeMove(); //calcul du prochain mouvement
            }
        }

      

        private void LateUpdate()
        {
            //On applique le mouvement calculer precedement
            if (!canMove) return;
            transform.position += _nextCameraMovements*Time.fixedDeltaTime;
        }

        #endregion

        #region Autres méthodes

        private void FreeMove()
        {
           
            _nextCameraMovements = Vector3.zero; //Par défaut la caméra ne bouge pas

            _nextCameraMovements += scrollSpeed * Input.GetAxis("Mouse ScrollWheel") * 10f*transform.forward;


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

        private void FocusZoom()
        {
            _transposer.m_CameraDistance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
            
        }

        public void setFocus(Transform t)
        {
            isFocusSomething = true;
            _camera.Follow = t;
        }

        public void stopFocus()
        {
            isFocusSomething = false;
            _camera.Follow = null;
        }

        //Les 4 fonctions qui vont suivre sont uniquement présente pour corriger un petit bug
        //Elles ajoutent plus ou moins le fait de ajouter une fonction qui gère le blocage de la camera
        //de facon prioritaire, c'est a dire que startUIComportment va bloquer la caméra mais si on ne la débloque pas 
        //a l'aide de la fonction stopUIComportment, alors on ne pourra pas la faire bouger a nouveau c'est une sorte de lock
        //NOTE: seuls les interfaces doivent utiliser cette fonction, en aucun cas un autre élément doir s'en servir!!!!!
        
        //stop bêtement les mouvements de la caméra
        public void stopCameraMovement()
        {
            canMove = false;
        }

        //Fait a nouveau bouger la caméra si on est pas dans un UI-lock
        public void resumeCameraMovement()
        {
            if (isInUi) return;
            canMove = true;
        }

        //Débute le UI-lock de la caméra
        public void startUIComportement()
        {
            isInUi = true;
            stopCameraMovement();
        }

        //Met fin au UI-lock
        public void stopUIComportement()
        {
            isInUi = false;
            resumeCameraMovement();
        }

        #endregion
    }
}
