using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Unitees
{
    public class UniteManager : MonoBehaviour
    {
        // Start is called before the first frame update
        private List<Unite> selectedUnites;
        private List<GameObject> selectionIndics;

        private void Start()
        {
            selectedUnites = new List<Unite>();
            selectionIndics = new List<GameObject>();
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition),
                    out hit, float.PositiveInfinity))
                {
                    Debug.Log(hit.transform.name);
                    if (hit.transform.name == "Plane")
                    {
                        foreach (Unite unite in selectedUnites)
                        {
                            unite.giveOrder(new Objectif(hit.point,"Go here !"));
                        }

                        return;
                    }
                    Unite obj = hit.transform.gameObject.GetComponent<Unite>();
                    if (!obj) return;
                    if (Input.GetButton("MultiSelect"))
                    {
                        selectedUnites.Add(obj);
                        GameObject o = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("div/SelectIndicator"),obj.transform);
                        o.transform.position = obj.transform.position + Vector3.down;
                        o.transform.localScale = obj.transform.localScale*2;
                        o.transform.localScale -= new Vector3(0,o.transform.localScale.y*0.97f,0f);
                        selectionIndics.Add(o);
                    }
                    else
                    {
                        foreach(GameObject ob in selectionIndics){
                            Destroy(ob,0.01f);
                        }
                        selectionIndics.Clear();
                        selectedUnites.Clear();
                        selectedUnites.Add(obj);
                        GameObject o = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("div/SelectIndicator"),obj.transform);
                        o.transform.position = obj.transform.position + Vector3.down;
                        o.transform.localScale = obj.transform.localScale*2;
                        o.transform.localScale -= new Vector3(0,o.transform.localScale.y*0.97f,0f);
                        selectionIndics.Add(o);
                    }
                }
            }
        }
    }
}
