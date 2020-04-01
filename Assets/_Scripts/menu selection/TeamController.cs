using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeamController : MonoBehaviour
{

    public SelectionGame player1;
    public SelectionGame player2;
    public GameObject[] selectedChampionTeam1 = new GameObject[5];
    public GameObject[] selectedChampionTeam2 = new GameObject[5];

    private bool canChangeScene = true;

    public string playerTurn = "player 1";

    private Text playerTurnText;
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("team1").GetComponent<SelectionGame>();
        player2 = GameObject.FindGameObjectWithTag("team2").GetComponent<SelectionGame>();
        playerTurnText = GameObject.Find("CanvasCurrentPlayer/Panel/TextCurrentPlayer").GetComponent<Text>();
        playerTurnText.text = playerTurn;
        SceneManager.sceneLoaded += OnSceneLoaded;


    }

    private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    {
        if (canChangeScene)
        {
            GameObject teamPlace1 = GameObject.Find("Team1Places");
            GameObject teamPlace2 = GameObject.Find("Team2Places");

            for (int i = 0; i < 5; i++)
            {
                Transform place1 = teamPlace1.transform.Find("CharacterBase" + (i + 1));
                GameObject character1 = Instantiate(selectedChampionTeam1[i], place1);
                Transform place2 = teamPlace2.transform.Find("CharacterBase" + (i + 1));
                GameObject character2 = Instantiate(selectedChampionTeam1[i], place2);
                character1.tag = "team1";
                character1.name = selectedChampionTeam1[i].name;
                character2.tag = "team2";
                character2.name = selectedChampionTeam2[i].name;

                //DontDestroyOnLoad(character1);
                //DontDestroyOnLoad(character2);

            }

            SelectionPersonnage sp = GameObject.Find("SelectionPersonnage").GetComponent<SelectionPersonnage>();
            sp.team1 = selectedChampionTeam1;
            sp.team2 = selectedChampionTeam2;
            Destroy(gameObject);
            canChangeScene = false;
        }
        

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updatePlayerTurn()
    {
        if (playerTurn == "player 1")
        {
            playerTurn = "player 2";
        }else if (playerTurn == "player 2")
        {
            playerTurn = "player 1";
        }
        playerTurnText.text = playerTurn;


    }
}
