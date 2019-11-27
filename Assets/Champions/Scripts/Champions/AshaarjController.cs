using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class AshaarjController : ChampionController
{

    [SerializeField] string Name;
    [SerializeField] public float Hp;
    [SerializeField] public float Attaque;
    [SerializeField] public float Defense;
    [SerializeField] public float Pouvoir;
    [SerializeField] public float Vitesse;
    [SerializeField] public float Heal;
    [SerializeField] public float Ultime;
    
    [SerializeField] private GameObject[] allies;
    [SerializeField] private GameObject[] ennemies;


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

        if (CompareTag("team1"))
        {
            allies = GameObject.FindGameObjectsWithTag("team1");
            ennemies = GameObject.FindGameObjectsWithTag("team2");
        }
        else
        {
            allies = GameObject.FindGameObjectsWithTag("team2");
            ennemies = GameObject.FindGameObjectsWithTag("team1");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void spell1()
    {
        SaaleerController Ennemy1 = GameObject.Find("Saaeleer").GetComponent<SaaleerController>();
        DohmaController Ennemy2 = GameObject.Find("Dohma").GetComponent<DohmaController>();
        UkkirasController Ennemy3 = GameObject.Find("Ukkiras").GetComponent<UkkirasController>();

        int choice = Random.Range(1, 3);

        switch (choice)
        {
            case 1:
                Ennemy1.Defense = Ennemy1.Defense * 0.9f;
                break;
            case 2:
                Ennemy2.Defense = Ennemy2.Defense * 0.9f;
                break;
            case 3:
                Ennemy3.Defense = Ennemy3.Defense * 0.9f;
                break;
        }

    }

    public void spell2()
    {
        ChypsettController Ally1 = GameObject.Find("Chypsett").GetComponent<ChypsettController>();
        ZeexController Ally2 = GameObject.Find("Zeex").GetComponent<ZeexController>();

        Ally1.Defense = Ally1.Defense * 1.2f;
        Ally2.Defense = Ally2.Defense * 1.2f;
    }

    public void ultimate()
    {
        SaaleerController Ennemy1 = GameObject.Find("Saaeleer").GetComponent<SaaleerController>();
        DohmaController Ennemy2 = GameObject.Find("Dohma").GetComponent<DohmaController>();
        UkkirasController Ennemy3 = GameObject.Find("Ukkiras").GetComponent<UkkirasController>();
        int stunProbability = 7;
        int chance = 0; 
        
        chance = Random.Range(0, 10);
        if (stunProbability >= chance)
        {
            Component component = new SaaleerController();

            Component test = gameObject.AddComponent<SaaleerController>();
        }
        
    }

}
