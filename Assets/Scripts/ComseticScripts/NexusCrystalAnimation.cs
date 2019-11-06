using System;
using UnityEngine;

namespace ComseticScripts
{
    public class NexusCrystalAnimation : MonoBehaviour
    {

        #region publics Fields

        [SerializeField]private Vector3 rotationSpeed;
        [SerializeField] private float flyAmplitude;

        #endregion

        #region private fields

        private Vector3 basePosition;

        private Vector3 nextMove;

        #endregion
    
        // Start is called before the first frame update
        void Start()
        {
            basePosition = transform.position;
            nextMove = 0.01f * flyAmplitude * -transform.up;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            
            
            transform.Rotate(rotationSpeed);
            if (Math.Abs(transform.position.y - (basePosition.y - flyAmplitude)) < 0.2f)
            {
                nextMove = 0.01f * flyAmplitude * transform.up;
                Debug.Log("bas");
            }else if (Math.Abs(transform.position.y - (basePosition.y + flyAmplitude)) < 0.2f)
            {
                nextMove = 0.01f * flyAmplitude * -transform.up;
                Debug.Log("haut");
            }
            
            
            transform.Translate(nextMove);

        }
    }
}
