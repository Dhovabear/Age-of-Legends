using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionPersonnage : MonoBehaviour
{

    public GameObject[] team1 = new GameObject[5];
    public GameObject[] team2 = new GameObject[5];

    private Text[] textSelectedTeam1 = new Text[3];
    private Text[] textSelectedTeam2 = new Text[3];

    public GameObject[] selectedChampionTeam1 = new GameObject[3];
    public GameObject[] selectedChampionTeam2 = new GameObject[3];

    private bool isValidateTeam1 = false;
    private bool isValidateTeam2 = false;

    void Start()
    {
        //getTeams();
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }
    
    public void getTeams()
    {
        /*team1 = GameObject.FindGameObjectsWithTag("team1");
        team2 = GameObject.FindGameObjectsWithTag("team2");*/
        for(int i = 1; i < 6; i++)
        {
            Text leftButtonText = GameObject.Find("CanvasSelectionChampionCombat/Panel/LeftTeam/buttons/ButtonChamp" + i+"/Text").GetComponent<Text>();
            Text rightButtonText = GameObject.Find("CanvasSelectionChampionCombat/Panel/RightTeam/buttons/ButtonChamp" + i + "/Text").GetComponent<Text>();
            
            //on fait ce test puisque les cases 4 et 5 des tableaux sont vides
            if (i < 4)
            {
                textSelectedTeam1[i-1] = GameObject.Find("/CanvasSelectionChampionCombat/Panel/LeftTeam/SelectedChampText/SelectedChamp" + i).GetComponent<Text>();
                textSelectedTeam2[i-1] = GameObject.Find("/CanvasSelectionChampionCombat/Panel/RightTeam/SelectedChampText/SelectedChamp" + i).GetComponent<Text>();

                textSelectedTeam1[i - 1].text = "pas encore selectionné";
                textSelectedTeam2[i - 1].text = "pas encore selectionné";

                
            }
            leftButtonText.text = team1[i - 1].name;
            rightButtonText.text = team2[i - 1].name;

        }
    }

    public void addToSelectedChampionTeam1(int index)
    {
        for(int i = 0; i < 3; i++)
        {
            if (selectedChampionTeam1[i] == null && !checkSelectedChampion(index,1))
            {
                selectedChampionTeam1[i] = team1[index];
                textSelectedTeam1[i].text = selectedChampionTeam1[i].name;
                break;
            }
        }
    }
    public void addToSelectedChampionTeam2(int index)
    {
        for (int i = 0; i < 3; i++)
        {
            if (selectedChampionTeam2[i] == null && !checkSelectedChampion(index,2))
            {
                selectedChampionTeam2[i] = team2[index];
                textSelectedTeam2[i].text = selectedChampionTeam2[i].name;
                break;
            }
        }
    }


    private bool checkSelectedChampion(int index, int team)
    {
        for(int i = 0; i < 3; i++)
        {
            if(team == 1)
            {
                if (selectedChampionTeam1[i] == team1[index])
                {
                    return true;
                }
            }else if(team == 2)
            {
                if (selectedChampionTeam2[i] == team2[index])
                {
                    return true;

                }
            }  
        }
        return false;
    }


    public void cancelSelectionTeam1()
    {
        for(int i = 0; i < 3; i++)
        {
            textSelectedTeam1[i].text = "pas encore selectionné";
            selectedChampionTeam1[i] = null;

        }
        isValidateTeam1 = false;

    }
    public void cancelSelectionTeam2()
    {
        for (int i = 0; i < 3; i++)
        {
            textSelectedTeam2[i].text = "pas encore selectionné";
            selectedChampionTeam2[i] = null;
        }
        isValidateTeam2 = false;
    }


    public void validateTeam1()
    {
        if(selectedChampionTeam1[2] != null)
        {
            isValidateTeam1 = true;
        }
    }

    public void validateTeam2()
    {
        if (selectedChampionTeam2[2] != null)
        {
            isValidateTeam2 = true;
        }
    }

    public void checkValidate()
    {
        if(isValidateTeam1 && isValidateTeam2)
        {
            DontDestroyOnLoad(gameObject);

            SceneManager.LoadScene("FightScene");
        }
    }


    public GameObject[] getTeam1()
    {
        return selectedChampionTeam1;
    }
    public GameObject[] getTeam2()
    {
        return selectedChampionTeam2;
    }

}
