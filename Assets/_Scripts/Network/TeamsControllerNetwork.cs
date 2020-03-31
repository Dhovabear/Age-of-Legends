using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class TeamsControllerNetwork : NetworkBehaviour
{
    public GameObject[] selectedChampionTeam1 = new GameObject[5];
    public GameObject[] selectedChampionTeam2 = new GameObject[5];

    public SelectionGameNetwork player1sg;
    public SelectionGameNetwork player2sg;

    public Text[] texts = new Text[10];
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("net id team controller : " + this.netId);
        for(int i = 1; i < 11; i++)
        {
            texts[i - 1] = transform.Find("Canvas/TextChampion" + i).GetComponent<Text>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        /*if (!isLocalPlayer)
        {
            return;
        }*/
        for(int i = 0; i < 5; i++)
        {
            if(selectedChampionTeam1[i] != null)
            {
                texts[i].text = selectedChampionTeam1[i].name;
            }
            else
            {
                texts[i].text = "";
            }
        }
        for (int i = 5; i < 10; i++)
        {
            if (selectedChampionTeam2[i-5] != null)
            {
                texts[i].text = selectedChampionTeam2[i - 5].name;

            }
            else
            {
                texts[i].text = "";
            }

        }
        //CmdPrintChampion();
        if(player1sg == null && GameObject.Find("SelectionChampion1") !=null)
        {
            player1sg = GameObject.Find("SelectionChampion1").GetComponent<SelectionGameNetwork>();
        }
        if (player2sg == null && GameObject.Find("SelectionChampion2") != null)
        {
            player2sg = GameObject.Find("SelectionChampion2").GetComponent<SelectionGameNetwork>();

        }
        if (player1sg != null && player2sg != null)
        {
            selectedChampionTeam1 = player1sg.selectedChampionTeam;
            selectedChampionTeam2 = player2sg.selectedChampionTeam;
            if(player1sg.isValidate && player2sg.isValidate)
            {
                //CHANGE SCENE
                Debug.Log("changer scene");
                NetworkManager.singleton.ServerChangeScene("CollectPhaseScene");


            }
        }
 

    }


    [ClientRpc]
    public void RpcSetSelectedChampions()
    {
        CmdSetSelectedChampions();
    }

    [Command]
    public void CmdSetSelectedChampions()
    {
        selectedChampionTeam1 = player1sg.selectedChampionTeam;
        selectedChampionTeam2 = player2sg.selectedChampionTeam;
    }


    [Command]
    public void CmdPrintChampion()
    {
        Debug.Log("first of list 1 : " + selectedChampionTeam1[0]);
        Debug.Log("first of list 2 : " + selectedChampionTeam2[0]);
    }
}
