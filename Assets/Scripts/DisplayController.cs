using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayController : MonoBehaviour
{
    public Text champ1Name;
    public Text champ1Health;
    public Text champ1Ult;
    
    public Text champ2Name;
    public Text champ2Health;
    public Text champ2Ult;
    
    public Text champ3Name;
    public Text champ3Health;
    public Text champ3Ult;
    
    public Text enemy1Name;
    public Text enemy1Health;
    public Text enemy1Ult;
    
    public Text enemy2Name;
    public Text enemy2Health;
    public Text enemy2Ult;
    
    public Text enemy3Name;
    public Text enemy3Health;
    public Text enemy3Ult;
    
    public Text champ4Name;
    public Text champ4Health;

    public Text currentEnnemyInfo;
    
    public FightManager fightmanager;
    
    public GameObject paneEnnemy;
    
    public Button button;
    
    public Button spell1;
    public Button spell2;
    public Button ult;
    
    public Button enemy1;
    public Button enemy2;
    public Button enemy3;

    public int currentSpell = 0;

    private List<ChampionController> champions;

    private void nextTurn()
    {
        if (fightmanager.getIndiceChampionCourant() < 5)
        {
            fightmanager.setIndiceChampionCourant(fightmanager.getIndiceChampionCourant()+1);
        }
        else
        {
            fightmanager.setIndiceChampionCourant(0);
            fightmanager.champions.Sort(Comparer<ChampionController>.Default);
        }
        updateInfos();
    }

    private void updateInfos()
    {
        champ4Name.text = "";

        champ1Name.text =fightmanager.getTeam1()[0].Name;
        champ1Health.text = "Vie : " + fightmanager.getTeam1()[0].Hp;
        champ1Ult.text = " Ult : " + fightmanager.getTeam1()[0].Ultime + "/100";
        
        champ2Name.text =fightmanager.getTeam1()[1].Name;
        champ2Health.text = "Vie : " + fightmanager.getTeam1()[1].Hp;
        champ2Ult.text = " Ult : " + fightmanager.getTeam1()[1].Ultime + "/100";
        
        champ3Name.text =fightmanager.getTeam1()[2].Name;
        champ3Health.text = "Vie : " + fightmanager.getTeam1()[2].Hp;
        champ3Ult.text = " Ult : " + fightmanager.getTeam1()[2].Ultime + "/100";
        
        enemy1Name.text =fightmanager.getTeam2()[0].Name;
        enemy1Health.text = "Vie : " + fightmanager.getTeam1()[0].Hp;
        enemy1Ult.text = " Ult : " + fightmanager.getTeam1()[0].Ultime + "/100";
        
        enemy2Name.text =fightmanager.getTeam1()[1].Name;
        enemy2Health.text = "Vie : " + fightmanager.getTeam2()[1].Hp;
        enemy2Ult.text = " Ult : " + fightmanager.getTeam2()[1].Ultime + "/100";
        
        enemy3Name.text =fightmanager.getTeam2()[2].Name;
        enemy3Health.text = "Vie : " + fightmanager.getTeam2()[2].Hp;
        enemy3Ult.text = " Ult : " + fightmanager.getTeam2()[2].Ultime + "/100";
        
        //champ4Name.text =fightmanager.getTeam2()[0].Name;
        //champ4Health.text = "Vie : " + fightmanager.getTeam2()[0].Hp;

        if (champions[fightmanager.getIndiceChampionCourant()].Name == fightmanager.getTeam1()[0].Name)
        {
            champ1Name.text ="-->" + fightmanager.getTeam1()[0].Name;
        }
        if (champions[fightmanager.getIndiceChampionCourant()].Name == fightmanager.getTeam1()[1].Name)
        {
            champ2Name.text ="-->" + fightmanager.getTeam1()[1].Name;
        }
        if (champions[fightmanager.getIndiceChampionCourant()].Name == fightmanager.getTeam1()[2].Name)
        {
            champ3Name.text ="-->" + fightmanager.getTeam1()[2].Name;
        }
        if (champions[fightmanager.getIndiceChampionCourant()].Name == fightmanager.getTeam2()[0].Name)
        {
            enemy1Name.text ="-->" + fightmanager.getTeam2()[0].Name;
        }
        if (champions[fightmanager.getIndiceChampionCourant()].Name == fightmanager.getTeam2()[1].Name)
        {
            enemy2Name.text ="-->" + fightmanager.getTeam2()[1].Name;
        }
        if (champions[fightmanager.getIndiceChampionCourant()].Name == fightmanager.getTeam2()[2].Name)
        {
            enemy3Name.text ="-->" + fightmanager.getTeam2()[2].Name;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        champions = fightmanager.champions;
        paneEnnemy.SetActive(false);
        updateInfos();
        button.onClick.AddListener(nextTurn);
        currentEnnemyInfo.text = "";
        champ4Name.text = "";
    }

    public void mouseEntered(int id)
    {
        ChampionController enemy;
        if (checkCurrentTeam())
        {
            enemy = fightmanager.getTeam2()[id];
        }
        else
        {
            enemy = fightmanager.getTeam1()[id];
        }
        
        currentEnnemyInfo.text = enemy.name + " -> HP : " + enemy.Hp;
    }

    public void mouseExit()
    {
        currentEnnemyInfo.text = "";
    }

    public void attack(int id)
    {
        currentSpell = id;
        paneEnnemy.SetActive(true);
    }

    public void launchSpell(int id)
    {
        String name = fightmanager.champions[fightmanager.getIndiceChampionCourant()].name;
        String targetName;
        switch (currentSpell)
        {
            case 0:
                if (name == fightmanager.getTeam1()[0].name || name == fightmanager.getTeam1()[1].name ||
                    name == fightmanager.getTeam1()[2].name)
                {
                    fightmanager.champions[fightmanager.getIndiceChampionCourant()].spell1(fightmanager.getTeam2()[id]);
                    targetName = fightmanager.getTeam2()[id].name;
                }
                else
                {
                    fightmanager.champions[fightmanager.getIndiceChampionCourant()].spell1(fightmanager.getTeam1()[id]);
                    targetName = fightmanager.getTeam1()[id].name;
                }
                champ4Name.text = fightmanager.champions[fightmanager.getIndiceChampionCourant()].name +
                                  " a lancé son sort 1 sur " + targetName;
                break;
            case 1:

                break;
        }

        nextTurn();
        updateInfos();
        paneEnnemy.SetActive(false);
    }

    private Boolean checkCurrentTeam()
    {
        String name = fightmanager.champions[fightmanager.getIndiceChampionCourant()].name;
        if (name == fightmanager.getTeam1()[0].name || name == fightmanager.getTeam1()[1].name ||
            name == fightmanager.getTeam1()[2].name)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
