using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class SelectionGame : MonoBehaviour
{

    /*private GameObject[] team1 = new GameObject[5];
    private GameObject[] team2 = new GameObject[5];*/

    private Text[] textSelectedTeam = new Text[5];
    //private Text[] textSelectedTeam2 = new Text[5];

    private List<GameObject> champions = new List<GameObject>();
    private GameObject[] selectedChampionTeam = new GameObject[5];
    //private GameObject[] selectedChampionTeam2 = new GameObject[5];

    private bool isValidateTeam = false;
    //private bool isValidateTeam2 = false;
    void Start()
    {
        getAllChampions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void getAllChampions()
    {
        for (int i = 1; i < 6; i++)
        {
            textSelectedTeam[i-1] = GameObject.Find("/TeamCanvas/SelectedChampion"+i+"/Text").GetComponent<Text>();

            //on fait ce test puisque les cases 4 et 5 des tableaux sont vides
            /*if (i < 4)
            {
                textSelectedTeam1[i - 1] = GameObject.Find("/CanvasSelectionChampionCombat/Panel/LeftTeam/SelectedChampText/SelectedChamp" + i).GetComponent<Text>();
                textSelectedTeam2[i - 1] = GameObject.Find("/CanvasSelectionChampionCombat/Panel/RightTeam/SelectedChampText/SelectedChamp" + i).GetComponent<Text>();

                textSelectedTeam1[i - 1].text = "pas encore selectionné";
                textSelectedTeam2[i - 1].text = "pas encore selectionné";

                leftButtonText.text = team1[i - 1].name;
                rightButtonText.text = team2[i - 1].name;
            }*/

        }
        DirectoryInfo dirInfo = new DirectoryInfo("Assets/Prefabs/Champions/");
        FileInfo[] fileInf = dirInfo.GetFiles("*.prefab");

        foreach (FileInfo fileInfo in fileInf)
        {
            //Debug.Log(fileInfo);
            string fullPath = fileInfo.FullName.Replace(@"\", "/");
            string assetPath = "Assets" + fullPath.Replace(Application.dataPath, "");
            //string assetPath = fileInfo.ToString();
            GameObject prefab = AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject)) as GameObject;

            if (prefab != null)
            {
                //Debug.Log(prefab);
                champions.Add(prefab);


            }
        }
       
    }

    public void selectChampion(GameObject go)
    {
        for (int i = 0; i < 5; i++)
        {
            if (selectedChampionTeam[i] == null && !checkSelectedChampion(go))
            {
                selectedChampionTeam[i] = go;
                textSelectedTeam[i].text = selectedChampionTeam[i].name;
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

        }
        isValidateTeam = false;

    }
    /*public void addToSelectedChampionTeam(int index)
    {
        for (int i = 0; i < 3; i++)
        {
            if (selectedChampionTeam[i] == null && !checkSelectedChampion(index, 1))
            {
                //selectedChampionTeam1[i] = //PREFAB SELECTED;
                textSelectedTeam[i].text = selectedChampionTeam[i].name;
                break;
            }
        }
    }



    private bool checkSelectedChampion(int index, int team)
    {
        for (int i = 0; i < 3; i++)
        {
            if (team == 1)
            {
                if (selectedChampionTeam[i] == team[index])
                {
                    return true;
                }
            }
        }
        return false;
    }


    public void cancelSelectionTeam()
    {
        for (int i = 0; i < 3; i++)
        {
            textSelectedTeam[i].text = "pas encore selectionné";
            selectedChampionTeam[i] = null;

        }
        isValidateTeam = false;

    }



    public void validateTeam()
    {
        if (selectedChampionTeam[4] != null)
        {
            isValidateTeam = true;
        }
    }*/



    /*public void checkValidate()
    {
        if (isValidateTeam1 && isValidateTeam2)
        {
            SceneManager.LoadScene("FightScene");
        }
    }*/


    /*public GameObject[] getTeam1()
    {
        return selectedChampionTeam1;
    }
    public GameObject[] getTeam2()
    {
        return selectedChampionTeam2;
    }*/
}
