using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectionGame : MonoBehaviour
{
    private SelectionGame sg;
    void Start()
    {
        sg = GameObject.Find("SelectionChampion").GetComponent<SelectionGame>();
    }

    public void selectChampion(GameObject go)
    {
        sg.selectChampion(go);
    }
    public void cancel()
    {
        sg.cancelSelectionTeam();
    }
}
