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
        Hp = 53000;
        MaxHp = Hp;
        Attaque = 200;
        Armure = 5500;
        ResistanceMagique = 5200;
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

    public override void spell1(ChampionController target)
    {
        target.Armure = target.Armure * 0.92f;
        target.ResistanceMagique = target.ResistanceMagique * 0.92f;
    }
    public void spell2()
    {
        foreach (ChampionController ally in allies)
        {
            if (ally.Armure<2000)
            {
                ally.Armure = ally.Armure * 1.15f;
            }
            else if (ally.Armure<3000)
            {
                ally.Armure = ally.Armure * 1.12f;
            }
            else if (ally.Armure<4000)
            {
                ally.Armure = ally.Armure * 1.10f;
            }
            else if (ally.Armure<5000)
            {
                ally.Armure = ally.Armure * 1.07f;
            }
            else
            {
                ally.Armure = ally.Armure * 1.03f;
            }
            
            
            if (ally.ResistanceMagique<2000)
            {
                ally.ResistanceMagique = ally.ResistanceMagique * 1.15f;
            }
            else if (ally.ResistanceMagique<3000)
            {
                ally.ResistanceMagique = ally.ResistanceMagique * 1.12f;
            }
            else if (ally.ResistanceMagique<4000)
            {
                ally.ResistanceMagique = ally.ResistanceMagique * 1.10f;
            }
            else if (ally.ResistanceMagique<5000)
            {
                ally.ResistanceMagique = ally.ResistanceMagique * 1.07f;
            }
            else
            {
                ally.ResistanceMagique = ally.ResistanceMagique * 1.03f;
            }
        }
    }

    public void ultimate()
    {
        int stunProbability = 4;
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
