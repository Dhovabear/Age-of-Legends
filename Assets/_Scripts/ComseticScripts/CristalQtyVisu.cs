using System.Collections;
using System.Collections.Generic;
using CollectPhase;
using UnityEngine;

public class CristalQtyVisu : MonoBehaviour
{

    private List<Transform> cristaux;
    [SerializeField]private RessourcesContainer _rc;

    // Start is called before the first frame update
    void Start()
    {
        cristaux = new List<Transform>(GetComponentsInChildren<Transform>());
    }

    // Update is called once per frame
    void Update()
    {
        updateRess();
    }

    void updateRess(){
        float cristToShow = ((float)_rc.GetResCount()) / ((float)_rc.GetMaxRes());
        int cToHide = cristaux.Count - (int)(cristaux.Count * cristToShow);
        Debug.Log("resCount: "+ _rc.GetResCount() +"critToShau: " + cristToShow + "  ctohide: " + cToHide);
        
        for(int i = 1 ; i < cToHide ; i++){
            cristaux[i].gameObject.SetActive(false);
        }
    }
}
