using Prototype.Camera;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

namespace Prototype.Unitees
{

    public class Unite : MonoBehaviour , IFocusable
    {
        public const int maxRes = 150;

        public static List<Unite> AllUnites;

        public Objectif currentOrder;
        public Objectif lastOrder;
        public GameObject container;
        



        #region Private fields

        private NavMeshAgent _agent;
        private float distanceFromPoint;
        //res
        private TypeRes type;
        private int resCount;
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
                lastOrder = currentOrder;
                currentOrder = null;
                _agent.SetDestination(gameObject.transform.position);
                //Debug.Log("je suis arriver !");
            }
        }

        public void CheckIfImFull(){
            if(resCount == maxRes && currentOrder == null){
                if(type == TypeRes.Cristaux){
                    giveOrder(GameManager.current.cristRepo.GetObjectif());
                }else{
                    giveOrder(GameManager.current.manaRepo.GetObjectif());
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

        public int CanCarry(){
            return maxRes - resCount;
        }

        public TypeRes GetResType(){
            return type;
        }
    }
}
