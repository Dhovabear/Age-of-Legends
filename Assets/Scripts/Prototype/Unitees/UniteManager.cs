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

        private void Start()
        {
            selectedUnites = new List<Unite>();
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
                    }
                    else
                    {
                        selectedUnites.Clear();
                        selectedUnites.Add(obj);
                    }
                }
            }
        }
    }
}
