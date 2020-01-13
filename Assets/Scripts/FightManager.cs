using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{

    [SerializeField] public List<ChampionController> champions;

    [SerializeField] protected GameObject[] team1;
    [SerializeField] protected GameObject[] team2;

    [SerializeField] public int indiceChampionCourant;

    // Start is called before the first frame update
    void Start()
    {
        team1 = GameObject.FindGameObjectsWithTag("team1");
        team2 = GameObject.FindGameObjectsWithTag("team2");

        foreach (GameObject champion in team1)
        {
            champions.Add(champion.GetComponent<ChampionController>());
        }
        foreach (GameObject champion in team2)
        {
            champions.Add(champion.GetComponent<ChampionController>());
        }

        champions.Sort(Comparer<ChampionController>.Default);

        indiceChampionCourant = 0;
    }

    public List<ChampionController> getTeam1()
    {
        List<ChampionController> listTeam1 = new List<ChampionController>();
        foreach (GameObject champion in team1)
        {
            listTeam1.Add(champion.GetComponent<ChampionController>());
        }
        return listTeam1;
    }

    public List<ChampionController> getTeam2()
    {
        List<ChampionController> listTeam2 = new List<ChampionController>();
        foreach (GameObject champion in team2)
        {
            listTeam2.Add(champion.GetComponent<ChampionController>());
        }

        return listTeam2;
    }
    
    public int getIndiceChampionCourant()
    {
        return indiceChampionCourant;
    }

    public void setIndiceChampionCourant(int indice)
    {
        indiceChampionCourant = indice;
    }

    // Update is called once per frame
    void Update()
    {
        // Essayer de faire un wait() d'un click avec le raycast -> Demander à Virgile
        // Une fois la cible et le sort choisi -> Appel à la méthode de sort du champion
    }
}
