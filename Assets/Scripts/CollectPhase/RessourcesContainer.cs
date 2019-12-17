using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Prototype.Unitees;
using Prototype.Camera;


[RequireComponent(typeof(Collider))]
public class RessourcesContainer : Container
{

    public static List<RessourcesContainer> instances;
    #region Private SerializeFields

    [SerializeField]private int resPerSecondPerUnit = 0;
    [SerializeField] private int regenRes;
    [SerializeField] private int maxRes;
    private int ResCount;
    [SerializeField]private TypeRes _typeRes;
    
    #endregion

    // Start is called before the first frame update
    public override void initialise()
    {
        Debug.Log("ResContInit");
        //Si la liste des instances est nulle alors on la crée
        if (instances == null){instances = new List<RessourcesContainer>();}

        //On s'ajoute a la liste des instances
        instances.Add(this);

        //On initialise les ressources
        ResCount = maxRes;
    }
    

    #region OnMouseCallbacks     
    

    public override void displayInfo(Text text){
        text.text = "";
        RectTransform rt = text.gameObject.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(Input.mousePosition.x + 80,Input.mousePosition.y);


        text.text += (ResCount >= 1000)? ResCount/1000 + "," + (ResCount % 1000) / 100 + "k" : ResCount.ToString();
        text.text += " " + _typeRes.ToString()+"\n";
        text.text += resPerSecondPerUnit + " " + _typeRes.ToString() + "/s\n" + uniteInZone.Count + "collecting";
    }

    #endregion

    public void UpdateRessourcesV2(){

        ResCount = (ResCount + regenRes < maxRes)? ResCount+regenRes : ResCount + (maxRes - ResCount);

        foreach(Unite u in uniteInZone){
            int resToEarn = Math.Min(u.CanCarry(),Math.Min(resPerSecondPerUnit,ResCount));
            ResCount -= resToEarn;
            u.EarnRessources((_typeRes == TypeRes.Cristaux),resToEarn);
            u.CheckIfImFull();
        }
    }

    #region getter and setter

    public int GetMaxRes(){
        return maxRes;
    }

    public int GetResCount(){
        return ResCount;
    }

    #endregion
}
