using System.Collections;
using System;
using System.Collections.Generic;
using Prototype.Unitees;
using UnityEngine.UI;
using UnityEngine;

public class RessourcesStorage : Container
{

    public static List<RessourcesStorage> instances;

    [SerializeField] private int MaxRessources;
    [SerializeField] private TypeRes type;

    private int ResCount;
    private const int resPerSec = 3;

    public override void initialise()
    {
        Debug.Log("ResStor");
        //Si la liste des instances est nulle alors on la crée
        if (instances == null){instances = new List<RessourcesStorage>();}

        //On s'ajoute a la liste des instances
        instances.Add(this);

        //On initialise les ressources
        ResCount = MaxRessources;
    }

    

    public void UpdateRessources(){

        Debug.Log("On passe la ");
        foreach(Unite u in uniteInZone ){

            int resToGain = Math.Min(u.CanCarry(),Math.Min(resPerSec , ResCount));
            ResCount += resToGain;
            
            if(u.GetResType() != type){
                return;
            }

            //pas très optmisé
            if(type == TypeRes.Cristaux){
                GameManager.current.GetPlayerManager().EarnCristal(resToGain);
            }else{
                GameManager.current.GetPlayerManager().EarnMana(resToGain);
            }
            
            u.EarnRessources((type == TypeRes.Cristaux),-resToGain);
            u.CheckIfImFull();
        }
    }

    public override void displayInfo(Text text){
        text.text = "";
    }

}
