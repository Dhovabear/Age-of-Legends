using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectionChampion : MonoBehaviour
{

    private SelectionPersonnage sp;


    void Start()
    {
        sp = GameObject.Find("SelectionPersonnage").GetComponent<SelectionPersonnage>();
    }

    // Update is called once per frame
    
    public void selectTeam1(int i)
    {
        sp.addToSelectedChampionTeam1(i);
    }

    public void selectTeam2(int i)
    {
        sp.addToSelectedChampionTeam2(i);

    }

    public void annulerTeam1()
    {
        sp.cancelSelectionTeam1();
    }
    public void annulerTeam2()
    {
        sp.cancelSelectionTeam2();

    }


    public void validerTeam1()
    {
        sp.validateTeam1();
        sp.checkValidate();
    }
    public void validerTeam2()
    {
        sp.validateTeam2();
        sp.checkValidate();

    }

    public void disableCanvas(GameObject o)
    {
        o.SetActive(!o.activeSelf);
    }
}
