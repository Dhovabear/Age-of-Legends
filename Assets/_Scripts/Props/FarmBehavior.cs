using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CollectPhase;
public class FarmBehavior : MonoBehaviour
{

    public GameObject pannelCreerPaysan;
    public Button bouttonCreerPaysan;
    
    public GameObject paysan;

    //public float cooldown;
    public float timer = 0.1f;
    public bool finCol = true;
    // Start is called before the first frame update
    void Start()
    {
        //bouttonCreerPaysan.GetComponentInChildren<Text>().text = "Pas assez de mana!";
        //bouttonCreerPaysan.interactable = false;
        finCol = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (timer <= 0)
        {
            timer = 0;
            if (GameManager.current.GetPlayerManager().GetCurrentPlayer().mana > 200)
            {
                bouttonCreerPaysan.GetComponentInChildren<Text>().text = "Créer";
                bouttonCreerPaysan.interactable = true;
            }
        }*/
        if(finCol){
            GameManager gm = GameManager.current;
            PlayerManager pm = gm.GetPlayerManager();
            PlayerData pd = pm.GetCurrentPlayer();

            if (pd.mana > 200)
            {
                bouttonCreerPaysan.GetComponentInChildren<Text>().text = "Créer";
                bouttonCreerPaysan.interactable = true;
            }
        }
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        { 
            if (GameManager.current.GetPlayerManager().GetCurrentPlayer().mana > 200){
                pannelCreerPaysan.SetActive(true);
                bouttonCreerPaysan.GetComponentInChildren<Text>().text = "Créer";
                bouttonCreerPaysan.interactable = true;
            }else{
                bouttonCreerPaysan.GetComponentInChildren<Text>().text = "Pas assez de mana!";
                bouttonCreerPaysan.interactable = false;
            }
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
            //bouttonCreerPaysan.GetComponentInChildren<Text>().text = "Pas assez de mana!";
            bouttonCreerPaysan.interactable = false;
            finCol = false;
            StartCoroutine(coldown());
        }
    }

    public IEnumerator coldown(){
        yield return new WaitForSeconds(timer);
        finCol = true;
    }
}
