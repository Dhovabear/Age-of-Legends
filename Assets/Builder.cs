using System.Collections;
using System.Collections.Generic;
using Prototype.Unitees;
using UnityEngine;
using UnityEngine.UI;

public class Builder : Container
{
    public static List<Builder> builderList;
    public static List<Builder> toRemove;

    #region Private fields

    private float buildPercent;
    private int idToBuild;

    #endregion

    #region private Serialized fields

    [Header("Liens vers les objets")]
    [SerializeField] private Image Bar;

    [Header("A regler dans le préfab")] 
    public List<GameObject> buildingList;
    
    #endregion

    #region Container methods

    public override void initialise()
    {
        //check si il créer la liste donc wola
        
        builderList.Add(this);

        Bar = GetComponentsInChildren<Image>()[0];
        
        buildPercent = 0f;
        Bar.fillAmount = buildPercent;
    }

    public override void displayInfo(Text text)
    {
        text.text = "Building ";
        text.text += buildingList[idToBuild].name;

        text.text += "\n " + buildPercent * 100f + "%";
        RectTransform rt = text.gameObject.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(Input.mousePosition.x + 80,Input.mousePosition.y);

    }

    #endregion

    #region Autres methodes

    public void updateBuild()
    {
        if (buildPercent >= 1)
        {
            var obj = GameObject.Instantiate(buildingList[idToBuild],transform.position,transform.rotation);
            obj.transform.localScale = Vector3.one*3;
            //On ajoute dans les listes
            if(idToBuild == 0) GameManager.current.cristRepo.Add(obj.GetComponent<ObjectifContainer>());
            if(idToBuild == 1) GameManager.current.manaRepo.Add(obj.GetComponent<ObjectifContainer>());
            toRemove.Add(this);
            Destroy(gameObject);
        }

        foreach (Unite unite in uniteInZone)
        {
            buildPercent += 0.001f;
        }
        Debug.Log(uniteInZone.Count);
        Bar.fillAmount = buildPercent;
    }

    public void setBuildingID(int id)
    {
        //if(id >= buildingList.Count) faut juste pas etre con
        idToBuild = id;
    }

    /*
     * Fonction incroyable qui va permettre au player manager d'initialiser la liste et de pas tout casser
     */
    public static void initLists()
    {
        if (builderList == null) {builderList = new List<Builder>();}
        if(toRemove == null) toRemove = new List<Builder>();
    }

    #endregion
}
