using System;
using System.Collections.Generic;
using Fight;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class ChampionController : MonoBehaviour, IComparable
{

    [SerializeField] public string Name;
    [SerializeField] public float Hp;
    [SerializeField] public float MaxHp;
    [SerializeField] public float Attaque;
    [SerializeField] public float Armure;
    [SerializeField] public float ResistanceMagique;
    [SerializeField] public float Defense;
    [SerializeField] public float Pouvoir;
    [SerializeField] public float Vitesse;
    [SerializeField] public float Heal;
    [Range(0,100)] [SerializeField] public int Ultime;
    [SerializeField] public List<Effect> effets;
    [SerializeField] public int Marques = 0;


    [SerializeField] protected GameObject[] team1;
    [SerializeField] protected GameObject[] team2;

    public String[] spellsTarget = new String[4];
    public String[] descSpell = new String[4];

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        team1 = GameObject.FindGameObjectsWithTag("team1");
        team2 = GameObject.FindGameObjectsWithTag("team2");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int Compare(ChampionController Champion1, ChampionController Champion2)
    {
        if (Champion1.Vitesse > Champion2.Vitesse)
            return -1;
        if (Champion1.Vitesse < Champion2.Vitesse)
            return 1;
        return 0;
    }

    public int CompareTo(object obj)
    {
        ChampionController champion = (ChampionController) obj;
        return Compare(this, champion);
    }

    public void chargeUltime(int improve)
    {
        Ultime += improve;
    }
    public void videUltime()
    {
        Ultime = 0;
    }

    public abstract void spell1(ChampionController champion);
    public abstract void spell2(ChampionController champion);
    public abstract void ultimate(ChampionController champion);

    public void autoAttack(ChampionController champion)
    {
        champion.Hp = champion.Hp - (Attaque - champion.Defense);
    }
}
