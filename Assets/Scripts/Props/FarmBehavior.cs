using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CollectPhase;
using Prototype.Camera;

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
        bouttonCreerPaysan.GetComponentInChildren<Text>().text = "Pas assez de mana!";
        bouttonCreerPaysan.interactable = false;
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
            pannelCreerPaysan.SetActive(true);
            CameraMover.currentInstance.startUIComportement();
            Debug.Log("Blocage de la caméra");
            if (GameManager.current.GetPlayerManager().GetCurrentPlayer().mana > 200){
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

    //Fonction qui va être appelé lors du clic du boutton
    public void creerPaysan()
    {
        //On verifie simplement que le joueur a assez de mana
        if (GameManager.current.GetPlayerManager().GetCurrentPlayer().mana > 200)
        {
            //Randomizer pour le spread des unitées qui spawnent
            float rngY = Random.Range(3.0f, 9.0f);
            float rngX = Random.Range(3.0f,9.0f);
            
            //instantiation
            Instantiate(Resources.Load<GameObject>("Paysan"),
                transform.position + Vector3.back*rngY + Vector3.left*rngX, Quaternion.identity);
            
            //On retire le mana du joueur
            GameManager.current.GetPlayerManager().Pay(200, TypeRes.Mana);
            bouttonCreerPaysan.interactable = false; //On bloque le boutton
            finCol = false;//On indique que le coldown n'est pas terminé , la coroutine se chargera de remettre a true
            
            StartCoroutine(coldown());//On lance la corroutine qui gère le coldown
            
        }
    }

    //Fonction qui va fermer la fenêtre
    public void fermerFenetre()
    {
        pannelCreerPaysan.SetActive(false);
        CameraMover.currentInstance.stopUIComportement();
    }

    //Fonction qui va gérer le coldown
    public IEnumerator coldown(){
        yield return new WaitForSeconds(timer);// on attend que le timer soit écoulé
        if (GameManager.current.GetPlayerManager().GetCurrentPlayer().mana > 200){
            bouttonCreerPaysan.GetComponentInChildren<Text>().text = "Créer";
            bouttonCreerPaysan.interactable = true;
        }else{
            bouttonCreerPaysan.GetComponentInChildren<Text>().text = "Pas assez de mana!";
            bouttonCreerPaysan.interactable = false;
        }
        finCol = true;
    }
}
