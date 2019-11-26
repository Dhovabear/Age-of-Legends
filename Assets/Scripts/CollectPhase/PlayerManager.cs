using System;
using System.Collections.Generic;
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

        public void Awake()
        {
            _joueurs = new List<PlayerData>();
        }

        public void Start()
        {
            cristIndic = GameObject.Find("cristauxLine").GetComponentInChildren<Text>();
            manaIndic = GameObject.Find("manaLine").GetComponentInChildren<Text>();
        }

        // Start is called before the first frame update
        public void InitPlayers()
        {
            _joueurs.Add(new PlayerData("Joueur1",new List<Object>()));
            _joueurs.Add(new PlayerData("Joueur2",new List<Object>()));
            
            //condition si je suis le joueur local
            _currentPlayer = 0;
        }

        

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

        private void Update()
        {
            PlayerData pd = GetCurrentPlayer();
            
            Debug.Log("C: " + pd.cristaux + "   M: " + pd.mana);
            
            string cristTxt = (pd.cristaux >= 1000)?pd.cristaux/1000 + "," + (pd.cristaux % 1000) / 100 + "k" : pd.cristaux.ToString();
            cristIndic.text = "x " + cristTxt;
            
            string manaTxt = (pd.mana >= 1000)?pd.mana/1000 + "," + (pd.mana % 1000) / 100 + "k" : pd.mana.ToString();
            manaIndic.text = "x " + manaTxt;
        }
    }
}
