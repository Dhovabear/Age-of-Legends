using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class In_Game_Menu_Script : MonoBehaviour {

    private bool isMenuAsked;
    private GameObject menu;

    // Start is called before the first frame update
    void Start() {

        menu = GameObject.Find("InGameMenu");
        menu.SetActive(false);
        isMenuAsked = false;
    }

    // Update is called once per frame
    void Update() {

        if ( Input.GetKeyDown("escape") ) {
            if( ! isMenuAsked ) {
                print("Open menu");
                isMenuAsked = true;
            }else {
                print("Close menu");
                isMenuAsked = false;
            }

            if ( isMenuAsked ) {    // load the menu 
                menu.SetActive(true);
            }else {     // hide the menu
                menu.SetActive(false);
            }
        }
    }
}
