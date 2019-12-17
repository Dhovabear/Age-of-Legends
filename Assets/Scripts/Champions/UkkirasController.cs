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

    public void spell1(ChampionController champion)
    {
        float dégats = Attaque * 2.1f - champion.Defense;
        champion.Hp = champion.Hp - dégats;
    }

    public void spell2()
    {
        foreach (ChampionController ennemy in ennemies)
        {
            ennemy.Hp = ennemy.Hp - (Attaque * 1.7f - ennemy.Defense);
        }
    }

    public void ultimate(ChampionController champion)
    {
        float dégats = Attaque * 4f - champion.Defense;
        champion.Hp = champion.Hp - dégats;
    }
}