using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChypsettController : ChampionController
{

    [SerializeField] string Name;
    [SerializeField] public int Hp;
    [SerializeField] public float Attaque;
    [SerializeField] public float Defense;
    [SerializeField] public float Pouvoir;
    [SerializeField] public float Vitesse;
    [SerializeField] public float Heal;
    [SerializeField] public float Ultime;


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
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void spell1()
    {

    }

    public void spell2()
    {

    }

    public void ultimate()
    {

    }

}
