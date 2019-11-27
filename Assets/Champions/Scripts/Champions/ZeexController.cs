using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeexController : MonoBehaviour
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
        Name = "Zeex";
        Hp = 600;
        Attaque = 50;
        Defense = 200;
        Pouvoir = 800;
        Vitesse = 600;
        Heal = 50;
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
