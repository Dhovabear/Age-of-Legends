using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class SelectionGameNetwork : NetworkBehaviour
{
    private Text[] textSelectedTeam = new Text[5];
    public GameObject[] selectedChampionTeam = new GameObject[5];
    [SerializeField] private List<GameObject> champions = new List<GameObject>();



    public GameObject testGo;
    public GameObject[] gos = new GameObject[5];


    [SyncVar]
    public bool isValidate;
    
    private void Awake()
    {
        getAllChampions();

    }
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        CmdChangeGo();
        

        CmdSetNameOfPlayer();
        //CmdChangeChampion(0,0);
        Debug.Log("end of start player");
    }

    private void Start()
    {
        if (!base.isServer)
        {
            if (isLocalPlayer)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        
    }
    [Command]
    private void CmdSetNameOfPlayer()
    {
        if (this.netId.ToString() == "2")
        {
            gameObject.name = "SelectionChampion1";

        }
        else if (this.netId.ToString() == "3")
        {
            gameObject.name = "SelectionChampion2";

        }

        //RpcSetIsFirst();
    }


    [Command]
    private void CmdChangeGo()
    {
        GameObject go = gos[Random.Range(0, 4)];
        testGo = go;
        RpcChangeGo(go);

    }

    [ClientRpc]
    private void RpcChangeGo(GameObject go)
    {
        Debug.Log(go);
        testGo = go;
    }

    [Command]
    private void CmdChangeChampion(int index, int i)
    {
        GameObject go = champions[index];
        //selectedChampionTeam[i] = go;
        Debug.Log("hello in the command");
        setChampion(i, go);
        //RpcChangeChampion(index, i);

    }

    [ClientRpc]
    private void RpcChangeChampion(int index, int i)
    {
        GameObject go = champions[index];

        //selectedChampionTeam[0] = go;
        setChampion(i, go);
    }

    [Command]
    private void CmdCancelChampion(int index)
    {
        textSelectedTeam[index].text = "";
        selectedChampionTeam[index] = null;

    }

    [Command]
    private void CmdSetIsValidate(bool b)
    {
        isValidate = b;
    }

    private void Update()
    {

        if (!base.isLocalPlayer)
        {

            return;

        }
    }

    private void getAllChampions()
    {
        for (int i = 1; i < 6; i++)
        {
            textSelectedTeam[i - 1] = gameObject.transform.Find("TeamCanvas/SelectedChampion" + i + "/Text").GetComponent<Text>();

        }
        Object[] prefabs = Resources.LoadAll("Champions"); //(GameObject[])
        foreach (Object go in prefabs)
        {
            champions.Add(go as GameObject);
        }
        Debug.Log("getting champion");

    }

    public void selectChampion(int index)
    {

        for (int i = 0; i < 5; i++)
        {
            if (selectedChampionTeam[i] == null && !checkSelectedChampion(champions[index]))
            {
                Debug.Log("selection loop");
                selectedChampionTeam[i] = champions[index];
                textSelectedTeam[i].text = selectedChampionTeam[i].name;
                //setChampion(i, champions[index]);
                CmdChangeChampion(index, i);

                break;


            }
        }

    }
    private bool checkSelectedChampion(GameObject go)
    {
        for (int i = 0; i < 5; i++)
        {
            if (selectedChampionTeam[i] != null && selectedChampionTeam[i].name == go.name)
            {
                Debug.Log("check " + i + " times");
                return true;
            }
        }
        return false;
    }

    public void cancelSelectionTeam()
    {
        for (int i = 0; i < 5; i++)
        {
            textSelectedTeam[i].text = "";
            selectedChampionTeam[i] = null;
            CmdCancelChampion(i);

        }
        isValidate = false;
        CmdSetIsValidate(false);
    }


    public void validateTeam()
    {

        if (selectedChampionTeam[4] != null)
        {
            isValidate = true;
            CmdSetIsValidate(true);

        }

    }

    public void setChampion(int index, GameObject go)
    {
        selectedChampionTeam[index] = go;
        Debug.Log("set champion text : "+ textSelectedTeam[index]);
        Debug.Log("set champion team : " + selectedChampionTeam[index]+" champioooooooooooooooooooooooon : "+go);

        textSelectedTeam[index].text = selectedChampionTeam[index].name;
    }
}