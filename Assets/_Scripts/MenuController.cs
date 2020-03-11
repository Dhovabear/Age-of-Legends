using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private int quality=2;
    private float volume = 0.5f;

    Slider volumeSlider;
    public void playGame() {

        SceneManager.LoadScene(1);
    }

    public void quitGame() {

        Debug.Log("Quit");
        Application.Quit();
    }

    public void changeQuality(int quality) {

        switch (quality) {

            case 1: 
                QualitySettings.SetQualityLevel(1, true);
                Debug.Log("Quality settings set to 'Fast'");
                break;

            case 2 :  
                QualitySettings.SetQualityLevel(2, true);
                Debug.Log("Quality settings set to 'Medium'");
                break;

            case 3 :  
                QualitySettings.SetQualityLevel(3, true);
                Debug.Log("Quality settings set to 'High'");
                break;            
        }
    }
    public void changeVolume() {

        GameObject temp = GameObject.Find("VolumeSlider");
         if (temp != null) {
             // Get the Slider Component
             volumeSlider = temp.GetComponent<Slider>();

             if (volumeSlider != null) {

                 volumeSlider.value = volume;
             }
        } 
    }

    public void volumeSliderChanged() {
        
        volume = volumeSlider.value;
    } 
    
    public void saveGame() {

        PlayerPrefs.SetInt("quality",quality);
        PlayerPrefs.SetFloat("volume",volume);
        Debug.Log("Volume value saved "+volume);
    }

    public void loadGamePrefs() {

        if (PlayerPrefs.HasKey("quality")) {
            quality = PlayerPrefs.GetInt("quality");
            changeQuality(quality);
        }

        if (PlayerPrefs.HasKey("volume")) {
            volume = PlayerPrefs.GetFloat("volume");
            Debug.Log("Volume value read "+ volume);
            changeVolume();
        }
    }
}
