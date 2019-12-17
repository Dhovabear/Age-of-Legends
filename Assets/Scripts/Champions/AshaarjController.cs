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
    }

    public void spell2()
    {
        foreach (ChampionController ally in allies)
        {
            ally.Defense = ally.Defense * 1.2f;
        }
    }

    public void ultimate()
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
    }
}
