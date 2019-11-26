using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Prototype.Unitees;
using Prototype.Camera;


enum TypeRes
{
    Cristaux,
    Mana
}

[RequireComponent(typeof(Collider))]
public class RessourcesContainer : MonoBehaviour, IFocusable
{

    public static List<RessourcesContainer> instances;
    #region Private SerializeFields

    [SerializeField]private int resPerSecondPerUnit = 0;
    [SerializeField] private int regenRes;
    [SerializeField] private int maxRes;
    [SerializeField]private Text infoToDisplay;
    private int ResCount;
    [SerializeField]private TypeRes _typeRes;
    
    #endregion

    #region private Fields

    private List<Unite> pInZone;
    private bool collect = false;

        
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        pInZone = new List<Unite>();
        ResCount = maxRes;

        if (instances == null)
        {
            instances = new List<RessourcesContainer>();
        }
        instances.Add(this);
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
        
        if (collect == false)
        {
            collect = true;
        }
        
    }

    void OnTriggerExit(Collider other){
        Unite un;
        if(!(un = other.gameObject.GetComponent<Unite>())){return;}
        pInZone.Remove(un);
        if (pInZone.Count == 0)
        {
            collect = false;
        }
    }

    #endregion

    #region OnMouseCallbacks     
    
    void OnMouseEnter(){
        infoToDisplay.gameObject.SetActive(true);
        
    }

    void OnMouseOver()
    {
        infoToDisplay.text = "";
        RectTransform rt = infoToDisplay.gameObject.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(Input.mousePosition.x + 80,Input.mousePosition.y);

        

        if (ResCount > 1000)
        {
            int nbK = ResCount / 1000;
            infoToDisplay.text += nbK + "k " + _typeRes.ToString() + " restants\n";
        }
        else
        {
            infoToDisplay.text += ResCount + " " + _typeRes.ToString() + " restants\n";
        }
        
        infoToDisplay.text += resPerSecondPerUnit + " " + _typeRes.ToString() + "/s\n" + pInZone.Count + "collecting";
    }

    void OnMouseExit(){
        infoToDisplay.gameObject.SetActive(false);
    }

    #endregion

    public void UpdateRessources()
    {

        if ((ResCount + regenRes) < maxRes)
        {
            ResCount += regenRes;
        }
        
        if (!collect) return;
        

        int resToEarn = resPerSecondPerUnit * pInZone.Count;
        resToEarn = (ResCount - resToEarn > 0) ? resToEarn : Math.Min(ResCount,resToEarn);
        ResCount -= resToEarn;

        if (_typeRes == TypeRes.Mana)
        {
            GameManager.current.GetPlayerManager().EarnMana(resToEarn);
        }
        else
        {
            GameManager.current.GetPlayerManager().EarnCristal(resToEarn);
        }
    }
}
