using System;
using System.Collections;
using System.Collections.Generic;
using Fight;
using UnityEngine;

public class FightManager : MonoBehaviour
{

    [SerializeField] public List<ChampionController> champions;

    [SerializeField] protected GameObject[] team1;
    [SerializeField] protected GameObject[] team2;

    [SerializeField] public int indiceChampionCourant;

    private GameObject[] leftInstanciatePlace = new GameObject[3];
    private GameObject[] rightInstanciatePlace = new GameObject[3];

    private SelectionPersonnage sp;


    private List<GameObject> tempPlayerList;


    private void instantiatePlayers()
    {
        for (int i = 0; i < 3; i++)
        {
            //team1 = sp.getTeam1();
            //team2 = sp.getTeam2();

            leftInstanciatePlace[i] = GameObject.Find("/ChampionPlaces/leftTeam/champ" + (i+1));
            rightInstanciatePlace[i] = GameObject.Find("/ChampionPlaces/rightTeam/champ" + (i+1));
            


            GameObject ally = Instantiate(team1[i], leftInstanciatePlace[i].transform.position, leftInstanciatePlace[i].transform.rotation);
            GameObject ennemy = Instantiate(team2[i], rightInstanciatePlace[i].transform.position, rightInstanciatePlace[i].transform.rotation);

            //ally.transform.position = leftInstanciatePlace[i].transform.position;
            //ennemy.transform.position = Vector3.zero;

            team1[i] = ally;
            team2[i] = ennemy;

            team1[i].tag = "team1";
            team2[i].tag = "team2";

        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        initSelectionPerso();
    }

    private void initSelectionPerso()
    {
        if (team1[2] == null && team2[2] == null)
        {
            //sp = GameObject.Find("SelectionPersonnage").GetComponent<SelectionPersonnage>();
            //sp.getTeam1();
            //sp.getTeam2();
            /* team1 = sp.getTeam1();
             team2 = sp.getTeam2();*/
            team1 = GameObject.FindGameObjectsWithTag("team1");
            team2 = GameObject.FindGameObjectsWithTag("team2");

            instantiatePlayers();

            string[] tags = { "team1", "team2" };
            for (int i = 0; i < 2; i++)
            {

                GameObject[] tempPlayers = GameObject.FindGameObjectsWithTag(tags[i]);


                for (int j = 0; j < 3; j++)
                {
                    tempPlayers[j].SetActive(false);

                }
            }
            /*team1 = sp.getTeam1();
            team2 = sp.getTeam2();*/

        }
        else
        {
            instantiatePlayers();

        }

    }
    void Start()
    {
        foreach (GameObject champion in team1)
        {
            ChampionController champ = champion.GetComponent<ChampionController>();
            if (champ.Hp > 0)
            {
                bool isStunned = false;
                foreach (Effect effet in champ.effets)
                {
                    if (effet.Equals(gameObject.GetComponent<Stun>()))
                    {
                        isStunned = true;
                    }
                }
                if (!isStunned)
                {
                    //on passe pas ici bizarement
                    //champions.Add(champion.GetComponent<ChampionController>());
                }
            }
            champions.Add(champ);
        }
        foreach (GameObject champion in team2)
        {
            ChampionController champ = champion.GetComponent<ChampionController>();
            if (champ.Hp > 0)
            {
                bool isStunned = false;
                foreach (Effect effet in champ.effets)
                {
                    if (effet.Equals(gameObject.GetComponent<Stun>()))
                    {
                        isStunned = true;
                    }
                }
                if (!isStunned)
                {
                    //on passe pas ici bizarement
                    //champions.Add(champion.GetComponent<ChampionController>());
                }
            }
            champions.Add(champ);

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
