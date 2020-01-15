using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public string nom;
    public int cristaux;
    public int mana;
    public List<Object> heros;

    public PlayerData(string nom, List<Object> heros)
    {
        this.nom = nom;
        this.heros = heros;
    }
}
