using System.Collections.Generic;
using UnityEngine;

public class DohmaController : ChampionController
{

    [SerializeField] private List<ChampionController> allies;
    [SerializeField] private List<ChampionController> ennemies;
    // Start is called before the first frame update
    void Start()
    {
        Name = "Dohma";
        Hp = 800;
        Attaque = 800;
        Defense = 500;
        Pouvoir = 50;
        Vitesse = 300;
        Heal = 200;
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
        target.Hp = target.Hp - (Attaque * 1.3f - target.Defense);
        int choice = Random.Range(0, 2);
        if (choice == 2)
        {
            Marques++;
        }
        else
        {
            allies[choice].Marques++;
        }
        chargeUltime(30);
    }

    public override void spell2(ChampionController target)
    {
        target.Hp = target.Hp - (Attaque* 2.8f - target.Defense);
        target.Marques++;
        chargeUltime(20);
    }

    public override void ultimate(ChampionController target)
    {
        if (target.Marques >= 3)
        {
            foreach (ChampionController champion in allies)
            {
                if (target == champion)
                {
                    champion.effets.Add(gameObject.AddComponent<Invulnerability>());
                }

                if (target == this)
                {
                    this.effets.Add(gameObject.AddComponent<Invulnerability>());
                }
            }

            foreach (ChampionController champion in ennemies)
            {
                if (target == champion)
                {
                    champion.Hp = 0;
                }
            }
        }
        videUltime();
    }
}
