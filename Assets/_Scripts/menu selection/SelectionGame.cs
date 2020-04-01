using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEditor;
//using System.IO;

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
            textSelectedTeam[i-1] = transform.Find("SelectedChampion"+i+"/Text").GetComponent<Text>();

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
        /*DirectoryInfo dirInfo = new DirectoryInfo("Assets/Prefabs/Champions/");
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
        }*/
        Object[] prefabs = Resources.LoadAll("Champions"); //(GameObject[])
        foreach (Object go in prefabs)
        {
            champions.Add(go as GameObject);
        }

    }

    public bool selectChampion(GameObject go)
    {
        for (int i = 0; i < 5; i++)
        {
            if (selectedChampionTeam[i] == null && !checkSelectedChampion(go))
            {
                selectedChampionTeam[i] = go;
                textSelectedTeam[i].text = selectedChampionTeam[i].name;
                return true;
            }
        }
        return false;
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
    public void validateTeam()
    {

        if (selectedChampionTeam[4] != null)
        {
            isValidateTeam = true;

        }

    }

    public bool getIsValidateTeam()
    {
        return isValidateTeam;
    }
}
