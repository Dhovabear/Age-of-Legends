using System;
using System.Collections;
using System.Collections.Generic;
using Prototype.Camera;
using UnityEngine;
using UnityEngine.Diagnostics;

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

        public GameObject indTL;
        public GameObject indTR;
        public GameObject indBR;
        public GameObject indBL;
        
        private void Start()
        {
            selectedUnites = new List<Unite>();
            selectionIndics = new List<GameObject>();
            UIselectionSquare = GameObject.Find("SelectionSquare");
            UIselectionSquare.SetActive(false);
        }

        public void Update()
        {
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
                    
                    if (Physics.Raycast(UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition), out hit,
                        float.PositiveInfinity))
                    {
                        if (hit.transform.tag.Equals("sol"))
                        {
                            Objectif ordre = new Objectif(hit.point,"Go here");
                            
                            
                            foreach (Unite unite in selectedUnites)
                            {
                                if (unite == null) continue;
                                unite.giveOrder(ordre);
                            }

                            return;
                        }

                        ObjectifContainer obj;
                        if ((obj = hit.transform.gameObject.GetComponent<ObjectifContainer>()) != null)
                        {
                            foreach (Unite unite in selectedUnites)
                            {
                                if (unite == null) continue;
                                unite.giveOrder(obj.GetObjectif());
                            }
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
                
                
                clickTime = 0f;
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

                TL = new Vector3(milieuRect.x-(tailleX/2),milieuRect.y+(tailleY/2),0);
                TR = new Vector3(milieuRect.x + (tailleX/2),milieuRect.y + (tailleY/2),0);
                BR = new Vector3(milieuRect.x + (tailleX/2), milieuRect.y - (tailleY/2),0);
                BL = new Vector3(milieuRect.x - (tailleX/2),milieuRect.y - (tailleY/2),0);
                
                if(Physics.Raycast(UnityEngine.Camera.main.ScreenPointToRay(TL),out hit,float.PositiveInfinity,1 << 11)){
                    TL = hit.point;
                    indTL.transform.position = TL;
                }

                if(Physics.Raycast(UnityEngine.Camera.main.ScreenPointToRay(TR),out hit,float.PositiveInfinity,1 << 11)){
                    TR = hit.point;
                    indTR.transform.position = TR;
                }

                if(Physics.Raycast(UnityEngine.Camera.main.ScreenPointToRay(BR),out hit,float.PositiveInfinity,1 << 11)){
                    BR = hit.point;
                    indBR.transform.position = BR;
                }

                if(Physics.Raycast(UnityEngine.Camera.main.ScreenPointToRay(BL),out hit,float.PositiveInfinity,1 << 11)){
                    BL = hit.point;
                    indBL.transform.position = BL;
                }

            

                foreach(Unite unite in Unite.AllUnites){
                    if (!selectedUnites.Contains(unite))
                    {
                        if (isInRectangle(unite.transform.position))
                        {
                            selectedUnites.Add(unite);
                            CreateIndicator(unite);
                        }
                    }
                    else
                    {
                        if (!isInRectangle(unite.transform.position))
                        {
                            selectedUnites.Remove(unite);
                            if ( unite.transform.Find("SelectIndicator(Clone)"))
                            {
                                Destroy( unite.transform.Find("SelectIndicator(Clone)").gameObject,0.001f);
                                //Debug.Log(unite.transform.name);
                            }
                        }
                    }
                }

            }
        }

        private bool isInRectangle(Vector3 pt)
        {

            if (isInTriangle(pt, TL,BL,TR))
            {
                return true;
            }

            if (isInTriangle(pt, BL, BR, TR))
            {
                return true;
            }

            return false;
        }

        private bool isInTriangle(Vector3 p,Vector3 p1, Vector3 p2 , Vector3 p3)
        {
            bool estDansTriangle = false;

            float denom = ((p2.z - p3.z) * (p1.x - p3.x) + (p3.x - p2.x) * (p1.z - p3.z));
            
            float a = ((p2.z - p3.z) * (p.x - p3.x) + (p3.x - p2.x) * (p.z - p3.z)) / denom;
            float b = ((p3.z - p1.z) * (p.x - p3.x) + (p1.x - p3.x) * (p.z - p3.z)) / denom;
            float c = 1 - a - b;
            
            if (a >= 0f && a <= 1f && b >= 0f && b <= 1f && c >= 0f && c <= 1f)
            {
                estDansTriangle = true;
            }
            
            return estDansTriangle;
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
