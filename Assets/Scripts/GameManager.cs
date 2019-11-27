using System.Collections;
using System.Collections.Generic;
using CollectPhase;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerManager _PlayerManager;

    public static GameManager current; //pour y acceder de n'importe ou
    // Start is called before the first frame update
    void Start()
    {
        //A voir quand y'aura le online
        _PlayerManager.InitPlayers();
        current = this;
        
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
            foreach (RessourcesContainer rc in RessourcesContainer.instances)
            {
                rc.UpdateRessourcesV2();
            }
        }
    }
}
