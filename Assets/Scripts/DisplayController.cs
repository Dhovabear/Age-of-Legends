using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayController : MonoBehaviour
{
    public Text champ1Name;
    public Text champ1Health;
    public Text champ2Name;
    public Text champ2Health;
    public Text champ3Name;
    public Text champ3Health;
    public Text champ4Name;
    public Text champ4Health;
    public FightManager fightmanager;

    public Button button;

    private void testAttack()
    {
        DohmaController dom = ((DohmaController) fightmanager.champions[0]);
        AshaarjController ash = ((AshaarjController) fightmanager.champions[3]);
        dom.spell1(ash);
        champ4Health.text = "Vie :" + ash.Hp;
        Debug.Log("pute");
        Debug.Log(ash.Hp);
    }
    // Start is called before the first frame update
    void Start()
    {
        champ1Name.text =fightmanager.champions[0].Name;
        champ1Health.text = "Vie :" + fightmanager.champions[0].Hp;
        champ4Name.text =fightmanager.champions[3].Name;
        champ4Health.text = "Vie :" + fightmanager.champions[3].Hp;
        button.onClick.AddListener(testAttack);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
