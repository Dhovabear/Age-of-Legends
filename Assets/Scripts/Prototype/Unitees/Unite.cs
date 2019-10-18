using Prototype.Camera;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

namespace Prototype.Unitees
{

    public class Unite : MonoBehaviour , IFocusable
    {

        public static List<Unite> AllUnites;

        public Objectif currentOrder;
        
        #region Private fields

        private NavMeshAgent _agent;

        #endregion
        
        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            AllUnites.Add(this);
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(_agent.remainingDistance);
            if (_agent.remainingDistance <= 2f && currentOrder != null && !_agent.pathPending)
            {
                currentOrder = null;
                _agent.SetDestination(gameObject.transform.position);
                Debug.Log("je suis arriver !");
            }
        }

        public void giveOrder(Objectif ordre)
        {
            currentOrder = ordre;
            _agent.SetDestination(currentOrder.location);
            
            Debug.Log("ok ! my destination is " + currentOrder.location);
            StartCoroutine(remainingDistance());
        }

        IEnumerator remainingDistance(){
            if(_agent.pathPending)yield return null;
            Debug.Log("il me reste " + _agent.remainingDistance);
        }
    }
}
