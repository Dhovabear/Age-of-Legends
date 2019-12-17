using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public Text champ4Name;
    public Text champ4Health;
    public FightManager fightmanager;
    public GameObject pane;
    public Button button;

    private void testAttack()
    {
        fightmanager.getTeam1()[0].spell1(fightmanager.getTeam2()[0]);
        updateInfos();
        pane.SetActive(true);
        button.interactable = false;
    }

    private void updateInfos()
    {
        champ1Name.text =fightmanager.getTeam1()[0].Name;
        champ1Health.text = "Vie :" + fightmanager.getTeam1()[0].Hp;
        champ1Ult.text = " Ult : " + fightmanager.getTeam1()[0].Ultime + "/100";
        
        champ2Name.text =fightmanager.getTeam1()[1].Name;
        champ2Health.text = "Vie :" + fightmanager.getTeam1()[1].Hp;
        champ2Ult.text = " Ult : " + fightmanager.getTeam1()[1].Ultime + "/100";
        
        champ3Name.text =fightmanager.getTeam1()[2].Name;
        champ3Health.text = "Vie :" + fightmanager.getTeam1()[2].Hp;
        champ3Ult.text = " Ult : " + fightmanager.getTeam1()[2].Ultime + "/100";
        
        champ4Name.text =fightmanager.getTeam2()[0].Name;
        champ4Health.text = "Vie :" + fightmanager.getTeam2()[0].Hp;
    }
    // Start is called before the first frame update
    void Start()
    {
        updateInfos();
        pane.SetActive(false);
        
        button.onClick.AddListener(testAttack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
