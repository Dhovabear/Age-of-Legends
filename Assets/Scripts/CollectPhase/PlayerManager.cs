using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace CollectPhase
{
    public class PlayerManager : MonoBehaviour
    {

        private List<PlayerData> _joueurs;
        private int _currentPlayer;
        private Text cristIndic;
        private Text manaIndic;
        
        private bool wantToBuild;
        private int idToBuild;
        
        public GameObject buildPrefab;
        private CinemachineClearShot cl;
        #region MonobehaviourCallbacks
        public void Awake()
        {
            _joueurs = new List<PlayerData>();
        }

        public void Start()
        {
            cristIndic = GameObject.Find("cristauxLine").GetComponentInChildren<Text>();
            manaIndic = GameObject.Find("manaLine").GetComponentInChildren<Text>();
        }

        private void Update()
        {
            //on obtient le joueur local
            PlayerData pd = GetCurrentPlayer();
            
            //Debug.Log("C: " + pd.cristaux + "   M: " + pd.mana);
            
            //mise a jour de l'interface qui affiche le nombre de cristaux
            string cristTxt = (pd.cristaux >= 1000)?pd.cristaux/1000 + "," + (pd.cristaux % 1000) / 100 + "k" : pd.cristaux.ToString();
            cristIndic.text = "x " + cristTxt;
            
            //idem pour le nombre de ressources de mana
            string manaTxt = (pd.mana >= 1000)?pd.mana/1000 + "," + (pd.mana % 1000) / 100 + "k" : pd.mana.ToString();
            manaIndic.text = "x " + manaTxt;

            if (wantToBuild && Input.GetMouseButtonDown(0))
            {
                RaycastHit res;
                //Ray ray = new Ray(Camera.main.ScreenPointToRay(Input.mousePosition),Camera.main.transform.forward);
                Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out res, 1000f);
                var buildPoint = GameObject.Instantiate(buildPrefab,res.point,new Quaternion(0,0,0,0));
                buildPoint.transform.position = res.point;
                buildPoint.GetComponent<Builder>().setBuildingID(idToBuild);
                //buildPoint.transform.Translate(0,5f,0);
                wantToBuild = false;
                
            }
        }
        #endregion
        
        // Start is called before the first frame update
        public void InitPlayers()
        {
            _joueurs.Add(new PlayerData("Joueur1",new List<Object>()));
            _joueurs.Add(new PlayerData("Joueur2",new List<Object>()));
            
            //condition si je suis le joueur local
            _currentPlayer = 0;
        }

        
        //retourne les données du joueur local (utile pour le jeu en ligne)
        public PlayerData GetCurrentPlayer()
        {
            return _joueurs[_currentPlayer]; // oui oui on peut faire ca sur les listes en C#
        }

        public void EarnCristal(int amount)
        {
            GetCurrentPlayer().cristaux += amount;
        }

        public void EarnMana(int amount)
        {
            GetCurrentPlayer().mana += amount;
        }

        //Fonction TRES importante , utiliser pour payer (ou simplement retirer du mana)
        //de facon saine, c'est a dire que l'on va retirer des ressources aussi dans les dépots
        //ce que les autres fonctions ne font pas, de plus elle renvoi la réussite de la transaction
        public bool Pay(int amount, TypeRes type)
        {
            //TODO: améliorer la liste en utilisant un tri en odre croissant sur la capacité de stockage

            //On regarde si la transaction est possible suivant la ressource choisi
            if ( type == TypeRes.Mana && amount > GetCurrentPlayer().mana){return false;}
            if(type == TypeRes.Cristaux && amount > GetCurrentPlayer().cristaux)return false;
            
            

            if (type == TypeRes.Mana) GetCurrentPlayer().mana -= amount;
            else GetCurrentPlayer().cristaux -= amount;
            
            int montantRestant = amount;//on stocke le montant restant
            List<RessourcesStorage> listRepo;
                
            //on prend la liste de mana ou de cristaux suivant le choix
            if(type == TypeRes.Mana)listRepo = GameManager.current.getManaRepositories();
            else listRepo = GameManager.current.getCritalRepositories();

            foreach (RessourcesStorage storage in listRepo)
            {
                //peut être étrange mais le montant restant prend la valeur 
                //de ce qu'on a pas pu enlever au storage concerné (grossièrement ce qu'il reste a retirer)
                montantRestant = storage.takeRessources(montantRestant);
                if (montantRestant <= 0) break; //donc si il ne nous reste plus rien a retirer alors on arrete
            }

            return true;
        }
        
        /*
         * Fonction qui va permettre la construction de batiments
         * pour le jeu , le batiment a créer sera identifié par un build ID
         * qui lui sera propre les buildId seront:
         * - CristalRepo: 0
         * - ManaRepo: 1
         */
        public void BuildStorage(int buildId)
        {
            idToBuild = buildId;
            wantToBuild = true;
        }
    }
    
    
}
