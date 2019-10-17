using System;
using System.Collections;
using System.Collections.Generic;
using Prototype.Camera;
using UnityEngine;

namespace Prototype.Unitees
{
    public class UniteManager : MonoBehaviour
    {
        // Start is called before the first frame update
        private List<Unite> selectedUnites;
        private List<GameObject> selectionIndics;

        private GameObject UIselectionSquare;
        private Vector2 UISelSquareLastPos;
        private Vector2 UiSelSquareFirstPos;

        private Vector3 selRectOrigin;
        private Vector3 selRectSecondPoint;

        private float clickTime = 0f;
        private float clickDelay = 0.2f;

        private bool SourisMaintenu = false;
        
        private void Start()
        {
            selectedUnites = new List<Unite>();
            selectionIndics = new List<GameObject>();
            UIselectionSquare = GameObject.Find("SelectionSquare");
            UIselectionSquare.SetActive(false);
        }

        public void Update()
        {
            /**
             * TODO: Implémenter le nouveau système de selection des unitées
             */
            RaycastHit hit;
            if (Input.GetMouseButtonDown(0))
            {
                clickTime = Time.time;//On stocke le temps de click
                UIselectionSquare.SetActive(true);
                UiSelSquareFirstPos = Input.mousePosition;
                /*if (Physics.Raycast(UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition), out hit,
                    float.PositiveInfinity))
                {
                    selRectOrigin = hit.point;
                }*/
            }



            if (Input.GetMouseButton(0))
            {
                UIselectionSquare.SetActive(false);
                if (Time.time - clickTime >= clickDelay)
                {
                    SourisMaintenu = true;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (Time.time - clickTime <= clickDelay)
                {
                    /**
                     * TODO: Action a faire en cas de simple clique
                     */
                }
                
                SourisMaintenu = false;
                CameraMover.currentInstance.canMove = true;
                clickTime = 0f;
                /*if (Physics.Raycast(UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition), out hit,
                    float.PositiveInfinity))
                {
                    selRectSecondPoint = hit.point;
                }*/
            }

            if (SourisMaintenu)
            {
                RectTransform rt = UIselectionSquare.GetComponent<RectTransform>();
                CameraMover.currentInstance.canMove = false;
                UISelSquareLastPos = Input.mousePosition;
                
                //On cherche dabord le millieu du rectangle
                Vector2 milieuRect = (UiSelSquareFirstPos + UISelSquareLastPos) / 2f;

                rt.anchoredPosition = milieuRect;
                
                //On calcule la taille du carré, on met une valeur absolue car sinon ca bug
                float tailleX = Mathf.Abs(UiSelSquareFirstPos.x - UISelSquareLastPos.x);
                float tailleY = Mathf.Abs(UiSelSquareFirstPos.y - UISelSquareLastPos.y);

                
                rt.sizeDelta = new Vector2(tailleX,tailleY);
                

            }
        }

        private void CreateIndicator(Unite obj)
        {
            GameObject o =
                (GameObject) GameObject.Instantiate(Resources.Load<GameObject>("div/SelectIndicator"), obj.transform);
            o.transform.position = obj.transform.position + Vector3.down;
            o.transform.localScale = obj.transform.localScale * 2;
            o.transform.localScale -= new Vector3(0, o.transform.localScale.y * 0.97f, 0f);
            selectionIndics.Add(o);
        }
    }
}
