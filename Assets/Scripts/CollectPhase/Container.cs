using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Prototype.Unitees;
using Prototype.Camera;

[RequireComponent(typeof(Collider))]
public abstract class Container : MonoBehaviour , IFocusable
{

    protected List<Unite> uniteInZone;
    [SerializeField]protected Text infoDisp;


    #region MonoBehaviour callbacks
    void Start(){
        uniteInZone = new List<Unite>();
        infoDisp = GameManager.current.infoField;
        initialise();
    }

    void Update(){

    }
    #endregion

    public abstract void initialise();

    #region Triggers Callbacks

    void OnTriggerEnter(Collider other){
        Unite un;
        if(!(un = other.gameObject.GetComponent<Unite>())){return;}
        uniteInZone.Add(un);
    }

    void OnTriggerExit(Collider other){
        Unite un;
        if(!(un = other.gameObject.GetComponent<Unite>())){return;}
        uniteInZone.Remove(un);
    }

    #endregion

    #region OnMouse callbacks

    void OnMouseEnter(){
        infoDisp.gameObject.SetActive(true);
    }

    void OnMouseOver(){
        displayInfo(infoDisp);
    }

    void OnMouseExit(){
        infoDisp.gameObject.SetActive(false);
    }

    #endregion

    public abstract void displayInfo(Text text);
    

    
}