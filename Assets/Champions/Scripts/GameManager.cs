using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject[] champions;
    [SerializeField] GameObject Ashaarj;
    [SerializeField] AshaarjController AshaarjScript;


    private void Awake()
    {
        Ashaarj = GameObject.Find("Ashaarj");
        AshaarjScript = Ashaarj.GetComponent<AshaarjController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Ashaarj.GetComponent<AshaarjController>());
        Debug.Log(AshaarjScript.Hp);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
