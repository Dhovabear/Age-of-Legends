﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Prototype.Unitees;
using Prototype.Camera;

[RequireComponent(typeof(Collider))]
public class RessourcesContainer : MonoBehaviour, IFocusable
{

    #region Private SerializeFields

    [SerializeField]private int resPerSecondPerUnit = 0;
    [SerializeField]private Text infoToDisplay;
        
    #endregion

    #region private Fields

    private List<Unite> pInZone;

        
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        pInZone = new List<Unite>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region OnTriggerCallbacks

    void OnTriggerEnter(Collider other)
    {
        Unite un;
        if(!(un = other.gameObject.GetComponent<Unite>())){return;}
        pInZone.Add(un);
    }

    void OnTriggerExit(Collider other){
        Unite un;
        if(!(un = other.gameObject.GetComponent<Unite>())){return;}
        pInZone.Remove(un);
    }

    #endregion

    #region OnMouseCallbacks     
    
    void OnMouseEnter(){
        infoToDisplay.gameObject.SetActive(true);
        
    }

    void OnMouseOver(){
        RectTransform rt = infoToDisplay.gameObject.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(Input.mousePosition.x + 80,Input.mousePosition.y);
        infoToDisplay.text = resPerSecondPerUnit + " r/s\n" + pInZone.Count + "collecting";
    }

    void OnMouseExit(){
        infoToDisplay.gameObject.SetActive(false);
    }

    #endregion
}
