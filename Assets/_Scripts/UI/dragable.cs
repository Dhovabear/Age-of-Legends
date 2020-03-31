using System;
using System.Collections;
using System.Collections.Generic;
using CollectPhase;
using Prototype.Unitees;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragable : MonoBehaviour , IBeginDragHandler , IDragHandler, IEndDragHandler
{
    private Vector2 decalage;
    private PlayerManager pm;
    private UniteManager um;

    

    public void OnBeginDrag(PointerEventData eventData)
    {
        decalage = eventData.position - (Vector2)GetComponent<RectTransform>().position;
        um = GameObject.Find("PlayerCamera").GetComponent<UniteManager>();
        pm = GameObject.Find("Scripts").GetComponent<PlayerManager>();
        pm.canInteract = false;
        um.canInsteract = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().position = eventData.position - decalage;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        pm = GameObject.Find("Scripts").GetComponent<PlayerManager>();
        pm.canInteract = true;
        um.canInsteract = true;
    }
}
