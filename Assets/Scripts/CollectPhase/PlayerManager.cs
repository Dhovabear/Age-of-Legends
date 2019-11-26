using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CollectPhase
{
    public class PlayerManager : MonoBehaviour
    {

        private List<PlayerData> _joueurs;
        private int _currentPlayer;

        public void Awake()
        {
            _joueurs = new List<PlayerData>();
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
            Debug.Log("cristaux: "+GetCurrentPlayer().cristaux + ";  Mana: "+GetCurrentPlayer().mana);
        }
    }
}
