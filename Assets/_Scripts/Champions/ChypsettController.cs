using System.Collections.Generic;
using UnityEngine;

public class ChypsettController : ChampionController
{

    [SerializeField] private List<ChampionController> allies;
    [SerializeField] private List<ChampionController> ennemies;

    // Start is called before the first frame update
    void Start()
    {
        Name = "Chypsett";
        Hp = 16000;
        MaxHp = Hp;
        Attaque = 50;
        Armure = 2000;
        ResistanceMagique = 1800;
        Pouvoir = 400;
        Vitesse = 400;
        Heal = 3000;
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
        if (champion.Hp + Heal >= champion.MaxHp)
        {
            champion.Hp = champion.MaxHp;
        }
        else
        {
            champion.Hp = champion.Hp + Heal;
        }
        chargeUltime((int)(Heal/100));
    }

    public override void spell2(ChampionController champion)
    {
        foreach (ChampionController ally in allies)
        {
            ally.Vitesse = ally.Vitesse * 1.8f;
        }
        chargeUltime(20);
    }

    public override void ultimate(ChampionController champion)
    {
        champion.effets.Add(gameObject.AddComponent<Stun>());
        champion.effets.Add(gameObject.AddComponent<Stun>());
        videUltime();
    }

}
