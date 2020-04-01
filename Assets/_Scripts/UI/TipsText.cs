using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.PlayerLoop;

public class TipsText : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler 
{

    public string tips;
    public static GameObject tipText;

    private bool mouseIn = false;
    public static void init()
    {
        tipText = GameObject.Find("Tips");
        tipText.SetActive(false);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        tipText.SetActive(true);
        mouseIn = true;
        tipText.GetComponent<TextMeshProUGUI>().text = tips;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseIn = false;
        tipText.SetActive(false);
    }

    private void Update()
    {
        if (!mouseIn) return;
        tipText.transform.position = Input.mousePosition + Vector3.right*110f;
    }
}
