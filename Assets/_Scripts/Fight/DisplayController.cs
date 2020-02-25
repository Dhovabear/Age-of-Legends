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
    private Slider champ1Slider;
   /* public Text champ1Health;
    public Text champ1Ult;*/
    
    public Text champ2Name;
   /* public Text champ2Health;
    public Text champ2Ult;*/
    
    public Text champ3Name;
   /* public Text champ3Health;
    public Text champ3Ult;*/
    
    public Text enemy1Name;
   /* public Text enemy1Health;
    public Text enemy1Ult;*/
    
    public Text enemy2Name;
   /* public Text enemy2Health;
    public Text enemy2Ult;*/
    
    public Text enemy3Name;
    /*public Text enemy3Health;
    public Text enemy3Ult;*/
    
    public Text champ4Name;
    public Text champ4Health;

    public Text currentEnnemyInfo;
    
    public FightManager fightmanager;
    
    public GameObject paneEnnemy;
    
    public Button button;
    
    /*public Button spell1;
    public Button spell2;
    public Button ult;
    
    public Button enemy1;
    public Button enemy2;
    public Button enemy3;*/

    public int currentSpell = 0;

    private List<ChampionController> champions;

    public GameObject playerPointer;

    private ChampionController currentChamp;

    private Animator anim;
    private Animator animEnemy;

    private GameObject attackUi;


    //VIVI VARIABLES

    private bool waitingForClick = false;
    private ChampionController target;
    private GameObject aideText;

    // Start is called before the first frame update

    private GameObject leftTeam;
    private GameObject rightTeam;



    private Text leftChamp1Name;
    private Text leftChamp2Name;
    private Text leftChamp3Name;

   



    private Text rightChamp1Name;
    private Text rightChamp2Name;
    private Text rightChamp3Name;


    Slider[] leftChampsHealth = new Slider[3];
    Slider[] leftChampsUlt = new Slider[3];

    Slider[] rightChampsHealth = new Slider[3];
    Slider[] rightChampsUlt = new Slider[3];

    private Text spellDescriptionText;
    void Start()
    {
        aideText = GameObject.Find("aideText");
        spellDescriptionText = GameObject.Find("SpellDescriptionText").GetComponent<Text>();
        aideText.SetActive(false);
        champ4Name.text = "";
        champions = fightmanager.champions;
        paneEnnemy.SetActive(false);
        //anim = fightmanager.getTeam1()[2].GetComponent<Animator>();
        attackUi = GameObject.Find("UIattack");
        //button.onClick.AddListener(nextTurn);
        currentEnnemyInfo.text = "";
        champ4Name.text = "";
        initChampionInfo();
        updateInfos();

    }
    public void initChampionInfo()
    {
        leftTeam = GameObject.Find("PanelLeftTeam");
        rightTeam = GameObject.Find("PanelRightTeam");

        GameObject leftChamp1 = leftTeam.transform.Find("CadreChampion1").gameObject;
        GameObject leftChamp2 = leftTeam.transform.Find("CadreChampion2").gameObject;
        GameObject leftChamp3 = leftTeam.transform.Find("CadreChampion3").gameObject;

        leftChamp1Name = leftChamp1.transform.Find("rightHolder/ChampName").GetComponent<Text>();
        leftChamp2Name = leftChamp2.transform.Find("rightHolder/ChampName").GetComponent<Text>();
        leftChamp3Name = leftChamp3.transform.Find("rightHolder/ChampName").GetComponent<Text>();

        leftChamp1Name.text = fightmanager.getTeam1()[0].Name;
        leftChamp2Name.text = fightmanager.getTeam1()[1].Name;
        leftChamp3Name.text = fightmanager.getTeam1()[2].Name;


        Slider leftChamp1Health = leftChamp1.transform.Find("rightHolder/ChampHealthSlider").GetComponent<Slider>();
        Slider leftChamp2Health = leftChamp2.transform.Find("rightHolder/ChampHealthSlider").GetComponent<Slider>();
        Slider leftChamp3Health = leftChamp3.transform.Find("rightHolder/ChampHealthSlider").GetComponent<Slider>();

        leftChampsHealth[0] = leftChamp1Health;
        leftChampsHealth[1] = leftChamp2Health;
        leftChampsHealth[2] = leftChamp3Health;


        Slider leftChamp1Ult = leftChamp1.transform.Find("rightHolder/ChampUltimateSlider").GetComponent<Slider>();
        Slider leftChamp2Ult = leftChamp2.transform.Find("rightHolder/ChampUltimateSlider").GetComponent<Slider>();
        Slider leftChamp3Ult = leftChamp3.transform.Find("rightHolder/ChampUltimateSlider").GetComponent<Slider>();

        leftChampsUlt[0] = leftChamp1Ult;
        leftChampsUlt[1] = leftChamp2Ult;
        leftChampsUlt[2] = leftChamp3Ult;

        GameObject rightChamp1 = rightTeam.transform.Find("CadreChampion1").gameObject;
        GameObject rightChamp2 = rightTeam.transform.Find("CadreChampion2").gameObject;
        GameObject rightChamp3 = rightTeam.transform.Find("CadreChampion3").gameObject;

        rightChamp1Name = rightChamp1.transform.Find("rightHolder/ChampName").GetComponent<Text>();
        rightChamp2Name = rightChamp2.transform.Find("rightHolder/ChampName").GetComponent<Text>();
        rightChamp3Name = rightChamp3.transform.Find("rightHolder/ChampName").GetComponent<Text>();

        rightChamp1Name.text = fightmanager.getTeam2()[0].Name;
        rightChamp2Name.text = fightmanager.getTeam2()[1].Name;
        rightChamp3Name.text = fightmanager.getTeam2()[2].Name;


        Slider rightChamp1Health = rightChamp1.transform.Find("rightHolder/ChampHealthSlider").GetComponent<Slider>();
        Slider rightChamp2Health = rightChamp2.transform.Find("rightHolder/ChampHealthSlider").GetComponent<Slider>();
        Slider rightChamp3Health = rightChamp3.transform.Find("rightHolder/ChampHealthSlider").GetComponent<Slider>();

        rightChampsHealth[0] = rightChamp1Health;
        rightChampsHealth[1] = rightChamp2Health;
        rightChampsHealth[2] = rightChamp3Health;
        

        Slider rightChamp1Ult = rightChamp1.transform.Find("rightHolder/ChampUltimateSlider").GetComponent<Slider>();
        Slider rightChamp2Ult = rightChamp2.transform.Find("rightHolder/ChampUltimateSlider").GetComponent<Slider>();
        Slider rightChamp3Ult = rightChamp3.transform.Find("rightHolder/ChampUltimateSlider").GetComponent<Slider>();

        rightChampsUlt[0] = rightChamp1Ult;
        rightChampsUlt[1] = rightChamp2Ult;
        rightChampsUlt[2] = rightChamp3Ult;

        for(int i = 0 ; i<3 ; i++)
        {
            leftChampsHealth[i].maxValue = fightmanager.getTeam1()[i].Hp;
            leftChampsHealth[i].value = leftChampsHealth[i].maxValue;
            //print(fightmanager.getTeam1()[i].name);

            rightChampsHealth[i].maxValue = fightmanager.getTeam2()[i].Hp;
            rightChampsHealth[i].value = rightChampsHealth[i].maxValue;
            print(fightmanager.getTeam2()[i].Hp);



            leftChampsUlt[i].maxValue = 100f;
            leftChampsUlt[i].value = 0f;

            rightChampsUlt[i].maxValue = 100f;
            rightChampsUlt[i].value = 0f;
        }


    }



    

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
        if (fightmanager.champions[fightmanager.getIndiceChampionCourant()].Hp <= 0)
        {
            nextTurn();
            print("skip");
        }
        updateInfos();

        
    }

    private void updateInfos()
    {
    	currentChamp = fightmanager.champions[fightmanager.getIndiceChampionCourant()];
        playerPointer.transform.position = currentChamp.gameObject.transform.position +
                                           Vector3.up * currentChamp.gameObject.transform.localScale.y * 2.1f;
        //UPDATE DES SLIDER DE VIE DE TOUT LE MONDE 
        for (int i = 0; i < 3; i++)
        {
            //leftChampsHealth[i].value = fightmanager.getTeam1()[i].Hp;
            leftChampsHealth[i].value = fightmanager.getTeam1()[i].Hp;
            leftChampsUlt[i].value = fightmanager.getTeam1()[i].Ultime;

            rightChampsHealth[i].value = fightmanager.getTeam2()[i].Hp;
            rightChampsUlt[i].value = fightmanager.getTeam2()[i].Ultime;

        }

        #region ancien code

        /*champ1Name.text =fightmanager.getTeam1()[0].Name;
        champ1Health.text = "Vie : " + fightmanager.getTeam1()[0].Hp;
        champ1Ult.text = " Ult : " + fightmanager.getTeam1()[0].Ultime + "/100";

        champ2Name.text =fightmanager.getTeam1()[1].Name;
        champ2Health.text = "Vie : " + fightmanager.getTeam1()[1].Hp;
        champ2Ult.text = " Ult : " + fightmanager.getTeam1()[1].Ultime + "/100";

        champ3Name.text =fightmanager.getTeam1()[2].Name;
        champ3Health.text = "Vie : " + fightmanager.getTeam1()[2].Hp;
        champ3Ult.text = " Ult : " + fightmanager.getTeam1()[2].Ultime + "/100";

        enemy1Name.text =fightmanager.getTeam2()[0].Name;
        enemy1Health.text = "Vie : " + fightmanager.getTeam2()[0].Hp;
        enemy1Ult.text = " Ult : " + fightmanager.getTeam1()[0].Ultime + "/100";

        enemy2Name.text =fightmanager.getTeam2()[1].Name;
        enemy2Health.text = "Vie : " + fightmanager.getTeam2()[1].Hp;
        enemy2Ult.text = " Ult : " + fightmanager.getTeam2()[1].Ultime + "/100";

        enemy3Name.text =fightmanager.getTeam2()[2].Name;
        enemy3Health.text = "Vie : " + fightmanager.getTeam2()[2].Hp;
        enemy3Ult.text = " Ult : " + fightmanager.getTeam2()[2].Ultime + "/100";*/


        /*if (champions[fightmanager.getIndiceChampionCourant()].Name == fightmanager.getTeam1()[0].Name)
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
        }*/
        #endregion
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
        waitingForClick = true;
        aideText.SetActive(true);
        spellDescriptionText.text = fightmanager.champions[fightmanager.getIndiceChampionCourant()].descSpell[currentSpell];

    }





    IEnumerator hitEffect()
    {
        
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.8f);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        animEnemy.SetTrigger("hurt");
        yield return new WaitForSeconds(1.2f);
        nextTurn();
        updateInfos();
        attackUi.SetActive(true);
    }

    /*public void launchSpell(int id)
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
                    anim = fightmanager.champions[fightmanager.getIndiceChampionCourant()].GetComponent<Animator>();
                    anim.SetTrigger("launch_spell");
                    animEnemy = fightmanager.getTeam2()[id].GetComponent<Animator>();
                    StartCoroutine(hitEffect());
                }
                else
                {
                    fightmanager.champions[fightmanager.getIndiceChampionCourant()].spell1(fightmanager.getTeam1()[id]);
                    targetName = fightmanager.getTeam1()[id].name;
                    anim = fightmanager.champions[fightmanager.getIndiceChampionCourant()].GetComponent<Animator>();
                    anim.SetTrigger("launch_spell");
                    animEnemy = fightmanager.getTeam1()[id].GetComponent<Animator>();
                    StartCoroutine(hitEffect());

                }
                champ4Name.text = fightmanager.champions[fightmanager.getIndiceChampionCourant()].name +
                                  " a lancé son sort 1 sur " + targetName;
                break;
            case 1:

                break;
        }

        attackUi.SetActive(false);
        paneEnnemy.SetActive(false);
    }*/

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
       

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
               
                if (hit.collider.tag == "team1" || hit.collider.tag == "team2")
                {
                    if (waitingForClick)
                    {
                        target = hit.collider.gameObject.GetComponent<ChampionController>();
                        if(target.Hp > 0)
                        {
                            launchSpellV2(target);

                        }
                    }
                    
                }

            }
        }
    }

    public void launchSpellV2(ChampionController cc)
    {
        String name = fightmanager.champions[fightmanager.getIndiceChampionCourant()].name;
        String targetName = cc.gameObject.name;
        String spellTarget = fightmanager.champions[fightmanager.getIndiceChampionCourant()].spellsTarget[currentSpell];
        switch (spellTarget)
        {
            case "Enemy":
                if (!isSameTeam(cc))
                {
                    characterAttack(cc);
                }
                break;

            case "Ally":
                if (isSameTeam(cc))
                {
                    characterAttack(cc);
                }
                break;

            case "Everyone":
                characterAttack(cc);
                break;
        }


        /*switch (currentSpell)
        {
            case 0:
                if (currentChamp.gameObject.tag == "team1" && cc.gameObject.tag=="team2" ||
                    currentChamp.gameObject.tag == "team2" && cc.gameObject.tag == "team1")
                {
                    characterAttack(cc);
                    champ4Name.text = fightmanager.champions[fightmanager.getIndiceChampionCourant()].name +
                                  " a lancé son sort 1 sur " + targetName;
                }
                
                break;
            case 1:

                break;
        }*/

        
    }

    public bool isSameTeam(ChampionController cc)
    {
        if (currentChamp.gameObject.tag == "team1" && cc.gameObject.tag == "team2" ||
                    currentChamp.gameObject.tag == "team2" && cc.gameObject.tag == "team1")
        {
            return false;
        }
        return true;
            
    }
    public void characterAttack(ChampionController cc)
    {
        anim = fightmanager.champions[fightmanager.getIndiceChampionCourant()].GetComponent<Animator>();

        switch (currentSpell)
        {
            case 0:
                fightmanager.champions[fightmanager.getIndiceChampionCourant()].autoAttack(cc);
                champ4Name.text = fightmanager.champions[fightmanager.getIndiceChampionCourant()].Name +
                                  " a lancé son sort attaque de base sur " + cc.Name;
                anim.SetTrigger("auto_attack");
                break;
            case 1:
                fightmanager.champions[fightmanager.getIndiceChampionCourant()].spell1(cc);
                champ4Name.text = fightmanager.champions[fightmanager.getIndiceChampionCourant()].Name +
                                  " a lancé son sort 1 sur " + cc.Name;
                anim.SetTrigger("launch_spell");
                break;
           case 2:
                fightmanager.champions[fightmanager.getIndiceChampionCourant()].spell2(cc);
                champ4Name.text = fightmanager.champions[fightmanager.getIndiceChampionCourant()].Name +
                                  " a lancé son sort 2 sur " + cc.Name;
                anim.SetTrigger("launch_spell");

                break;
            case 3:
                if (fightmanager.champions[fightmanager.getIndiceChampionCourant()].Ultime < 100) return;
                fightmanager.champions[fightmanager.getIndiceChampionCourant()].ultimate(cc);
                champ4Name.text = fightmanager.champions[fightmanager.getIndiceChampionCourant()].Name +
                                  " a lancé son ultime sur " + cc.Name;
                break;
        }
        //fightmanager.champions[fightmanager.getIndiceChampionCourant()].spell1(cc);

        //fightmanager.champions[fightmanager.getIndiceChampionCourant()].spell1(cc);
        
        
        animEnemy = cc.GetComponent<Animator>();
        StartCoroutine(hitEffect());

        attackUi.SetActive(false);
        paneEnnemy.SetActive(false);
        aideText.SetActive(false);
        waitingForClick = false;

    }
}
