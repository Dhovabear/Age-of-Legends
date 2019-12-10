using System.Collections;
using System.Collections.Generic;
using CollectPhase;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerManager _PlayerManager;
    
    public ObjectifContainer cristRepo;
    public ObjectifContainer manaRepo;
    
    public Text infoField;

    public static GameManager current; //pour y acceder de n'importe ou
    // Start is called before the first frame update
    void Start()
    {
        //A voir quand y'aura le online
        _PlayerManager.InitPlayers();
        current = this;
        Debug.Log("Je suis init !");
        
        //on lance la boucle d'update du jeu
        StartCoroutine(TimeLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlayerManager GetPlayerManager()
    {
        return _PlayerManager;
    }
    
    
    IEnumerator TimeLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            //trucs a 1.5Sec
            yield return new WaitForSeconds(0.5f);

            /*if(RessourcesContainer.instances == null){
                Debug.Log("Test");
            }
            
            foreach(RessourcesStorage rs in RessourcesStorage.instances){
                
                //rs.UpdateRessources();
            }*/
            
            

            
        }
    }


}
