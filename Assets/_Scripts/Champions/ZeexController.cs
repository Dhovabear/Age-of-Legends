using System.Collections.Generic;
using UnityEngine;

public class ZeexController : ChampionController
{
    [SerializeField] private List<ChampionController> allies;
    [SerializeField] private List<ChampionController> ennemies;
    
    // Start is called before the first frame update
    void Start()
    {
        Name = "Zeex";
        Hp = 600;
        Attaque = 50;
        Defense = 200;
        Pouvoir = 800;
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

    }

    public void spell2()
    {

    }

    public void ultimate()
    {

    }
}

