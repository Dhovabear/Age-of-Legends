using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCost
{

    public static BuildingCost[] coutsBuilds = new BuildingCost[5] {
        new BuildingCost(300, 0),
        new BuildingCost(0,300),
        new BuildingCost(1500,500),
        new BuildingCost(2000,1000),
        new BuildingCost(2000,2000)
    };
    
    public int manaCosts;
    public int cristalCosts;

    public BuildingCost(int mana , int cristal)
    {
        this.manaCosts = mana;
        this.cristalCosts = cristal;
    }
}
