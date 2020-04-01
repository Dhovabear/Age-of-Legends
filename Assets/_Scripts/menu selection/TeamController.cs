using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TeamController : MonoBehaviour
{

    public SelectionGame player1;
    public SelectionGame player2;

    public string playerTurn = "player 1";

    private Text playerTurnText;
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("team1").GetComponent<SelectionGame>();
        player2 = GameObject.FindGameObjectWithTag("team2").GetComponent<SelectionGame>();
        playerTurnText = GameObject.Find("CanvasCurrentPlayer/Panel/TextCurrentPlayer").GetComponent<Text>();
        playerTurnText.text = playerTurn;
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
