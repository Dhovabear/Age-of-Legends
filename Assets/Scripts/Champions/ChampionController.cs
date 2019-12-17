﻿using System.Collections.Generic;
using UnityEngine;

public class ChampionController : MonoBehaviour
{

    [SerializeField] public string Name;
    [SerializeField] public float Hp;
    [SerializeField] public float Attaque;
    [SerializeField] public float Defense;
    [SerializeField] public float Pouvoir;
    [SerializeField] public float Vitesse;
    [SerializeField] public float Heal;
    [SerializeField] public int Ultime;
    [SerializeField] public List<Effet> effets;
    [SerializeField] public int Marques = 0;
    [SerializeField] public bool peutJouerCeTour = true;


    [SerializeField] protected GameObject[] team1;
    [SerializeField] protected GameObject[] team2;

    // Start is called before the first frame update
    void Start()
    {
        team1 = GameObject.FindGameObjectsWithTag("team1");
        team2 = GameObject.FindGameObjectsWithTag("team2");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
