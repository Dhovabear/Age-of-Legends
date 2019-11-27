using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UkkirasController : MonoBehaviour
{
    [SerializeField] string Name;
    [SerializeField] public float Hp;
    [SerializeField] public float Attaque;
    [SerializeField] public float Defense;
    [SerializeField] public float Pouvoir;
    [SerializeField] public float Vitesse;
    [SerializeField] public float Heal;
    [SerializeField] public float Ultime;


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
