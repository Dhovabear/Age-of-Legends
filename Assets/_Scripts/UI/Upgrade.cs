using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "newUpgrade" , menuName = "Upgrade")]

public class Upgrade : ScriptableObject
{
    [Header("Détails")]
    
    public Sprite logo;

    public string nom;

    public string description;


    [Header("Effets")]

    public int uniteCost;

    public int uniteSpeed;

    public int uniteCapacity;

    public int HeroDamageBonus;

    public int HeroLifeBonus;

    public int HeroDefenseBonus;

    public int HeroUltiBonus; //pour charger de tant de points d'ultime 'par tour ou attaque


    [Header("Couts")] 
    
    public int mana;

    public int cristaux;

    [FormerlySerializedAs("tempPrière")] public int tempPriere; //uniquement pour temple
    

}
