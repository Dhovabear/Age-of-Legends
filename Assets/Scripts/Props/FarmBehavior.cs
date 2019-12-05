using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmBehavior : MonoBehaviour
{

    public GameObject pannelCreerPaysan;
    public GameObject bouttonCreerPaysan;
    
    public GameObject paysan;

    public float cooldown;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        bouttonCreerPaysan.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer = (float) (timer - 0.01);
        Debug.Log("Timer = "+timer);
        if (timer <= 0)
        {
            timer = 0;
            if (GameManager.current.GetPlayerManager().GetCurrentPlayer().mana > 200)
            {
                bouttonCreerPaysan.SetActive(true);
            }
        }
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        { 
            pannelCreerPaysan.SetActive(true);
            bouttonCreerPaysan.SetActive(false);
        }
        
    }
    
    public void OnMouseEnter()
    {
        
    }

    public void OnMouseExit()
    {
        
    }

    public void creerPaysan()
    {
        if (GameManager.current.GetPlayerManager().GetCurrentPlayer().mana > 200)
        {
            
            paysan = GameObject.Instantiate(Resources.Load<GameObject>("Paysan"), gameObject.transform.position + Vector3.back*3, Quaternion.identity);
            GameManager.current.GetPlayerManager().GetCurrentPlayer().mana -= 200;
            bouttonCreerPaysan.SetActive(false);
            timer = 5;
        }
    }
}
