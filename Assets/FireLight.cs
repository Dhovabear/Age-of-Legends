using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class FireLight : MonoBehaviour
{
    // Start is called before the first frame update

    #region Private Fields

    private Light _light;

    
    
    #endregion

    #region Public fields

    public float minVal = 7f;
    public float maxVal = 25f;
    public float pas = 1f;
    
    #endregion
    
    void Start()
    {
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float variation;//variable qui va déterminer le 'mouvement' de l'intensité

        if (Random.Range(0, 2)==1)//condition bête, 1 chance sur 2
        {
            variation = (_light.intensity <= maxVal) ? pas : -pas;//expression ternaire pour gerer le dépassement
        }
        else
        {
            variation = (_light.intensity > minVal) ? -pas : pas;
        }
        
        _light.intensity += variation;//on applique la variation
    }
}
