using System.Collections.Generic;
using UnityEngine;

public class AshaarjController : ChampionController
{

    [SerializeField] private List<ChampionController> allies;
    [SerializeField] private List<ChampionController> ennemies;

    // Start is called before the first frame update
    void Start()
    {
        Name = "Ashaarj";
        Hp = 1000;
        Attaque = 200;
        Defense = 700;
        Pouvoir = 50;
        Vitesse = 200;
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

    public override void spell1(ChampionController target)
    {
        target.Defense = target.Defense * 0.9f;
        chargeUltime((int)target.Defense / 10);

    }

    public override void spell2(ChampionController champion)
    {
        foreach (ChampionController ally in allies)
        {
            ally.Defense = ally.Defense * 1.2f;
        }
        chargeUltime(40);
    }

    public override void ultimate(ChampionController champion)
    {
        int stunProbability = 7;
        int chance; 
        
        foreach (ChampionController ennemy in ennemies)
        {
            chance = Random.Range(0, 11);
            if (stunProbability >= chance)
            {
                ennemy.effets.Add(gameObject.AddComponent<Stun>());
            }
        }
        videUltime();
    }
}
