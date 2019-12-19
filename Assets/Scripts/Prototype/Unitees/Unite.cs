using Prototype.Camera;
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
            
            //je dois rien faire et je suis plein
            if(resCount == maxRes && currentOrder == null){
                giveOrder(getNearStorage(type)); //donc je cherche le conteneur le plus proche
            }

            
            

            RessourcesContainer rc = currentPlace.gameObject.GetComponent<RessourcesContainer>();

            //Si actuellement on est sur un endroit de récolte
            if(rc != null){
                //et si y'a plus rien a prendre
                if(rc.GetResCount() == 0){
                    giveOrder(getNearStorage(type));//alors on s'en va au stockage
                }
            }


            RessourcesStorage rs = currentPlace.gameObject.GetComponent<RessourcesStorage>();
            if(rs != null){ //si actuellement on est sur un ressources storage

                if(resCount > 0 && !rs.HasSpaceFor()){// Si on a encore des ressources et que y'a plus d'espace pour mettre des ressources
                    giveOrder(getNearStorage(type));//alors on cherche un nouvel endroit ou poser
                }
                
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

        public void SetTypeRes(TypeRes t){
            type = t;
        }
        #endregion
    }
}
