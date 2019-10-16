using System;
using Cinemachine;
using UnityEditor;
using UnityEngine;


namespace Prototype.Camera
{
    public class SimpleFocus : MonoBehaviour
    {
    

        /**
         * TODO: Utiliser un système de rayon pour selectionner ou non les Focusable.
         */
        private void OnMouseDown()
        {
            CameraMover.currentInstance.setFocus(transform);
        }

        private void LateUpdate()
        {
            if (Input.GetButton("Fire2")) CameraMover.currentInstance.stopFocus();
        }
    }
}
