using Prototype.Camera;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

namespace Prototype.Unitees
{

    enum TypeRes
    {
        Cristaux,
        Mana
    }

    public class Unite : MonoBehaviour , IFocusable
    {
        const int maxRes = 150;

        public static List<Unite> AllUnites;

        public Objectif currentOrder;
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
            if(resCount == maxRes){
                if(currentOrder == null){
                    Debug.Log("Fini !");
                    giveOrder(new Objectif(Vector3.zero,"rentre"));
                }
                return;
            }
            //Debug.Log(_agent.remainingDistance);
            if (_agent.remainingDistance <= distanceFromPoint && currentOrder != null && !_agent.pathPending)
            {
                currentOrder = null;
                _agent.SetDestination(gameObject.transform.position);
                //Debug.Log("je suis arriver !");
            }
        }

        public void giveOrder(Objectif ordre)
        {
            currentOrder = ordre;
            _agent.SetDestination(currentOrder.location);
            distanceFromPoint = Random.Range(0.1f,4f);
            //Debug.Log("ok ! my destination is " + currentOrder.location);
            StartCoroutine(remainingDistance());
        }

        IEnumerator remainingDistance(){
            if(_agent.pathPending)yield return null;
            //Debug.Log("il me reste " + _agent.remainingDistance);
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
    }
}
