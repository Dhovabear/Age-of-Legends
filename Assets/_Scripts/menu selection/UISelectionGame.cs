using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UISelectionGame : MonoBehaviour
{
    private TeamController tc;
    void Start()
    {
        tc = GameObject.Find("TeamController").GetComponent<TeamController>();
    }

    public void selectChampion(GameObject go)
    {
        bool tempCheckSelect = false;
        if(tc.playerTurn == "player 1")
        {
            tempCheckSelect = tc.player1.selectChampion(go);
        }else if (tc.playerTurn == "player 2")
        {
            tempCheckSelect = tc.player2.selectChampion(go);
        }

        if (tempCheckSelect)
        {
            tc.updatePlayerTurn();

        }
    }
    public void cancelPlayer1()
    {
        if (tc.playerTurn == "player 1")
        {
            tc.player1.cancelSelectionTeam();
        }
    }

    public void cancelPlayer2()
    {
        if (tc.playerTurn == "player 2")
        {
            tc.player2.cancelSelectionTeam();
        }
    }


    public void validatePlayer1()
    {
        tc.player1.validateTeam();
        launchGame();
    }
    public void validatePlayer2()
    {
        tc.player2.validateTeam();
        launchGame();
    }

    public void launchGame()
    {
        if(tc.player1.getIsValidateTeam() && tc.player2.getIsValidateTeam())
        {
            SceneManager.LoadScene("CollectPhaseScene");
        }
    }
}
