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
        Hp = 26000;
        MaxHp = Hp;
        Attaque = 2000;
        Armure = 2800;
        ResistanceMagique = 2600;
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
        Animator anim = GetComponent<Animator>();
        if (Attaque * 4f > champion.Armure)
        {
            champion.Hp = champion.Hp - (Attaque * 4f - champion.Armure);
            chargeUltime((int)(Attaque * 4f - champion.Armure) / 100);
        }
    }

    public override void spell2(ChampionController champion)
    {
        foreach (ChampionController ennemy in ennemies)
        {
            if (Attaque * 3f > ennemy.Armure)
            {
                ennemy.Hp = ennemy.Hp - (Attaque * 3f - ennemy.Armure);
                chargeUltime((int)(Attaque * 3f - ennemy.Armure) / 100);
            }
        }
    }

    public override void ultimate(ChampionController champion)
    {
        if (Attaque * 6f > champion.Armure)
        {
            champion.Hp = champion.Hp - (Attaque * 6f - champion.Armure);
        }
        videUltime();
    }
}