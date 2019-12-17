using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{

    [SerializeField] private List<ChampionController> champions;
    
    [SerializeField] protected GameObject[] team1;
    [SerializeField] protected GameObject[] team2;


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
        
        champions.Sort();
    }

    // Update is called once per frame
    void Update()
    {
        // Essayer de faire un wait() d'un click avec le raycast -> Demander à Virgile
        // Une fois la cible et le sort choisi -> Appel à la méthode de sort du champion
    }
}
