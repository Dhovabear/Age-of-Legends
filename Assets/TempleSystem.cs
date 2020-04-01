using System.Collections;
using System.Collections.Generic;
using Prototype.Unitees;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TempleSystem : MonoBehaviour
{

    public List<Upgrade> listBonus;

    public List<Upgrade> bonusAchetees;

    public GameObject boutonPrefab;
    
    public  Image progressbar;

    public Image logocurrent;

    public GameObject grilleUpdgrades;

    public GameObject grilleUprgadesAchetees;

    public Upgrade currentUpgrade;
    public GameObject bouttonMem;
    
    public float upgradeProgression;
    public float pas;

    public static TempleSystem current;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var upgrade in listBonus)
        {
            var no = GameObject.Instantiate(boutonPrefab,grilleUpdgrades.transform);
            no.GetComponent<Image>().sprite = upgrade.logo;
            no.GetComponent<Button>().onClick.AddListener(delegate { apply(no,upgrade); });
            no.GetComponent<TipsText>().tips = upgrade.nom + "\n" + upgrade.description;
        }

        TempleSystem.current = this;

        gameObject.SetActive(false);
    }
    

    void apply(GameObject bouton,Upgrade bonus)
    {
        bouttonMem = bouton;
        TipsText.tipText.SetActive(false);
        bouttonMem.SetActive(false);
        logocurrent.sprite = bonus.logo;
        upgradeProgression = 0;
        progressbar.fillAmount = 0;
        currentUpgrade = bonus;
        pas = 1 / (float)bonus.tempPriere;
        
    }

    public void refreshUpdates()
    {
        progressbar.fillAmount = upgradeProgression;
        if (upgradeProgression >= 1)
        {
            UpgradesStats.HeroDamageBonus += currentUpgrade.HeroDamageBonus;
            UpgradesStats.HeroDefenseBonus += currentUpgrade.HeroDefenseBonus;
            UpgradesStats.HeroLifeBonus += currentUpgrade.HeroLifeBonus;
            UpgradesStats.HeroUltiBonus += currentUpgrade.HeroUltiBonus;
            
            currentUpgrade = null;
            logocurrent.sprite = null;
            upgradeProgression = 0;
            pas = 0;
            bouttonMem.SetActive(true);
            bouttonMem.transform.parent = grilleUprgadesAchetees.transform;
            bouttonMem.GetComponent<Button>().onClick.RemoveAllListeners();
            bouttonMem.GetComponent<Button>().interactable = false;

        }
    }
    
    
}
