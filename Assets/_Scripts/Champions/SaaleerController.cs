using System.Collections.Generic;
using UnityEngine;

public class SaaleerController : ChampionController
{

    [SerializeField] private List<ChampionController> allies;
    [SerializeField] private List<ChampionController> ennemies;

    // Start is called before the first frame update
    void Start()
    {
        Name = "Saaleer";
        Hp = 18000;
        MaxHp = Hp;
        Attaque = 50;
        Armure = 2300;
        ResistanceMagique = 2100;
        Pouvoir = 3200;
        Vitesse = 300;
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
        float degats = Pouvoir * 2f;
        if (degats - champion.ResistanceMagique > 0)
        {
            champion.Hp = Hp - (degats - champion.ResistanceMagique);
        }
    }

    public void spell2(ChampionController champion)
    {
        foreach (ChampionController ally in allies)
        {
            ally.Pouvoir = ally.Pouvoir * 1.2f;
        }
    }

    public void ultimate()
    {
        foreach (ChampionController ally in allies)
        {
            ally.Ultime = ally.Ultime + 40;
        }
        videUltime();
    }
}
