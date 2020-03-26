using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCost
{

    public static BuildingCost[] coutsBuilds = new BuildingCost[5] {
        new BuildingCost(300, 0,"Dépot de cristal"),
        new BuildingCost(0,300,"Dépot de mana"),
        new BuildingCost(1500,500,"Temple"),
        new BuildingCost(2000,1000,"Armurerie"),
        new BuildingCost(2000,2000,"Hotel des finances")
    };

    public String buildingName;
    public int manaCosts;
    public int cristalCosts;

    public BuildingCost(int mana , int cristal,String buildingName)
    {
        this.manaCosts = mana;
        this.cristalCosts = cristal;
        this.buildingName = buildingName;
    }
}
