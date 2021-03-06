﻿using System.Collections;
using System.Collections.Generic;
using CollectPhase;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerManager _PlayerManager;
    
    public List<ObjectifContainer> cristRepo;
    public List<ObjectifContainer> manaRepo;
    
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
        
        TipsText.init();
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

            if(RessourcesContainer.instances == null){
                Debug.Log("Test");
                continue;
            }
            
            foreach(RessourcesContainer rc in RessourcesContainer.instances){
                rc.UpdateRessourcesV2();
            }
            
            if(RessourcesStorage.instances == null){
                Debug.Log("Test");
                continue;
            }

            foreach (RessourcesStorage rs in RessourcesStorage.instances)
            {
                rs.UpdateRessources();
            }

            if (TempleBuilding.current != null)
            {
                TempleBuilding.current.updatePrieres();
            }

            //zone de debug quand on supprime un builder
            //Cela sert a supprimer comme il faut les instances
            //pour ne pas faire crash la corroutine et ne pas casser le jeu
            
            foreach (Builder build in Builder.toRemove)
            {
                Builder.builderList.Remove(build);
            }
            
            foreach (Builder builder in Builder.builderList)
            {
                builder.updateBuild();
            }
            
        }
    }

    //créer et renvoi une liste des 'RessourcesStorage'
    //des dépots de mana
    public List<RessourcesStorage> getManaRepositories()
    {
        //on fait une nouvelle liste
        List<RessourcesStorage> list = new List<RessourcesStorage>();
        
        //on parcours la liste des depots de mana
        //pour récupérer leurs script RessourcesStorage
        foreach (ObjectifContainer container in manaRepo)
        {
            list.Add(container.GetComponent<RessourcesStorage>());
        }

        return list;
    }
    
    //meme chose que la fonction ci dessus, mais pour les cristaux
    public List<RessourcesStorage> getCritalRepositories()
    {
        //on fait une nouvelle liste
        List<RessourcesStorage> list = new List<RessourcesStorage>();
        
        //on parcours la liste des depots de mana
        //pour récupérer leurs script RessourcesStorage
        foreach (ObjectifContainer container in cristRepo)
        {
            list.Add(container.GetComponent<RessourcesStorage>());
        }

        return list;
    }
}
