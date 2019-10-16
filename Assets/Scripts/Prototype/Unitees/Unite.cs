using Prototype.Camera;
using UnityEngine;
using UnityEngine.AI;

namespace Prototype.Unitees
{

    public class Unite : MonoBehaviour , IFocusable
    {

        public Objectif currentOrder;
        
        #region Private fields

        private NavMeshAgent _agent;

        #endregion
        // Start is called before the first frame update
        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.isStopped = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (_agent.remainingDistance <= 2f && currentOrder != null)
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
        }
    }
}
