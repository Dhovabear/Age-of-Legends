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
        ResCount = 0;
    }

    

    public void UpdateRessources(){

        Debug.Log("On passe la ");
        foreach(Unite u in uniteInZone ){
            
            u.CheckIfImFull();

            if(u.GetResType() != type && u.GetResCount() > 0){
                return;
            }
            
            u.SetTypeRes(type);
            
            int resToGain = Math.Min( (MaxRessources - ResCount),Math.Min(resPerSec , u.GetResCount()));
            Debug.Log("resto gain: " + resToGain);
            
            
            ResCount += resToGain;

            //pas très optmisé
            if(type == TypeRes.Cristaux){
                GameManager.current.GetPlayerManager().EarnCristal(resToGain);
            }else{
                GameManager.current.GetPlayerManager().EarnMana(resToGain);
            }
            
            u.EarnRessources((type == TypeRes.Cristaux),-resToGain);
            
        }
    }

    public override void displayInfo(Text text)
    {
        text.text = "";
        RectTransform rt = text.gameObject.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(Input.mousePosition.x + 80,Input.mousePosition.y);
        
        text.text += (ResCount >= 1000)? ResCount/1000 + "," + (ResCount % 1000) / 100 + "k" : ResCount.ToString();
        text.text += " " + type.ToString()+"\n";
        text.text += resPerSec + " " + type.ToString() + "/s\n" + uniteInZone.Count + " deposit";
    }

    public bool HasSpaceFor(){
        return (ResCount < MaxRessources);
    }

    //retire et retourne le nombre de ressources qui n'ont pas pu être retiré
    //surant l'opération (ex: on a 10 cristaux on veut en prendre 11 , la fonction renverra 1)
    public int takeRessources(int amount)
    {
        int amountToLose = Math.Min(ResCount, amount);
        ResCount -= amountToLose;
        Debug.Log(transform.name + " a normalement perdu " + amountToLose + "ressources");
        return amount - amountToLose;
    }
}
