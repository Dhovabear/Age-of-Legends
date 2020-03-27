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

    [SerializeField]
    private GameObject cristalVisu;

    [SerializeField]
    private GameObject manaVisu;
    
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


    public void showCristal()
    {
        manaVisu.SetActive(false);
        cristalVisu.SetActive(true);
    }

    public void showMana()
    {
        manaVisu.SetActive(true);
        cristalVisu.SetActive(false);
    }

    public void hideAll()
    {
        manaVisu.SetActive(false);
        cristalVisu.SetActive(false);
    }
}
