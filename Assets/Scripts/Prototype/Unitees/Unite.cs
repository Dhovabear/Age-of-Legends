﻿using Prototype.Camera;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

namespace Prototype.Unitees
{

    public class Unite : MonoBehaviour , IFocusable
    {
        public const int maxRes = 213;

        public static List<Unite> AllUnites;

        public Objectif currentOrder;
        public Objectif lastOrder;

         

        public GameObject container;


        public bool collecting = false;

        #region Private fields

        private NavMeshAgent _agent;
        private float distanceFromPoint;
        //res
        private TypeRes type;
        private int resCount;

        public Container currentPlace;

        #endregion
        
        void Start()
        {
            if(AllUnites == null) AllUnites = new List<Unite>();
            _agent = GetComponent<NavMeshAgent>();
            distanceFromPoint = Random.Range(0.1f,3f);
            AllUnites.Add(this);
        }

        // Update is called once per frame
        void Update()
        {
            
            //Debug.Log(_agent.remainingDistance);
            if (_agent.remainingDistance <= distanceFromPoint && currentOrder != null && !_agent.pathPending)
            {
                if(currentOrder.name == "Collecter" ){
                    lastOrder = currentOrder;
                }
                currentOrder = null;
                _agent.SetDestination(gameObject.transform.position);
                //Debug.Log("je suis arriver !");
            }
        }

        public void CheckIfImFull(){
            if(resCount == maxRes && currentOrder == null){
                /*if(type == TypeRes.Cristaux){
                    giveOrder(GameManager.current.cristRepo.GetObjectif());
                }else{
                    giveOrder(GameManager.current.manaRepo.GetObjectif());
                }*/
                giveOrder(getNearStorage(type));
            }

            

            RessourcesStorage rs = currentPlace.gameObject.GetComponent<RessourcesStorage>();
            if(rs != null){
                if(resCount > 0 && !rs.HasSpaceFor()){
                giveOrder(getNearStorage(type));
            }
            }
            

            if(resCount == 0 && lastOrder != null){
                giveOrder(lastOrder);
            }
        }

        public void giveOrder(Objectif ordre)
        {
            currentOrder = ordre;
            _agent.SetDestination(currentOrder.location);
            distanceFromPoint = Random.Range(0.1f,4f);
            //Debug.Log("ok ! my destination is " + currentOrder.location);
        }

    

        public void EarnRessources(bool isCristal,int amount){
            if(type == null) type = (isCristal)? TypeRes.Cristaux : TypeRes.Mana;

            if(resCount + amount > maxRes){
                return;
            }

            if(isCristal && type == TypeRes.Cristaux){
                resCount += amount;
            }

            if(!isCristal && type == TypeRes.Mana){
                resCount += amount;
            }

        }

        private Objectif getNearStorage(TypeRes type){

            float bestVal = 99999999;
            ObjectifContainer best = null;
            List<ObjectifContainer> ls;

            if(type == TypeRes.Mana){
                ls = GameManager.current.manaRepo;
            }
            else{
                ls = GameManager.current.cristRepo;
            }

            foreach(ObjectifContainer rs in ls){

                if(!rs.gameObject.GetComponent<RessourcesStorage>().HasSpaceFor()){
                    continue;
                }

                float dist = Vector3.Distance(gameObject.transform.position,rs.gameObject.transform.position);
                if( dist < bestVal){
                    best = rs;
                    bestVal = dist;
                }
            }

            return best.GetObjectif();
            
        }

        #region getter et setter
        public int CanCarry(){
            return maxRes - resCount;
        }

        public TypeRes GetResType(){
            return type;
        }

        public int GetResCount()
        {
            return resCount;
        }
        #endregion
    }
}
