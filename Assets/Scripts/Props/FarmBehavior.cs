using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmBehavior : MonoBehaviour
{

    public GameObject pannelCreerPaysan;
    
    public GameObject paysan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        { 
            pannelCreerPaysan.SetActive(true);
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
        }
    }
}
