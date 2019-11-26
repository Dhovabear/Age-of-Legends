using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Prototype.Unitees;
using Prototype.Camera;


enum TypeRes
{
    Cristal,
    Mana
}

[RequireComponent(typeof(Collider))]
public class RessourcesContainer : MonoBehaviour, IFocusable
{

    #region Private SerializeFields

    [SerializeField]private int resPerSecondPerUnit = 0;
    [SerializeField]private Text infoToDisplay;

    [SerializeField]
    private TypeRes _typeRes;
    
    #endregion

    #region private Fields

    private List<Unite> pInZone;

        
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        pInZone = new List<Unite>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region OnTriggerCallbacks

    void OnTriggerEnter(Collider other)
    {
        Unite un;
        if(!(un = other.gameObject.GetComponent<Unite>())){return;}
        pInZone.Add(un);
        if (pInZone.Count == 0)
        {
            StartCoroutine(EarnRessources());
        }
    }

    void OnTriggerExit(Collider other){
        Unite un;
        if(!(un = other.gameObject.GetComponent<Unite>())){return;}
        pInZone.Remove(un);
    }

    #endregion

    #region OnMouseCallbacks     
    
    void OnMouseEnter(){
        infoToDisplay.gameObject.SetActive(true);
        
    }

    void OnMouseOver(){
        RectTransform rt = infoToDisplay.gameObject.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(Input.mousePosition.x + 80,Input.mousePosition.y);
        infoToDisplay.text = resPerSecondPerUnit + " r/s\n" + pInZone.Count + "collecting";
    }

    void OnMouseExit(){
        infoToDisplay.gameObject.SetActive(false);
    }

    #endregion

    private IEnumerator EarnRessources()
    {
        while (pInZone.Count > 0)
        {
            yield return new WaitForSeconds(1f);//On attend une seconde
            if (_typeRes == TypeRes.Mana)
            {
                GameManager.current.GetPlayerManager().EarnMana(resPerSecondPerUnit);
            }
            else
            {
                GameManager.current.GetPlayerManager().EarnCristal(resPerSecondPerUnit);
            }
        }
    }
}
