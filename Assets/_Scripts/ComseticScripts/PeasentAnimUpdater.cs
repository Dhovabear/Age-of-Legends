using System.Collections;
using System.Collections.Generic;
using Prototype.Unitees;
using UnityEngine;
using UnityEngine.AI;

public class PeasentAnimUpdater : MonoBehaviour
{
    private NavMeshAgent _agent;

    private Rigidbody _rigidbody;

    private Unite _unite;

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _rigidbody = GetComponent<Rigidbody>();
        _unite = GetComponent<Unite>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _animator.SetBool("Collecting",_unite.collecting);
        _animator.SetFloat("Move_speed",_agent.velocity.magnitude);
    }
}
