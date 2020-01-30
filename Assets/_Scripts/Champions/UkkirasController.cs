using System.Collections.Generic;
using UnityEngine;

public class UkkirasController : ChampionController
{
    [SerializeField] private List<ChampionController> allies;
    [SerializeField] private List<ChampionController> ennemies;
    
    // Start is called before the first frame update
    void Start()
    {
        Name = "Ukkiras";
        Hp = 600;
        Attaque = 600;
        Defense = 200;
        Pouvoir = 50;
        Vitesse = 800;
        Heal = 50;
        Ultime = 0;
         
        allies = new List<ChampionController>();
        ennemies = new List<ChampionController>();

        if (CompareTag("team1"))
        {
            foreach (GameObject championObject in team1)
            {
                if (championObject.name!=name)
                {
                    allies.Add(championObject.GetComponent<ChampionController>());
                }
            }

            foreach (GameObject championObject in team2)
            {
                ennemies.Add(championObject.GetComponent<ChampionController>());
            }
        }
        else
        {
            foreach (GameObject championObject in team1)
            {
                ennemies.Add(championObject.GetComponent<ChampionController>());
            }
            foreach (GameObject championObject in team2)
            {
                if (championObject.name!=name)
                {
                    allies.Add(championObject.GetComponent<ChampionController>());
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void spell1(ChampionController champion)
    {
        //float degats = Attaque * 2.1f - champion.Defense;

        float degats = Attaque * 0.8f - champion.Defense;
        champion.Hp = champion.Hp - degats;
        chargeUltime((int)degats/100);
    }

    public override void spell2(ChampionController champion)
    {
        foreach (ChampionController ennemy in ennemies)
        {
            ennemy.Hp = ennemy.Hp - (Attaque * 1.7f - ennemy.Defense);
            Debug.Log("ennemy : "+ennemy);
            Debug.Log("ennemies : "+ennemies);

        }
        chargeUltime(5);

    }

    public override void ultimate(ChampionController champion)
    {
        float degats = Attaque * 4f - champion.Defense;
        champion.Hp = champion.Hp - degats;
        videUltime();
    }
}