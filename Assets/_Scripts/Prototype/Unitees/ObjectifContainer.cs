using System.Collections;
using System.Collections.Generic;
using Prototype.Unitees;
using UnityEngine;

public class ObjectifContainer : MonoBehaviour
{
    [SerializeField] private string orderName;

    private Objectif obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = new Objectif(gameObject.transform.position,orderName);
    }

    // Update is called once per frame
    public Objectif GetObjectif()
    {
        return obj;
    }
}
