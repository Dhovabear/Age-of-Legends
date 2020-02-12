using System.Collections.Generic;
using Fight;
using UnityEngine;

public class DohmaController : ChampionController
{

    [SerializeField] private List<ChampionController> allies;
    [SerializeField] private List<ChampionController> ennemies;
    // Start is called before the first frame update
    void Start()
    {
        Name = "Dohma";
        Hp = 32000;
        MaxHp = Hp;
        Attaque = 3500;
        Armure = 3500;
        ResistanceMagique = 3250;
        Pouvoir = 50;
        Vitesse = 500;
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
        if (Attaque * 1.8f > target.Armure)
        {
            target.Hp = target.Hp - (Attaque * 2f - target.Armure);
        }
        int choice = Random.Range(0, 2);
        if (choice == 2)
        {
            Marques++;
        }
        else
        {
            allies[choice].Marques++;
        }
    }

    public void spell2(ChampionController target)
    {
        if (Attaque * 2f > target.Armure)
        {
            target.Hp = target.Hp - (Attaque* 2f - target.Armure);
        }
        target.Marques++;
    }

    public void ultimate(ChampionController target)
    {
        if (target.Marques >= 3)
        {
            foreach (ChampionController champion in allies)
            {
                if (target == champion)
                {
                    champion.effets.Add(gameObject.AddComponent<Invulnerability>());
                    champion.Marques -= 3;
                }
            }
            if (target == this)
            {
                effets.Add(gameObject.AddComponent<Invulnerability>());
            }

            foreach (ChampionController champion in ennemies)
            {
                if (target == champion)
                {
                    champion.Hp = 0;
                }
            }
        }
    }
}
