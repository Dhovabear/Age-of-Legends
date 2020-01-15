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
        Hp = 300;
        Attaque = 50;
        Defense = 200;
        Pouvoir = 400;
        Vitesse = 400;
        Heal = 700;
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
        champion.Hp = champion.Hp + Heal;
    }

    public void spell2()
    {
        foreach (ChampionController ally in allies)
        {
            ally.Vitesse = ally.Vitesse * 1.2f;
        }
    }

    public void ultimate(ChampionController champion)
    {
        champion.effets.Add(gameObject.AddComponent<Stun>());
        champion.effets.Add(gameObject.AddComponent<Stun>());
    }

}
