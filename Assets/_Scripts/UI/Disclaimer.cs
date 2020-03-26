using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Disclaimer : MonoBehaviour
{
    public static Disclaimer current;
    

    private TextMeshProUGUI txt;
    
    // Start is called before the first frame update
    void Start()
    {
        if (current == null) current = this;
        txt = GetComponent<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }

    public void displayTime(String message, Color couleur,float duration)
    {
        display(message,couleur);
        StartCoroutine(delayDisplay(duration));
    }

    public void display(String message, Color couleur)
    {
        gameObject.SetActive(true);
        txt.color = couleur;
        txt.text = message;
    }

    public void hide()
    {
        gameObject.SetActive(false);
    }

    IEnumerator delayDisplay(float delay)
    {
        yield return new WaitForSeconds(delay);
        hide();
    }
    
}
