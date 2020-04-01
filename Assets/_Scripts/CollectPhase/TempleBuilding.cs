using System;
using System.Collections;
using System.Collections.Generic;
using Prototype.Unitees;
using UnityEngine;
using UnityEngine.UI;

public class TempleBuilding : Container
{
    public static TempleBuilding current;

    private bool mouseOver = false;
    
    public override void initialise()
    {
        current = this;
    }

    public override void displayInfo(Text text)
    {
        text.gameObject.SetActive(true);
        RectTransform rt = text.gameObject.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(Input.mousePosition.x + 80,Input.mousePosition.y);
        text.text = "yolooooo";
    }
    
    public void updatePrieres()
    {
        
        if (TempleSystem.current.currentUpgrade == null) return;
        
        foreach (Unite u in uniteInZone)
        {
           TempleSystem.current.upgradeProgression += TempleSystem.current.pas;
        }
        TempleSystem.current.refreshUpdates();
        
    }
    
    void OnMouseEnter()
    {
        base.OnMouseEnter();
        infoDisp.gameObject.SetActive(true);
        mouseOver = true;
    }
    
    void OnMouseExit(){
        base.OnMouseEnter();
        infoDisp.gameObject.SetActive(false);
        mouseOver = false;
    }

    private void Update()
    {
        if (mouseOver && Input.GetMouseButtonDown(0))
        {
            TempleSystem.current.gameObject.SetActive(true);
        }
    }
}
