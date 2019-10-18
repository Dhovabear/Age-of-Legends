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
        private Vector3 selRectBasDroite;

        private Vector3 TL,TR,BR,BL;

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
                
                UiSelSquareFirstPos = Input.mousePosition;
            }



            if (Input.GetMouseButton(0))
            {
                
                if (Time.time - clickTime >= clickDelay)
                {
                    SourisMaintenu = true;
                    UIselectionSquare.SetActive(true);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                CameraMover.currentInstance.canMove = true;
                SourisMaintenu = false;
                UIselectionSquare.SetActive(false);
                if (Time.time - clickTime <= clickDelay)
                {
                    /**
                     * TODO: Action a faire en cas de simple clique
                     */
                    if (Physics.Raycast(UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition), out hit,
                        float.PositiveInfinity))
                    {
                        if (hit.transform.name.Equals("Plane"))
                        {
                            Objectif ordre = new Objectif(hit.point,"Go here");
                            foreach (Unite unite in selectedUnites)
                            {
                                unite.giveOrder(ordre);
                            }

                            return;
                        }
                        
                        if (Input.GetButton("MultiSelect"))
                        {
                            selectedUnites.Add((hit.transform.GetComponent<Unite>()));
                            CreateIndicator(hit.transform.GetComponent<Unite>());
                        }
                        else
                        {
                            foreach (GameObject ind in selectionIndics){ Destroy(ind,0.01f);}
                            selectionIndics.Clear();
                            selectedUnites.Clear();
                            selectedUnites.Add(hit.transform.GetComponent<Unite>());
                            CreateIndicator(hit.transform.GetComponent<Unite>());
                        }
                    }
                }
                
                //SourisMaintenu = false;
                
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

                TL = new Vector3(milieuRect.x-(tailleX/2),milieuRect.y-(tailleY/2),0);
                TR = new Vector3(milieuRect.x + (tailleX/2),milieuRect.y - (tailleY/2),0);
                BR = new Vector3(milieuRect.x + (tailleX/2), milieuRect.y + (tailleY/2),0);
                BL = new Vector3(milieuRect.x - (tailleX/2),milieuRect.y - (tailleY/2),0);
                
                if(Physics.Raycast(UnityEngine.Camera.main.ScreenPointToRay(TL),out hit,float.PositiveInfinity,11)){
                    TL = hit.point;
                }

                if(Physics.Raycast(UnityEngine.Camera.main.ScreenPointToRay(TR),out hit,float.PositiveInfinity,11)){
                    TR = hit.point;
                }

                if(Physics.Raycast(UnityEngine.Camera.main.ScreenPointToRay(BR),out hit,float.PositiveInfinity,11)){
                    BR = hit.point;
                }

                if(Physics.Raycast(UnityEngine.Camera.main.ScreenPointToRay(BL),out hit,float.PositiveInfinity,11)){
                    BL = hit.point;
                }

            

                foreach(Unite unite in Unite.AllUnites){
        

                }

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
