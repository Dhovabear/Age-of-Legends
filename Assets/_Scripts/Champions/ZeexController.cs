using System.Collections.Generic;
using Fight;
using UnityEngine;

public class ZeexController : ChampionController
{
    [SerializeField] private List<ChampionController> allies;
    [SerializeField] private List<ChampionController> ennemies;
    
    // Start is called before the first frame update
    void Start()
    {
        Name = "Zeex";
        Hp = 19000;
        MaxHp = Hp;
        Attaque = 50;
        Armure = 2200;
        ResistanceMagique = 2000;
        Pouvoir = 3500;
        Vitesse = 600;
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
        if (Pouvoir * 2f > champion.ResistanceMagique)
        {
            champion.Hp = champion.Hp - (Pouvoir* 2f - champion.ResistanceMagique);
            chargeUltime((int)((Pouvoir* 2f - champion.ResistanceMagique)/100));
        }
        champion.effets.Add(gameObject.AddComponent<Inferno>());
    }

    public override void spell2(ChampionController champion)
    {
        chargeUltime(45);
    }

    public override void ultimate(ChampionController champ)
    {
        foreach (ChampionController champion in ennemies)
        {
            int count = 0;
            foreach (Effect effet in champion.effets)
            {
                if (effet.Equals(gameObject.GetComponent<Inferno>()))
                {
                    count++;
                }
            }
            champion.Hp = champion.Hp - (count * 3000);
        }
        videUltime();
    }
}
